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

            button.EnabledChanged += (s, e) => icon.Visible = button.Visible && button.Enabled;
            button.VisibleChanged += (s, e) => icon.Visible = button.Visible;
        }
    }
}
