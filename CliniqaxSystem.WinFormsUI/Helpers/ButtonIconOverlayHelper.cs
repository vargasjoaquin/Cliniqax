namespace CliniqaxSystem.WinFormsUI.Helpers
{
    public static class ButtonIconOverlayHelper
    {
        public static void BindEvents(Button button, PictureBox icon)
        {
            if (button == null || icon == null)
                return;

            if (icon.Parent != button)
            {
                Control? currentParent = icon.Parent;
                if (currentParent != null)
                {
                    Point screenPos = currentParent.PointToScreen(icon.Location);
                    Point buttonRelPos = button.PointToClient(screenPos);

                    icon.Parent = button;
                    icon.Location = buttonRelPos;
                }
                else
                {
                    icon.Location = new Point(icon.Left - button.Left, icon.Top - button.Top);
                    icon.Parent = button;
                }
            }

            icon.BackColor = Color.Transparent;
            icon.Enabled = false;
            icon.BringToFront();

            Color originalBackColor = button.BackColor;
            Color originalForeColor = button.ForeColor;

            void UpdateVisualState()
            {
                icon.Visible = button.Visible;

                if (button.Enabled)
                {
                    button.BackColor = originalBackColor;
                    button.ForeColor = originalForeColor;
                    button.Cursor = Cursors.Hand;
                }
                else
                {
                    button.BackColor = Color.FromArgb(226, 232, 240);
                    button.ForeColor = Color.FromArgb(148, 163, 184);
                    button.Cursor = Cursors.Default;
                }
            }

            button.EnabledChanged += (s, e) => UpdateVisualState();
            button.VisibleChanged += (s, e) => icon.Visible = button.Visible;

            UpdateVisualState();
        }
    }
}
