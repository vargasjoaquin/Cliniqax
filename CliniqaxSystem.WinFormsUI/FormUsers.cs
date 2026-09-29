using CliniqaxSystem.Application.DTOs.Professional;
using CliniqaxSystem.Application.DTOs.User;
using CliniqaxSystem.Application.Interfaces.Services;
using CliniqaxSystem.Domain.Constants;
using CliniqaxSystem.WinFormsUI.Helpers;

namespace CliniqaxSystem.WinFormsUI
{
    public partial class FormUsers : Form
    {
        private readonly IUserService _userService;
        private readonly IProfessionalService _professionalService;

        private int _selectedUserId = 0;
        private byte[]? _userPhotoBuffer = null;
        private bool _isPasswordVisible = false;

        public FormUsers(
            IUserService userService,
            IProfessionalService professionalService)
        {
            _userService = userService;
            _professionalService = professionalService;

            InitializeComponent();
            UIThemeHelper.ApplyFormStyle(this);
            UIThemeHelper.ApplyCardStyle(panelUserForm);

            // Vinculación de iconos overlay
            ButtonIconOverlayHelper.BindEvents(this.buttonSave, this.picIconSave);
            ButtonIconOverlayHelper.BindEvents(this.buttonEdit, this.picIconEdit);
            ButtonIconOverlayHelper.BindEvents(this.buttonToggleStatus, this.picIconToggleStatus);
            ButtonIconOverlayHelper.BindEvents(this.buttonDelete, this.picIconDelete);
            ButtonIconOverlayHelper.BindEvents(this.buttonCancel, this.picIconCancel);

            this.dataGridViewUsers.CellFormatting += (s, e) => DataGridViewHelper.ColorRowsByStatus(dataGridViewUsers, e);

            // Eventos
            this.Load += async (s, e) => await InitializeFormAsync();
            this.buttonSave.Click += async (s, e) => await ExecuteSaveUserAsync();
            this.buttonEdit.Click += async (s, e) => await ExecuteUpdateUserAsync();
            this.buttonToggleStatus.Click += async (s, e) => await ExecuteToggleStatusAsync();
            this.buttonDelete.Click += async (s, e) => await ExecuteDeleteUserAsync();
            this.buttonCancel.Click += (s, e) => ResetInputFields();
            this.buttonBrowsePhoto.Click += (s, e) => HandlePhotoSelection();
            this.buttonClearPhoto.Click += (s, e) => HandlePhotoRemoval();
            this.buttonTogglePasswordVisibility.Click += (s, e) => TogglePasswordVisibility();
            this.comboBoxRole.SelectedIndexChanged += (s, e) => OnRoleSelectionChanged();
        }

        private async Task InitializeFormAsync()
        {
            using (new WaitCursorHelper(this))
            {
                // 1. Cargar Roles
                var roles = (await _userService.GetRolesAsync()).ToList();
                comboBoxRole.DataSource = roles;
                comboBoxRole.DisplayMember = "Name";
                comboBoxRole.ValueMember = "Id";

                // 2. Cargar Médicos para enlace opcional
                var professionals = (await _professionalService.GetAllAsync()).ToList();
                professionals.Insert(0, new ProfessionalDto { Id = 0, FirstName = "[ Ninguno /", LastName = "No es Médico ]" });
                comboBoxProfessional.DataSource = professionals;
                comboBoxProfessional.DisplayMember = "FullName";
                comboBoxProfessional.ValueMember = "Id";

                await RefreshGridAsync();
                UIHelper.AttachManagedSelection(this, dataGridViewUsers, SynchronizeSelectedUserToFields, ResetInputFields);
            }
        }

        private async Task RefreshGridAsync()
        {
            var users = await _userService.GetUserListAsync();
            dataGridViewUsers.DataSource = null;
            dataGridViewUsers.DataSource = users.ToList();
            UIHelper.FormatGrid(dataGridViewUsers);
        }

        private void OnRoleSelectionChanged()
        {
            // Si el rol es "Profesional", habilitamos el combo para vincularlo a su ficha médica
            bool isDoctorRole = comboBoxRole.SelectedValue is int roleId && roleId == RoleConstants.PROFESSIONAL_ROLE_ID;
            comboBoxProfessional.Enabled = isDoctorRole;
            if (!isDoctorRole) comboBoxProfessional.SelectedValue = 0;
        }

        private void SynchronizeSelectedUserToFields()
        {
            if (dataGridViewUsers.CurrentRow == null)
                return;

            var user = (UserDto)dataGridViewUsers.CurrentRow.DataBoundItem;

            _selectedUserId = user.Id;
            textBoxUsername.Text = user.Username;
            textBoxFirstName.Text = user.FirstName;
            textBoxLastName.Text = user.LastName;
            textBoxEmail.Text = user.Email ?? string.Empty;
            comboBoxRole.SelectedValue = user.RoleId;
            comboBoxProfessional.SelectedValue = user.ProfessionalId ?? 0;
            textBoxPassword.Clear();

            _userPhotoBuffer = user.Photo;
            ImageHelper.Clear(pictureBoxUserPhoto);
            pictureBoxUserPhoto.Image = ImageHelper.LoadFromBytes(user.Photo);

            // INMUTABILIDAD DEL USUARIO
            textBoxUsername.ReadOnly = true;
            textBoxUsername.BackColor = Color.FromArgb(241, 245, 249);

            bool isSuperAdmin = user.Username.Equals(RoleConstants.DEFAULT_ADMIN_USERNAME, StringComparison.OrdinalIgnoreCase);
            comboBoxRole.Enabled = !isSuperAdmin;
            buttonDelete.Enabled = !isSuperAdmin;
            buttonToggleStatus.Enabled = !isSuperAdmin;

            UpdateButtonStates(isEditing: true);
        }

        private void ResetInputFields()
        {
            _selectedUserId = 0;
            _userPhotoBuffer = null;
            ImageHelper.Clear(pictureBoxUserPhoto);

            UIHelper.CleanControls(panelUserForm);

            textBoxUsername.ReadOnly = false;
            textBoxUsername.BackColor = Color.White;
            comboBoxRole.SelectedIndex = -1;
            comboBoxProfessional.SelectedValue = 0;
            comboBoxRole.Enabled = true;

            _isPasswordVisible = false;
            textBoxPassword.PasswordChar = '●';

            UpdateButtonStates(isEditing: false);
            textBoxUsername.Focus();
        }

        private void UpdateButtonStates(bool isEditing)
        {
            buttonSave.Enabled = !isEditing;
            buttonEdit.Enabled = isEditing;
        }

        private void TogglePasswordVisibility()
        {
            _isPasswordVisible = !_isPasswordVisible;
            textBoxPassword.PasswordChar = _isPasswordVisible ? '\0' : '●';
            buttonTogglePasswordVisibility.Text = _isPasswordVisible ? "🙈" : "👁";
            textBoxPassword.Focus();
        }

        private void HandlePhotoSelection()
        {
            if (ImageHelper.SelectImage(out byte[]? bytes, out Image? img, out string? err))
            {
                ImageHelper.Clear(pictureBoxUserPhoto);
                _userPhotoBuffer = bytes;
                pictureBoxUserPhoto.Image = img;
            }
            else if (!string.IsNullOrEmpty(err))
            {
                UIHelper.WarnMessage(this, err, "Fotografía");
            }
        }

        private void HandlePhotoRemoval()
        {
            _userPhotoBuffer = null;
            ImageHelper.Clear(pictureBoxUserPhoto);
        }

        private async Task ExecuteSaveUserAsync()
        {
            var dto = new UserCreateDto
            {
                Username = textBoxUsername.Text.Trim(),
                FirstName = textBoxFirstName.Text.Trim(),
                LastName = textBoxLastName.Text.Trim(),
                Email = textBoxEmail.Text.Trim(),
                Password = textBoxPassword.Text,
                RoleId = (int)(comboBoxRole.SelectedValue ?? RoleConstants.RECEPTIONIST_ROLE_ID),
                ProfessionalId = comboBoxProfessional.SelectedValue is int pId && pId > 0 ? pId : null,
                Photo = _userPhotoBuffer,
                IsActive = true
            };

            using (new WaitCursorHelper(this))
            {
                var result = await _userService.CreateUserAsync(dto);
                UIHelper.ShowResult(result, "Gestión de Usuarios", async () =>
                {
                    await RefreshGridAsync();
                    ResetInputFields();
                });
            }
        }

        private async Task ExecuteUpdateUserAsync()
        {
            if (_selectedUserId == 0) return;

            var dto = new UserDto
            {
                Id = _selectedUserId,
                Username = textBoxUsername.Text.Trim(),
                FirstName = textBoxFirstName.Text.Trim(),
                LastName = textBoxLastName.Text.Trim(),
                Email = textBoxEmail.Text.Trim(),
                RoleId = (int)(comboBoxRole.SelectedValue ?? RoleConstants.RECEPTIONIST_ROLE_ID),
                ProfessionalId = comboBoxProfessional.SelectedValue is int pId && pId > 0 ? pId : null,
                Photo = _userPhotoBuffer,
                IsActive = true
            };

            using (new WaitCursorHelper(this))
            {
                var result = await _userService.UpdateUserAsync(dto);
                UIHelper.ShowResult(result, "Gestión de Usuarios", async () =>
                {
                    await RefreshGridAsync();
                    ResetInputFields();
                });
            }
        }

        private async Task ExecuteToggleStatusAsync()
        {
            if (_selectedUserId == 0) return;

            using (new WaitCursorHelper(this))
            {
                var result = await _userService.ToggleUserStatusAsync(_selectedUserId);
                UIHelper.ShowResult(result, "Estado de Usuario", async () =>
                {
                    await RefreshGridAsync();
                    ResetInputFields();
                });
            }
        }

        private async Task ExecuteDeleteUserAsync()
        {
            if (_selectedUserId == 0) return;

            if (UIHelper.ConfirmMessage("¿Dar de baja a este usuario del sistema?", "Confirmar Baja"))
            {
                using (new WaitCursorHelper(this))
                {
                    var result = await _userService.DeleteUserAsync(_selectedUserId);
                    UIHelper.ShowResult(result, "Baja de Usuario", async () =>
                    {
                        await RefreshGridAsync();
                        ResetInputFields();
                    });
                }
            }
        }
    }
}
