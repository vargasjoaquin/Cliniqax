using CliniqaxSystem.Application.DTOs.User;
using CliniqaxSystem.Application.Interfaces.Services;
using CliniqaxSystem.WinFormsUI.Helpers;

namespace CliniqaxSystem.WinFormsUI
{
    public partial class FormUserProfile : Form
    {
        private readonly IUserService _userService;
        private readonly ICurrentUserService _currentUserService;
        private byte[]? _photoBuffer = null;

        public FormUserProfile(
            IUserService userService,
            ICurrentUserService currentUserService)
        {
            _userService = userService;
            _currentUserService = currentUserService;

            InitializeComponent();
            UIThemeHelper.ApplyFormStyle(this);
            UIThemeHelper.ApplyCardStyle(panelProfileCard);
            UIThemeHelper.ApplyCardStyle(panelEditCard);

            // Vinculación de icono en botón
            ButtonIconOverlayHelper.BindEvents(this.buttonSaveChanges, this.picIconSaveChanges);

            this.Load += async (s, e) => await LoadUserProfileAsync();
            this.buttonSaveChanges.Click += async (s, e) => await ExecuteSaveChangesAsync();
            this.buttonBrowsePhoto.Click += (s, e) => HandlePhotoSelection();
            this.buttonClearPhoto.Click += (s, e) => HandlePhotoRemoval();
        }

        private async Task LoadUserProfileAsync()
        {
            if (!_currentUserService.UserId.HasValue) return;

            using (new WaitCursorHelper(this))
            {
                var user = await _userService.GetByIdAsync(_currentUserService.UserId.Value);
                if (user == null) return;

                // Ficha visual izquierda
                labelFullNameDisplay.Text = $"{user.FirstName} {user.LastName}".Trim();
                labelRoleBadge.Text = user.RoleName.ToUpper();
                labelUsernameDisplay.Text = $"Usuario: @{user.Username}";
                labelEmailDisplay.Text = user.Email ?? "Sin correo configurado";

                _photoBuffer = user.Photo;
                ImageHelper.Clear(pictureBoxAvatar);
                pictureBoxAvatar.Image = ImageHelper.LoadFromBytes(user.Photo);

                // Campos editables derecha
                textBoxFirstName.Text = user.FirstName;
                textBoxLastName.Text = user.LastName;
                textBoxEmail.Text = user.Email ?? string.Empty;
                textBoxCurrentPassword.Clear();
                textBoxNewPassword.Clear();
                textBoxConfirmPassword.Clear();
            }
        }

        private void HandlePhotoSelection()
        {
            if (ImageHelper.SelectImage(out byte[]? bytes, out Image? img, out string? err))
            {
                ImageHelper.Clear(pictureBoxAvatar);
                _photoBuffer = bytes;
                pictureBoxAvatar.Image = img;
            }
            else if (!string.IsNullOrEmpty(err))
            {
                UIHelper.WarnMessage(this, err, "Fotografía");
            }
        }

        private void HandlePhotoRemoval()
        {
            _photoBuffer = null;
            ImageHelper.Clear(pictureBoxAvatar);
        }

        private async Task ExecuteSaveChangesAsync()
        {
            if (!_currentUserService.UserId.HasValue) return;

            if (!string.IsNullOrWhiteSpace(textBoxNewPassword.Text))
            {
                if (string.IsNullOrWhiteSpace(textBoxCurrentPassword.Text))
                {
                    UIHelper.WarnMessage(this, "Debe ingresar su contraseña actual para confirmar el cambio de clave.", "Contraseña Requerida");
                    textBoxCurrentPassword.Focus();
                    return;
                }

                if (textBoxNewPassword.Text != textBoxConfirmPassword.Text)
                {
                    UIHelper.WarnMessage(this, "La nueva contraseña y su confirmación no coinciden.", "Claves Discrepantes");
                    textBoxConfirmPassword.Focus();
                    return;
                }
            }

            var dto = new UserProfileUpdateDto
            {
                UserId = _currentUserService.UserId.Value,
                FirstName = textBoxFirstName.Text.Trim(),
                LastName = textBoxLastName.Text.Trim(),
                Email = textBoxEmail.Text.Trim(),
                CurrentPassword = textBoxCurrentPassword.Text,
                NewPassword = textBoxNewPassword.Text,
                Photo = _photoBuffer
            };

            using (new WaitCursorHelper(this))
            {
                var result = await _userService.UpdateProfileAsync(dto);
                UIHelper.ShowResult(result, "Mi Perfil", async () =>
                {
                    await LoadUserProfileAsync();
                });
            }
        }
    }
}
