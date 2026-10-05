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

            this.buttonLogout.Click += (s, e) => this.Close();
            this.FormClosing += OnFormClosingConfirmation;
            this.Load += (s, e) => InitializeNavigationAndSession();

            this.Load += async (s, e) =>
            {
                InitializeNavigationAndSession();
                await LoadEmbeddedDashboardAsync();
            };
        }

        private void InitializeNavigationAndSession()
        {
            labelSessionUser.Text = _currentUserService.FullName?.ToUpper();
            labelRoleName.Text = $"[{_currentUserService.RoleName?.ToUpper()}]";

            bool isAdministrator = _currentUserService.RoleName?.Equals(RoleConstants.ADMINISTRATOR, StringComparison.OrdinalIgnoreCase) ?? true;

            BuildNavigationRibbon(isAdministrator);
        }

        private void BuildNavigationRibbon(bool isAdministrator)
        {
            flowLayoutPanelMenu.SuspendLayout();
            flowLayoutPanelMenu.Controls.Clear();

            var menuItems = new List<NavMenuItemHelper>
            {
                NavMenuItemHelper.DirectAction("Inicio", "Dashboard", Icons.nav_dashboard, async () =>
                {
                    if (_dashboardForm != null)
                    {
                        _dashboardForm.BringToFront();
                        await _dashboardForm.RefreshDashboardMetricsAndTablesAsync();
                    }
                }),

                NavMenuItemHelper.Group("Agenda ▾", "Turnos y Calendario", Icons.nav_agenda_medica, new List<NavMenuItemHelper>
                {
                    NavMenuItemHelper.Direct("Agenda Médica", "Grilla Visual de Turnos", Icons.nav_agenda_medica, typeof(FormAgenda)),
                    NavMenuItemHelper.Direct("Gestión de Turnos", "Listado y Búsqueda de Citas", Icons.nav_gestion_turnos, typeof(FormAppointments))
                }),

                NavMenuItemHelper.Direct("Pacientes", "Padrón de Pacientes", Icons.nav_pacientes, typeof(FormPatients)),

                NavMenuItemHelper.Direct("Profesionales", "Médicos y Matrículas", Icons.nav_profesionales, typeof(FormProfessionals), requireAdmin: true),

                NavMenuItemHelper.Direct("Caja Diaria", "Sesión Diaria y Cobros", Icons.nav_caja_finanzas, typeof(FormCashSession)),

                NavMenuItemHelper.Group("Catálogos ▾", "Maestros del Sistema", Icons.nav_especialidades, new List<NavMenuItemHelper>
                {
                    NavMenuItemHelper.Direct("Especialidades", "Ramas Médicas", Icons.nav_especialidades, typeof(FormSpecialties), requireAdmin: true),
                    NavMenuItemHelper.Direct("Obras Sociales", "Prepagas y Mutuales", Icons.nav_obras_sociales, typeof(FormHealthInsurances), requireAdmin: true)
                }),

                NavMenuItemHelper.Group("Reportes ▾", "Informes Administrativos", Icons.nav_reportes_estadisticas, new List<NavMenuItemHelper>
                {
                    NavMenuItemHelper.Direct("Reporte de Turnos", "Estadísticas de Citas", Icons.nav_gestion_turnos, typeof(FormAppointmentsReport)),
                    NavMenuItemHelper.Direct("Reporte de Ingresos", "Recaudación de Consultas", Icons.nav_caja_finanzas, typeof(FormIncomeReport), requireAdmin: true)
                }),

                NavMenuItemHelper.Group("Ajustes ▾", "Configuración y Seguridad", Icons.nav_configuracion_consultorio, new List<NavMenuItemHelper>
                {
                    NavMenuItemHelper.Direct("Usuarios del Sistema", "Cuentas de Acceso", Icons.nav_usuarios_sistema, typeof(FormUsers), requireAdmin: true),
                    NavMenuItemHelper.Direct("Papelera y Auditoría", "Restaurar Registros", Icons.nav_papelera_restauracion, typeof(FormRestoreRecords), requireAdmin: true),
                    NavMenuItemHelper.Direct("Datos del Consultorio", "Ajustes Institucionales", Icons.nav_configuracion_consultorio, typeof(FormSettings), requireAdmin: true),
                    NavMenuItemHelper.Direct("Mi Perfil", "Mis Datos y Clave", Icons.nav_mi_perfil, typeof(FormUserProfile))
                })
            };

            foreach (var item in menuItems)
            {
                if (item.RequireAdmin && !isAdministrator)
                    continue;

                var subItemsAuth = item.SubItems.Where(s => !s.RequireAdmin || isAdministrator).ToList();
                
                if (item.HasSubItems && !subItemsAuth.Any())
                    continue;

                var ribbonButton = CreateRibbonButton(item.Title, item.Icon ?? Icons.nav_dashboard);

                if (item.HasSubItems)
                {
                    var dropdownMenu = CreateDropdownMenu(subItemsAuth, isAdministrator);
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
                Size = new Size(125, 76),
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
