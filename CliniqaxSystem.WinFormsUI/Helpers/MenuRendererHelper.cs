namespace CliniqaxSystem.WinFormsUI.Helpers
{
    public class MenuRendererHelper : ToolStripProfessionalRenderer
    {
        public MenuRendererHelper() : base(new ModernColorTable()) { }

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            if (e.Item.Selected || e.Item.Pressed)
            {
                var rect = new Rectangle(2, 1, e.Item.Width - 4, e.Item.Height - 2);
                using var brush = new SolidBrush(Color.FromArgb(2, 132, 199)); // Azul Cliniqax
                e.Graphics.FillRectangle(brush, rect);
            }
            else
            {
                base.OnRenderMenuItemBackground(e);
            }
        }

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            e.TextColor = (e.Item.Selected || e.Item.Pressed) ? Color.White : Color.FromArgb(15, 23, 42);
            base.OnRenderItemText(e);
        }

        private class ModernColorTable : ProfessionalColorTable
        {
            public override Color MenuItemSelected => Color.FromArgb(2, 132, 199);
            public override Color MenuItemSelectedGradientBegin => Color.FromArgb(2, 132, 199);
            public override Color MenuItemSelectedGradientEnd => Color.FromArgb(2, 132, 199);
            public override Color MenuBorder => Color.FromArgb(226, 232, 240);
            public override Color ToolStripDropDownBackground => Color.White;
            public override Color ImageMarginGradientBegin => Color.White;
            public override Color ImageMarginGradientMiddle => Color.White;
            public override Color ImageMarginGradientEnd => Color.White;
        }
    }
}
