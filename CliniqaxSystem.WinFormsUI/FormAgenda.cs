using CliniqaxSystem.Application.DTOs.Appointment;
using CliniqaxSystem.Application.DTOs.Professional;
using CliniqaxSystem.Application.Interfaces.Services;
using CliniqaxSystem.Domain.Enums;
using CliniqaxSystem.WinFormsUI.Helpers;
using CliniqaxSystem.WinFormsUI.Helpers.Dialogs;
using System.Data;

namespace CliniqaxSystem.WinFormsUI
{
    public partial class FormAgenda : Form
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IProfessionalService _professionalService;
        private readonly IPatientService _patientService;
        private readonly ICatalogService _catalogService;

        private bool _isInitializing = false;
        private readonly SemaphoreSlim _loadLock = new(1, 1);

        private List<ProfessionalDto> _professionals = new();
        private List<AgendaSlotDto> _currentSlots = new();
        private AgendaSlotDto? _selectedSlot = null;

        public FormAgenda(IAppointmentService appointmentService, IProfessionalService professionalService, IPatientService patientService, ICatalogService catalogService)
        {
            _appointmentService = appointmentService;
            _professionalService = professionalService;
            _patientService = patientService;
            _catalogService = catalogService;

            InitializeComponent();
            UIThemeHelper.ApplyFormStyle(this);
            UIThemeHelper.ApplyCardStyle(panelFiltersCard);
            UIThemeHelper.ApplyCardStyle(panelActionsCard);

            // Vinculación de iconos overlay
            ButtonIconOverlayHelper.BindEvents(this.buttonBookSlot, this.picIconBookSlot);
            ButtonIconOverlayHelper.BindEvents(this.buttonConfirmAppointment, this.picIconConfirm);
            ButtonIconOverlayHelper.BindEvents(this.buttonWaitingRoom, this.picIconWaitingRoom);
            ButtonIconOverlayHelper.BindEvents(this.buttonMarkAttended, this.picIconAttended);
            ButtonIconOverlayHelper.BindEvents(this.buttonCancelAppointment, this.picIconCancel);
            ButtonIconOverlayHelper.BindEvents(this.buttonRefresh, this.picIconRefresh);

            // Eventos
            this.Load += async (s, e) => await InitializeAgendaAsync();

            this.comboBoxProfessionals.SelectedIndexChanged += async (s, e) =>
            {
                if (!_isInitializing)
                    await LoadAgendaSlotsAsync();
            };

            this.dateTimePickerDate.ValueChanged += async (s, e) =>
            {
                if (!_isInitializing)
                    await LoadAgendaSlotsAsync();
            };

            this.buttonPrevDay.Click += (s, e) => ShiftDate(-1);
            this.buttonNextDay.Click += (s, e) => ShiftDate(1);
            this.buttonToday.Click += (s, e) => dateTimePickerDate.Value = DateTime.Today;
            this.buttonRefresh.Click += async (s, e) => await LoadAgendaSlotsAsync();

            // Acciones sobre turnos
            this.buttonBookSlot.Click += async (s, e) => await ExecuteBookAppointmentAsync();
            this.buttonConfirmAppointment.Click += async (s, e) => await ExecuteChangeStatusAsync(AppointmentStatus.Confirmed);
            this.buttonWaitingRoom.Click += async (s, e) => await ExecuteChangeStatusAsync(AppointmentStatus.Waiting);
            this.buttonMarkAttended.Click += async (s, e) => await ExecuteChangeStatusAsync(AppointmentStatus.Attended);
            this.buttonCancelAppointment.Click += async (s, e) => await ExecuteCancelAppointmentAsync();

            this.dataGridViewAgenda.CellClick += (s, e) => SynchronizeSelectedSlot();
            this.dataGridViewAgenda.CellFormatting += OnGridCellFormatting;
        }

        private async Task InitializeAgendaAsync()
        {
            _isInitializing = true;

            try
            {
                using (new WaitCursorHelper(this))
                {
                    _professionals = (await _professionalService.GetAllAsync()).ToList();

                    comboBoxProfessionals.DataSource = _professionals;
                    comboBoxProfessionals.DisplayMember = "FullName";
                    comboBoxProfessionals.ValueMember = "Id";

                    dateTimePickerDate.Value = DateTime.Today;

                    if (_professionals.Any())
                    {
                        comboBoxProfessionals.SelectedIndex = 0;
                    }
                }
            }
            finally
            {
                _isInitializing = false;
            }

            await LoadAgendaSlotsAsync();
        }

        private void ShiftDate(int days)
        {
            dateTimePickerDate.Value = dateTimePickerDate.Value.Date.AddDays(days);
        }

        private async Task LoadAgendaSlotsAsync()
        {
            if (_isInitializing)
                return;

            if (!await _loadLock.WaitAsync(0))
                return;

            try
            {
                if (comboBoxProfessionals.SelectedValue is not int professionalId || professionalId <= 0)
                {
                    labelScheduleInfo.Text = "Seleccione un profesional para ver su agenda.";
                    dataGridViewAgenda.DataSource = null;
                    return;
                }

                var selectedProfessional = _professionals.FirstOrDefault(p => p.Id == professionalId);
                var selectedDate = dateTimePickerDate.Value.Date;

                using (new WaitCursorHelper(this))
                {
                    var slots = await _appointmentService.GetDailyAgendaSlotsAsync(selectedDate, professionalId);
                    _currentSlots = slots.ToList();

                    if (!_currentSlots.Any())
                    {
                        labelScheduleInfo.Text = $"El Dr/a. {selectedProfessional?.FullName} no atiende los días {dateTimePickerDate.Value:dddd}.";
                        labelScheduleInfo.ForeColor = UIThemeHelper.Danger;
                    }
                    else
                    {
                        labelScheduleInfo.Text = $"Agenda del {selectedDate:dddd dd/MM/yyyy} - Turnos de {selectedProfessional?.AppointmentDuration} min";
                        labelScheduleInfo.ForeColor = UIThemeHelper.PrimaryDark;
                    }

                    var gridViewData = _currentSlots.Select(s => new
                    {
                        Horario = s.TimeRange,
                        Estado = s.IsAvailable ? "DISPONIBLE" : s.Appointment?.StatusName,
                        Paciente = s.IsAvailable ? "-" : s.Appointment?.PatientName,
                        DNI = s.IsAvailable ? "-" : s.Appointment?.PatientDocument,
                        Telefono = s.IsAvailable ? "-" : s.Appointment?.PatientPhone,
                        Especialidad = s.IsAvailable ? "-" : s.Appointment?.SpecialtyName,
                        Observaciones = s.Appointment?.Observations ?? ""
                    }).ToList();

                    dataGridViewAgenda.DataSource = null;
                    dataGridViewAgenda.DataSource = gridViewData;
                    UIHelper.FormatGrid(dataGridViewAgenda);

                    ResetSlotSelection();
                }
            }
            finally
            {
                _loadLock.Release();
            }
        }

        private void SynchronizeSelectedSlot()
        {
            if (dataGridViewAgenda.CurrentRow == null || dataGridViewAgenda.CurrentRow.Index < 0 || dataGridViewAgenda.CurrentRow.Index >= _currentSlots.Count)
            {
                ResetSlotSelection();
                return;
            }

            _selectedSlot = _currentSlots[dataGridViewAgenda.CurrentRow.Index];

            if (_selectedSlot.IsAvailable)
            {
                labelSelectedSlotInfo.Text = $"Franja Seleccionada: {_selectedSlot.TimeRange}  DISPONIBLE";
                labelSelectedSlotInfo.ForeColor = UIThemeHelper.Success;

                buttonBookSlot.Enabled = true;
                buttonConfirmAppointment.Enabled = false;
                buttonWaitingRoom.Enabled = false;
                buttonMarkAttended.Enabled = false;
                buttonCancelAppointment.Enabled = false;
            }
            else
            {
                var appointment = _selectedSlot.Appointment!;
                labelSelectedSlotInfo.Text = $"Turno: {appointment.TimeSlot} - Paciente: {appointment.PatientName} ({appointment.StatusName})";
                labelSelectedSlotInfo.ForeColor = UIThemeHelper.Primary;

                buttonBookSlot.Enabled = false;
                buttonConfirmAppointment.Enabled = appointment.Status == AppointmentStatus.Pending;
                buttonWaitingRoom.Enabled = appointment.Status == AppointmentStatus.Confirmed || appointment.Status == AppointmentStatus.Pending;
                buttonMarkAttended.Enabled = appointment.Status == AppointmentStatus.Waiting || appointment.Status == AppointmentStatus.Confirmed;
                buttonCancelAppointment.Enabled = appointment.Status != AppointmentStatus.Attended && appointment.Status != AppointmentStatus.Cancelled;
            }
        }

        private void ResetSlotSelection()
        {
            _selectedSlot = null;
            labelSelectedSlotInfo.Text = "Haga clic en una franja horaria de la tabla para operar.";
            labelSelectedSlotInfo.ForeColor = UIThemeHelper.TextMuted;

            buttonBookSlot.Enabled = false;
            buttonConfirmAppointment.Enabled = false;
            buttonWaitingRoom.Enabled = false;
            buttonMarkAttended.Enabled = false;
            buttonCancelAppointment.Enabled = false;
        }

        private async Task ExecuteBookAppointmentAsync()
        {
            if (_selectedSlot == null || !_selectedSlot.IsAvailable)
                return;

            int professionalId = (int)comboBoxProfessionals.SelectedValue!;
            var professional = _professionals.First(p => p.Id == professionalId);

            // Diálogo rápido para seleccionar paciente y especialidad
            using var bookDialog = new FormBookSlotDialog(_patientService, professional);
            
            if (bookDialog.ShowDialog(this) == DialogResult.OK)
            {
                var appointmentDto = new AppointmentCreateDto
                {
                    PatientId = bookDialog.SelectedPatientId,
                    ProfessionalId = professionalId,
                    SpecialtyId = bookDialog.SelectedSpecialtyId,
                    AppointmentDate = dateTimePickerDate.Value.Date,
                    StartTime = _selectedSlot.StartTime,
                    EndTime = _selectedSlot.EndTime,
                    Observations = bookDialog.Observations
                };

                using (new WaitCursorHelper(this))
                {
                    var result = await _appointmentService.CreateAppointmentAsync(appointmentDto);
                    UIHelper.ShowResult(result, "Reserva de Turno", async () =>
                    {
                        await LoadAgendaSlotsAsync();
                    });
                }
            }
        }

        private async Task ExecuteChangeStatusAsync(AppointmentStatus newStatus)
        {
            if (_selectedSlot?.Appointment == null) 
                return;

            using (new WaitCursorHelper(this))
            {
                var result = await _appointmentService.ChangeAppointmentStatusAsync(_selectedSlot.Appointment.Id, newStatus);
                UIHelper.ShowResult(result, "Estado del Turno", async () =>
                {
                    await LoadAgendaSlotsAsync();
                });
            }
        }

        private async Task ExecuteCancelAppointmentAsync()
        {
            if (_selectedSlot?.Appointment == null)
                return;

            string reason = "";
            using var prompt = new FormBlindCashCountDialog.FormPromptDialog("Cancelar Turno", "Motivo de la cancelación:");
            
            if (prompt.ShowDialog(this) == DialogResult.OK)
            {
                reason = prompt.EnteredDescription;
                using (new WaitCursorHelper(this))
                {
                    var result = await _appointmentService.ChangeAppointmentStatusAsync(_selectedSlot.Appointment.Id, AppointmentStatus.Cancelled, reason);
                    UIHelper.ShowResult(result, "Cancelar Turno", async () =>
                    {
                        await LoadAgendaSlotsAsync();
                    });
                }
            }
        }

        private void OnGridCellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dataGridViewAgenda.Rows.Count) 
                return;

            var estado = dataGridViewAgenda.Rows[e.RowIndex].Cells["Estado"].Value?.ToString();

            if (estado == "DISPONIBLE")
            {
                e.CellStyle.ForeColor = UIThemeHelper.Success;
                e.CellStyle.SelectionForeColor = Color.LimeGreen;
                e.CellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            }
            else if (estado == "En Espera")
            {
                e.CellStyle.ForeColor = UIThemeHelper.Primary;
                e.CellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            }
            else if (estado == "Atendido")
            {
                e.CellStyle.ForeColor = Color.FromArgb(100, 116, 139);
            }
            else if (estado == "Cancelado" || estado == "Ausente")
            {
                e.CellStyle.ForeColor = UIThemeHelper.Danger;
            }
        }
    }
}
