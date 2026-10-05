namespace CliniqaxSystem.WinFormsUI.Helpers
{
    public static class UIThemeHelper
    {
        // ==========================================
        // 1. PALETA DE COLORES (Slate / Medical Theme)
        // ==========================================
        public static readonly Color Primary = Color.FromArgb(2, 132, 199);        // Azul Médico
        public static readonly Color PrimaryDark = Color.FromArgb(3, 105, 161);
        public static readonly Color PrimaryLight = Color.FromArgb(224, 242, 254);

        public static readonly Color SidebarBackground = Color.FromArgb(15, 23, 42); // Slate 900
        public static readonly Color SidebarHover = Color.FromArgb(30, 41, 59);
        public static readonly Color SidebarText = Color.FromArgb(226, 232, 240);

        public static readonly Color Background = Color.FromArgb(248, 250, 252);     // Slate 50
        public static readonly Color Surface = Color.White;
        public static readonly Color Border = Color.FromArgb(226, 232, 240);

        public static readonly Color Success = Color.FromArgb(16, 185, 129);       // Verde Esmeralda
        public static readonly Color SuccessLight = Color.FromArgb(209, 250, 229);
        public static readonly Color Danger = Color.FromArgb(239, 68, 68);         // Rojo Alerta
        public static readonly Color DangerLight = Color.FromArgb(254, 226, 226);
        public static readonly Color Warning = Color.FromArgb(245, 158, 11);       // Ámbar Pendiente

        public static readonly Color TextMain = Color.FromArgb(15, 23, 42);
        public static readonly Color TextMuted = Color.FromArgb(100, 116, 139);

        // ==========================================
        // 2. TIPOGRAFÍAS
        // ==========================================
        public static readonly Font FontDisplayLarge = new("Segoe UI", 22F, FontStyle.Bold);
        public static readonly Font FontDisplayMedium = new("Segoe UI", 16F, FontStyle.Bold);
        public static readonly Font FontHeader = new("Segoe UI", 12F, FontStyle.Bold);
        public static readonly Font FontSubHeader = new("Segoe UI", 10.5F, FontStyle.Bold);
        public static readonly Font FontBodyBold = new("Segoe UI", 9.5F, FontStyle.Bold);
        public static readonly Font FontBody = new("Segoe UI", 9.5F, FontStyle.Regular);
        public static readonly Font FontSmall = new("Segoe UI", 8.5F, FontStyle.Regular);
        public static readonly Font FontMonospace = new("Consolas", 10F, FontStyle.Regular);

        // ==========================================
        // 3. ATAJOS DE TECLADO CENTRALIZADOS
        // ==========================================
        public static class Shortcuts
        {
            public const Keys Search = Keys.F2;
            public const Keys NewRecord = Keys.F3;
            public const Keys Refresh = Keys.F5;
            public const Keys ProcessPayment = Keys.F8;
            public const Keys Delete = Keys.Delete;
            public const Keys Escape = Keys.Escape;
        }

        // ==========================================
        // 4. ESTILIZADO DE CONTROLES
        // ==========================================
        public static void ApplyFormStyle(Form form)
        {
            form.BackColor = Background;
            form.Font = FontBody;
        }

        public static void ApplyCardStyle(Panel panel)
        {
            panel.BackColor = Surface;
            panel.BorderStyle = BorderStyle.None;
        }

        public static void ApplyButtonPrimary(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = Primary;
            btn.ForeColor = Color.White;
            btn.Font = FontBodyBold;
            btn.Cursor = Cursors.Hand;
        }

        public static void ApplyButtonSuccess(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = Success;
            btn.ForeColor = Color.White;
            btn.Font = FontBodyBold;
            btn.Cursor = Cursors.Hand;
        }

        public static void ApplyButtonDanger(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = Danger;
            btn.ForeColor = Color.White;
            btn.Font = FontBodyBold;
            btn.Cursor = Cursors.Hand;
        }
    }
}
