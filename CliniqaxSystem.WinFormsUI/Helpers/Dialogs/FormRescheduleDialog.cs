using CliniqaxSystem.Application.DTOs.Appointment;
using CliniqaxSystem.Application.Interfaces.Services;

namespace CliniqaxSystem.WinFormsUI.Helpers.Dialogs 
{
    public partial class FormRescheduleDialog : Form
    {
        private readonly IAppointmentService _appointmentService;
        private readonly AppointmentDto _appointment;
        private readonly TimeSpan _appointmentDuration;

        public FormRescheduleDialog(IAppointmentService appointmentService, AppointmentDto appointment)
        {
            _appointmentService = appointmentService;
            _appointment = appointment;

            var appointmentDuration = _appointment.EndTime - _appointment.StartTime;
            _appointmentDuration = appointmentDuration > TimeSpan.Zero ? appointmentDuration : TimeSpan.FromMinutes(30);

            InitializeComponent();
            UIThemeHelper.ApplyFormStyle(this);
            UIThemeHelper.ApplyCardStyle(panelCard);

            // Vinculación de iconos superpuestos
            ButtonIconOverlayHelper.BindEvents(this.buttonConfirm, this.picIconConfirm);
            ButtonIconOverlayHelper.BindEvents(this.buttonCancel, this.picIconCancel);

            // Eventos
            this.Load += (s, e) => InitializeDialogData();
            this.dateTimePickerStartTime.ValueChanged += (s, e) => CalculateAutomaticEndTime();
            this.buttonConfirm.Click += async (s, e) => await ExecuteRescheduleAsync();
            this.buttonCancel.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };
        }

        private void InitializeDialogData()
        {
            labelPatientDisplay.Text = $"Paciente: {_appointment.PatientName} (DNI: {_appointment.PatientDocument})";
            labelProfessionalDisplay.Text = $"Médico: {_appointment.ProfessionalName} - {_appointment.SpecialtyName}";
            labelCurrentSlotDisplay.Text = $"Turno actual: {_appointment.AppointmentDate:dd/MM/yyyy} ({_appointment.TimeSlot})";

            dateTimePickerNewDate.Value = _appointment.AppointmentDate >= DateTime.Today ? _appointment.AppointmentDate : DateTime.Today;
            dateTimePickerStartTime.Value = DateTime.Today.Add(_appointment.StartTime);
            dateTimePickerEndTime.Value = DateTime.Today.Add(_appointment.EndTime);
        }

        private void CalculateAutomaticEndTime()
        {
            dateTimePickerEndTime.Value = dateTimePickerStartTime.Value.Add(_appointmentDuration);
        }

        private async Task ExecuteRescheduleAsync()
        {
            if (dateTimePickerNewDate.Value.Date < DateTime.Today)
            {
                UIHelper.WarnMessage(this, "La nueva fecha del turno no puede ser anterior al día de hoy.", "Fecha Inválida");
                dateTimePickerNewDate.Focus();
                return;
            }

            if (dateTimePickerStartTime.Value.TimeOfDay >= dateTimePickerEndTime.Value.TimeOfDay)
            {
                UIHelper.WarnMessage(this, "La hora de inicio debe ser anterior a la hora de finalización.", "Horario Inválido");
                dateTimePickerStartTime.Focus();
                return;
            }

            var appointmentReschedule = new AppointmentRescheduleDto
            {
                AppointmentId = _appointment.Id,
                NewDate = dateTimePickerNewDate.Value.Date,
                NewStartTime = dateTimePickerStartTime.Value.TimeOfDay,
                NewEndTime = dateTimePickerEndTime.Value.TimeOfDay
            };

            using (new WaitCursorHelper(this))
            {
                var result = await _appointmentService.RescheduleAppointmentAsync(appointmentReschedule);
                
                if (result.Success)
                {
                    UIHelper.ShowResult(result, "Reprogramación Exitosa");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    UIHelper.ShowResult(result, "Conflicto de Horario");
                }
            }
        }
    }
}
