using CliniqaxSystem.Application.Common;

namespace CliniqaxSystem.WinFormsUI.Helpers
{
    public static class UIHelper
    {
        public static void CleanControls(Control container)
        {
            foreach (Control c in container.Controls)
            {
                if (c is TextBox t)
                    t.Clear();
                else if (c is ComboBox cb)
                    cb.SelectedIndex = -1;
                else if (c is NumericUpDown n)
                    n.Value = n.Minimum;
                else if (c is PictureBox p)
                    p.Image = null;

                if (c.HasChildren && c is not DataGridView)
                    CleanControls(c);
            }
        }

        public static void ShowResult(OperationResult result, string title, Action? onSuccess = null)
        {
            if (result.Success)
            {
                MessageBox.Show(result.Message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                onSuccess?.Invoke();
            }
            else
            {
                MessageBox.Show(result.Message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private static readonly Dictionary<string, string> _translations = new()
        {
            // Pacientes
            { "DocumentNumber", "DNI / Documento" },
            { "FirstName", "Nombre" },
            { "LastName", "Apellido" },
            { "FullName", "Paciente" },
            { "BirthDate", "Fecha Nacimiento" },
            { "Age", "Edad" },
            { "Phone", "Teléfono" },
            { "Email", "Correo Electrónico" },
            { "Address", "Dirección" },
            { "City", "Ciudad" },
            { "HealthInsuranceName", "Obra Social / Prepaga" },
            { "AffiliateNumber", "N.° Afiliado" },
            { "AdministrativeNotes", "Observaciones Administrativas" },

            // Profesionales
            { "LicenseNumber", "Matrícula" },
            { "AppointmentDurationMinutes", "Duración Turno (min)" },
            { "Observations", "Observaciones" },
            { "SpecialtyName", "Especialidad" },
            { "ProfessionalName", "Profesional" },

            // Turnos y Agenda
            { "AppointmentDate", "Fecha Turno" },
            { "StartTime", "Hora Inicio" },
            { "EndTime", "Hora Fin" },
            { "TimeSlot", "Horario" },
            { "StatusName", "Estado Turno" },
            { "PatientName", "Paciente" },
            { "PatientDocument", "DNI Paciente" },
            { "PatientPhone", "Teléfono" },
            { "CancellationReason", "Motivo Cancelación" },
            { "TimeRange", "Franja Horaria" },

            // Caja y Finanzas
            { "StationName", "Recepción / Puesto" },
            { "OpeningDate", "Apertura" },
            { "ClosingDate", "Cierre" },
            { "InitialCash", "Fondo Inicial" },
            { "RealCash", "Efectivo Contado" },
            { "ExpectedCash", "Efectivo Esperado" },
            { "Difference", "Diferencia" },
            { "TotalCashIncome", "Ingresos Efectivo" },
            { "TotalDebitIncome", "Ingresos Débito" },
            { "TotalCreditIncome", "Ingresos Crédito" },
            { "TotalTransferIncome", "Ingresos Transferencia" },
            { "TotalQrIncome", "Ingresos QR" },
            { "TotalManualCashIn", "Ingresos Manuales" },
            { "TotalManualCashOut", "Egresos / Retiros" },
            { "CurrentSystemCash", "Efectivo en Gaveta" },
            { "TotalTurnover", "Total Recaudado" },
            { "MovementTypeName", "Tipo Movimiento" },
            { "Amount", "Importe" },
            { "CopayAmount", "Copago" },
            { "ReceiptNumber", "N.° Comprobante" },
            { "PaymentMethodName", "Medio de Pago" },
            { "ClosingNotes", "Observaciones Cierre" },

            // Seguridad
            { "UserName", "Usuario" },
            { "Username", "Usuario" },
            { "RoleName", "Rol" },
            { "Status", "Estado" },

            // Auditoría / Papelera
            { "EntityType", "Módulo" },
            { "Identifier", "Identificador" },
            { "Name", "Nombre / Detalle" },
            { "AdditionalInfo", "Información Extra" },
            { "DeletedAt", "Fecha Baja" },
            { "DeletedBy", "Dado de baja por" }
        };

        public static void FormatGrid(DataGridView dgv)
        {
            if (dgv == null) 
                return;

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToResizeRows = false;
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;

            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(15, 23, 42); // Slate 900
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(15, 23, 42);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgv.ColumnHeadersHeight = 36;

            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 242, 254); // Slate Light
            dgv.DefaultCellStyle.SelectionForeColor = Color.FromArgb(3, 105, 161);
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            dgv.RowTemplate.Height = 30;

            string[] columnsToHide = {
            "Id", "IsDeleted", "RowVersion", "IsActive", "Status",
            "RoleId", "SpecialtyId", "ProfessionalId", "PatientId", "HealthInsuranceId",
            "UserId", "CashSessionId", "AppointmentId", "PaymentMethodId",
            "Photo", "Logo", "LogoBytes", "Password", "NewPassword", "CurrentPassword",
            "SpecialtyIds", "SpecialtyNames", "Schedules", "Payments", "CashMovements",
            "HasClinicalEvolution"
            };

            foreach (var colName in columnsToHide)
            {
                if (dgv.Columns.Contains(colName))
                    dgv.Columns[colName].Visible = false;
            }

            foreach (var item in _translations)
            {
                if (dgv.Columns.Contains(item.Key))
                    dgv.Columns[item.Key].HeaderText = item.Value;
            }

            string[] moneyCols = {
            "Amount", "CopayAmount", "PaymentReceived", "PaymentChange",
            "InitialCash", "RealCash", "ExpectedCash", "Difference",
            "TotalCashIncome", "TotalDebitIncome", "TotalCreditIncome",
            "TotalTransferIncome", "TotalQrIncome", "TotalManualCashIn",
            "TotalManualCashOut", "CurrentSystemCash", "TotalTurnover"
            };

            foreach (var col in moneyCols)
            {
                if (dgv.Columns.Contains(col))
                    dgv.Columns[col].DefaultCellStyle.Format = "C2";
            }

            string[] dateCols = { "BirthDate", "AppointmentDate", "Date", "CreatedAt", "DeletedAt", "OpeningDate", "ClosingDate" };
            
            foreach (var col in dateCols)
            {
                if (dgv.Columns.Contains(col))
                {
                    dgv.Columns[col].DefaultCellStyle.Format = col == "BirthDate" || col == "AppointmentDate" ? "dd/MM/yyyy" : "dd/MM/yyyy HH:mm";
                    dgv.Columns[col].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
        }

        public static void AttachManagedSelection(Form form, DataGridView dgv, Action onSync, Action onClear)
        {
            if (dgv.Tag is SelectionState oldState)
            {
                dgv.CellClick -= oldState.OnCellClick;
                dgv.MouseDown -= oldState.OnDgvMouseDown;

                foreach (var (control, handler) in oldState.ExternalHandlers)
                    control.Click -= handler;
            }

            var state = new SelectionState();

            void SafeClear()
            {
                if (state.SelectedRowIndex != -1)
                {
                    state.SelectedRowIndex = -1;
                    dgv.ClearSelection();
                    onClear();
                }
            }

            void OnCellClick(object? sender, DataGridViewCellEventArgs e)
            {
                if (e.RowIndex < 0 || dgv.CurrentRow == null)
                    return;

                if (state.SelectedRowIndex == e.RowIndex)
                    SafeClear();
                else
                {
                    state.SelectedRowIndex = e.RowIndex;
                    onSync();
                }
            }

            void OnDgvMouseDown(object? sender, MouseEventArgs e)
            {
                var hit = dgv.HitTest(e.X, e.Y);
                
                if (hit.Type == DataGridViewHitTestType.None) 
                    SafeClear();
            }

            void OnExternalClick(object? sender, EventArgs e) => SafeClear();

            state.OnCellClick = OnCellClick;
            state.OnDgvMouseDown = OnDgvMouseDown;

            dgv.CellClick += OnCellClick;
            dgv.MouseDown += OnDgvMouseDown;
            
            AttachExternalClick(form, OnExternalClick, state);
            
            dgv.Tag = state;
        }

        private static void AttachExternalClick(Control container, EventHandler handler, SelectionState state)
        {
            if (container is Form or Panel or GroupBox or Label)
            {
                container.Click += handler;
                state.ExternalHandlers.Add((container, handler));
            }

            if (container.HasChildren && container is not DataGridView)
            {
                foreach (Control child in container.Controls)
                {
                    if (child is not DataGridView and not TextBox and not ComboBox
                        and not NumericUpDown and not Button and not PictureBox
                        and not DateTimePicker and not CheckBox and not RadioButton)
                    {
                        AttachExternalClick(child, handler, state);
                    }
                }
            }
        }

        private sealed class SelectionState
        {
            public int SelectedRowIndex { get; set; } = -1;
            public DataGridViewCellEventHandler? OnCellClick { get; set; }
            public MouseEventHandler? OnDgvMouseDown { get; set; }
            public List<(Control Control, EventHandler Handler)> ExternalHandlers { get; } = new();
        }

        public static bool ConfirmMessage(string message, string title = "Confirmación")
            => MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;

        public static void InfoMessage(IWin32Window? owner, string message, string title = "Información")
            => MessageBox.Show(owner, message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);

        public static void WarnMessage(IWin32Window? owner, string message, string title = "Aviso")
            => MessageBox.Show(owner, message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);

        public static void ErrorMessage(IWin32Window? owner, string message, string title = "Error")
            => MessageBox.Show(owner, message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
