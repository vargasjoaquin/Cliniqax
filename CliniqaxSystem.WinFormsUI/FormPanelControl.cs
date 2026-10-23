using CliniqaxSystem.Application.Interfaces.Services;
using CliniqaxSystem.Domain.Constants;
using CliniqaxSystem.WinFormsUI.Helpers;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Drawing.Drawing2D;

namespace CliniqaxSystem.WinFormsUI
{
    public partial class FormPanelControl : Form
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IServiceProvider _serviceProvider;
        private readonly IBackupService _backupService;

        private FormHome? _dashboardForm;
        private System.Windows.Forms.Timer? _reminderTimer;
        private bool _isShuttingDown = false;

        public FormPanelControl(ICurrentUserService currentUserService, IServiceProvider serviceProvider, IBackupService backupService)
        {
            _currentUserService = currentUserService;
            _serviceProvider = serviceProvider;
            _backupService = backupService;

            InitializeComponent();
            UIThemeHelper.ApplyFormStyle(this);

            ButtonIconOverlayHelper.BindEvents(this.buttonLogout, this.picIconLogout);

            labelClockTime.Text = DateTime.Now.ToString("HH:mm:ss");
            timerClock.Interval = 1000;
            timerClock.Tick += (s, e) => labelClockTime.Text = DateTime.Now.ToString("HH:mm:ss");
            timerClock.Start();

            InitializeBackgroundRemindersTimer();

            this.buttonLogout.Click += (s, e) => this.Close();
            this.FormClosing += OnFormClosingConfirmation;

            this.Load += async (s, e) =>
            {
                InitializeNavigationAndSession();
                await LoadEmbeddedDashboardAsync();
            };
        }

        private void InitializeBackgroundRemindersTimer()
        {
            _reminderTimer = new System.Windows.Forms.Timer();
            _reminderTimer.Interval = 15 * 60 * 1000; // Evalúa cada 15 minutos
            _reminderTimer.Tick += async (s, e) =>
            {
                try
                {
                    var reminderService = _serviceProvider.GetRequiredService<IAppointmentReminderService>();
                    await reminderService.CheckAndGenerateAppointmentRemindersAsync();
                }
                catch
                {
                    // Manejo silencioso en segundo plano para no interrumpir el flujo de UI del operador
                }
            };
            _reminderTimer.Start();
        }

        private void InitializeNavigationAndSession()
        {
            labelSessionUser.Text = _currentUserService.FullName?.ToUpper();
            labelRoleName.Text = $"[{_currentUserService.RoleName?.ToUpper()}]";

            bool isAdministrator = _currentUserService.RoleName?.Equals(RoleConstants.ADMINISTRATOR, StringComparison.OrdinalIgnoreCase) ?? true;
            bool isDoctor = _currentUserService.RoleName?.Equals(RoleConstants.PROFESSIONAL, StringComparison.OrdinalIgnoreCase) ?? false;
            bool canAccessClinical = isAdministrator || isDoctor;

            BuildNavigationRibbon(isAdministrator, canAccessClinical);
        }

        private void BuildNavigationRibbon(bool isAdministrator, bool canAccessClinical)
        {
            flowLayoutPanelMenu.SuspendLayout();
            flowLayoutPanelMenu.Controls.Clear();

            string currentRole = _currentUserService.RoleName ?? string.Empty;
            bool isDoctor = currentRole.Equals(RoleConstants.PROFESSIONAL, StringComparison.OrdinalIgnoreCase);
            bool isReceptionist = currentRole.Equals(RoleConstants.RECEPTIONIST, StringComparison.OrdinalIgnoreCase);

            var menuItems = new List<NavMenuItemHelper>();

            menuItems.Add(NavMenuItemHelper.DirectAction("Inicio", "Dashboard", Icons.nav_dashboard, async () =>
            {
                if (_dashboardForm != null)
                {
                    _dashboardForm.BringToFront();
                    await _dashboardForm.RefreshDashboardMetricsAndTablesAsync();
                }
            }));

            menuItems.Add(NavMenuItemHelper.Group("Agenda ▾", "Turnos y Calendario", Icons.nav_agenda_medica, new List<NavMenuItemHelper>
            {
                NavMenuItemHelper.Direct("Agenda Médica", "Grilla Visual de Turnos", Icons.nav_agenda_medica, typeof(FormAgenda)),
                NavMenuItemHelper.Direct("Gestión de Turnos", "Listado y Búsqueda de Citas", Icons.nav_gestion_turnos, typeof(FormAppointments))
            }));

            menuItems.Add(NavMenuItemHelper.Direct("Pacientes", "Padrón de Pacientes", Icons.nav_pacientes, typeof(FormPatients)));

            if (isAdministrator || isDoctor)
            {
                menuItems.Add(NavMenuItemHelper.Direct("Historia Clínica", "Expedientes y Atenciones", Icons.status_atendido, typeof(FormMedicalRecord)));
            }

            if (isAdministrator)
            {
                menuItems.Add(NavMenuItemHelper.Direct("Profesionales", "Médicos y Matrículas", Icons.nav_profesionales, typeof(FormProfessionals)));
            }

            if (isAdministrator || isReceptionist)
            {
                menuItems.Add(NavMenuItemHelper.Direct("Caja Diaria", "Sesión Diaria y Cobros", Icons.nav_caja_finanzas, typeof(FormCashSession)));
            }

            if (isAdministrator)
            {
                menuItems.Add(NavMenuItemHelper.Group("Catálogos ▾", "Maestros del Sistema", Icons.nav_especialidades, new List<NavMenuItemHelper>
                {
                    NavMenuItemHelper.Direct("Especialidades", "Ramas Médicas", Icons.nav_especialidades, typeof(FormSpecialties)),
                    NavMenuItemHelper.Direct("Obras Sociales", "Prepagas y Mutuales", Icons.nav_obras_sociales, typeof(FormHealthInsurances))
                }));
            }

            var reportSubItems = new List<NavMenuItemHelper>
            {
                NavMenuItemHelper.Direct("Reporte de Turnos", "Estadísticas de Citas", Icons.nav_gestion_turnos, typeof(FormAppointmentsReport))
            };

            if (isAdministrator)
            {
                reportSubItems.Add(NavMenuItemHelper.Direct("Reporte de Ingresos", "Recaudación de Consultas", Icons.nav_caja_finanzas, typeof(FormIncomeReport)));
            }

            menuItems.Add(NavMenuItemHelper.Group("Reportes ▾", "Informes Administrativos", Icons.nav_reportes_estadisticas, reportSubItems));

            var settingsSubItems = new List<NavMenuItemHelper>();

            if (isAdministrator)
            {
                settingsSubItems.Add(NavMenuItemHelper.Direct("Centro de Configuración", "Parámetros y Automatización", Icons.nav_configuracion_consultorio, typeof(FormConfigurationHub)));
                settingsSubItems.Add(NavMenuItemHelper.Direct("Monitor de Notificaciones", "Control WhatsApp y Email", Icons.status_atendido, typeof(FormNotificationMonitor)));
                settingsSubItems.Add(NavMenuItemHelper.Direct("Visor de Auditoría", "Trazabilidad de Operaciones", Icons.action_buscar_filtrar, typeof(FormAuditViewer)));
                settingsSubItems.Add(NavMenuItemHelper.Direct("Usuarios del Sistema", "Cuentas de Acceso", Icons.nav_usuarios_sistema, typeof(FormUsers)));
                settingsSubItems.Add(NavMenuItemHelper.Direct("Papelera y Auditoría", "Restaurar Registros", Icons.nav_papelera_restauracion, typeof(FormRestoreRecords)));
                settingsSubItems.Add(NavMenuItemHelper.Direct("Datos del Consultorio", "Ajustes Institucionales", Icons.nav_configuracion_consultorio, typeof(FormSettings)));
            }

            settingsSubItems.Add(NavMenuItemHelper.Direct("Mi Perfil", "Mis Datos y Clave", Icons.nav_mi_perfil, typeof(FormUserProfile)));

            menuItems.Add(NavMenuItemHelper.Group("Ajustes ▾", "Configuración y Seguridad", Icons.nav_configuracion_consultorio, settingsSubItems));

            foreach (var item in menuItems)
            {
                var ribbonButton = CreateRibbonButton(item.Title, item.Icon ?? Icons.nav_dashboard);

                if (item.HasSubItems)
                {
                    var dropdownMenu = CreateDropdownMenu(item.SubItems, isAdministrator);
                    ribbonButton.Click += (s, e) => dropdownMenu.Show(ribbonButton, 0, ribbonButton.Height);
                }
                else if (item.TargetFormType != null)
                {
                    ribbonButton.Click += (s, e) => OpenOrFocusChildFormByType(item.TargetFormType);
                }
                else if (item.CustomAction != null)
                {
                    ribbonButton.Click += (s, e) => item.CustomAction();
                }

                flowLayoutPanelMenu.Controls.Add(ribbonButton);
            }

            flowLayoutPanelMenu.ResumeLayout(true);
        }

        private static Button CreateRibbonButton(string title, Image icon)
        {
            var btn = new Button
            {
                Size = new Size(128, 76),
                Image = ResizeIcon(icon, 32, 32),
                ImageAlign = ContentAlignment.TopCenter,
                Text = title,
                TextAlign = ContentAlignment.BottomCenter,
                Font = UIThemeHelper.FontBodyBold,
                ForeColor = UIThemeHelper.TextMain,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
                Cursor = Cursors.Hand,
                Padding = new Padding(0, 6, 0, 6),
                Margin = new Padding(3, 2, 3, 2)
            };

            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(215, 225, 235);
            return btn;
        }

        private ContextMenuStrip CreateDropdownMenu(List<NavMenuItemHelper> items, bool isAdministrator)
        {
            var menu = new ContextMenuStrip
            {
                Renderer = new MenuRendererHelper(),
                Font = UIThemeHelper.FontBody,
                ShowImageMargin = true,
                ImageScalingSize = new Size(20, 20)
            };

            foreach (var item in items)
            {
                if (item.RequireAdmin && !isAdministrator)
                    continue;

                var menuItem = new ToolStripMenuItem(item.Title)
                {
                    Image = item.Icon != null ? ResizeIcon(item.Icon, 20, 20) : null,
                    Padding = new Padding(4, 6, 4, 6)
                };

                if (item.TargetFormType != null)
                    menuItem.Click += (s, e) => OpenOrFocusChildFormByType(item.TargetFormType);
                else if (item.CustomAction != null)
                    menuItem.Click += (s, e) => item.CustomAction();

                menu.Items.Add(menuItem);
            }

            return menu;
        }

        public void OpenOrFocusChildForm<T>() where T : Form
        {
            OpenOrFocusChildFormByType(typeof(T));
        }

        private void OpenOrFocusChildFormByType(Type formType)
        {
            Form? openForm = System.Windows.Forms.Application.OpenForms.Cast<Form>().FirstOrDefault(f => f.GetType() == formType);

            if (openForm != null)
            {
                openForm.WindowState = FormWindowState.Normal;
                openForm.BringToFront();
                openForm.Focus();

                return;
            }

            var newForm = (Form)_serviceProvider.GetRequiredService(formType);
            newForm.Show();
        }

        private static Image ResizeIcon(Image original, int width, int height)
        {
            var bmp = new Bitmap(width, height);
            using var g = Graphics.FromImage(bmp);

            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.DrawImage(original, 0, 0, width, height);

            return bmp;
        }

        private async Task LoadEmbeddedDashboardAsync()
        {
            _dashboardForm = _serviceProvider.GetRequiredService<FormHome>();
            _dashboardForm.TopLevel = false;
            _dashboardForm.FormBorderStyle = FormBorderStyle.None;
            _dashboardForm.Dock = DockStyle.Fill;

            panelMainContainer.Controls.Clear();
            panelMainContainer.Controls.Add(_dashboardForm);
            _dashboardForm.Show();

            await _dashboardForm.RefreshDashboardMetricsAndTablesAsync();
        }

        private async void OnFormClosingConfirmation(object? sender, FormClosingEventArgs e)
        {
            if (_isShuttingDown)
                return;

            bool confirm = UIHelper.ConfirmMessage("¿Está seguro de que desea cerrar la sesión y salir del sistema?", "Cerrar Sesión");

            if (!confirm)
            {
                e.Cancel = true;
                return;
            }

            e.Cancel = true;
            _isShuttingDown = true;
            this.Enabled = false;

            _reminderTimer?.Stop();
            _reminderTimer?.Dispose();

            try
            {
                using (new WaitCursorHelper(this))
                {
                    await _backupService.ExecuteAutomaticBackupAsync();
                }
            }
            catch
            {
            }
            finally
            {
                System.Windows.Forms.Application.Exit();
            }
        }
    }
}