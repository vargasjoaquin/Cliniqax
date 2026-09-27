namespace CliniqaxSystem.WinFormsUI.Helpers
{
    public class NavMenuItemHelper
    {
        public string Title { get; set; } = null!;
        public string? Tooltip { get; set; }
        public Image? Icon { get; set; }
        public Type? TargetFormType { get; set; }
        public Action? CustomAction { get; set; }
        public bool RequireAdmin { get; set; } = false;
        public List<NavMenuItemHelper> SubItems { get; set; } = new();

        public bool HasSubItems => SubItems.Any();

        public static NavMenuItemHelper Direct(string title, string tooltip, Image? icon, Type formType, bool requireAdmin = false)
        {
            return new NavMenuItemHelper
            {
                Title = title,
                Tooltip = tooltip,
                Icon = icon,
                TargetFormType = formType,
                RequireAdmin = requireAdmin
            };
        }

        public static NavMenuItemHelper DirectAction(string title, string tooltip, Image? icon, Action action, bool requireAdmin = false)
        {
            return new NavMenuItemHelper
            {
                Title = title,
                Tooltip = tooltip,
                Icon = icon,
                CustomAction = action,
                RequireAdmin = requireAdmin
            };
        }

        public static NavMenuItemHelper Group(string title, string tooltip, Image? icon, List<NavMenuItemHelper> subItems, bool requireAdmin = false)
        {
            return new NavMenuItemHelper
            {
                Title = title,
                Tooltip = tooltip,
                Icon = icon,
                SubItems = subItems,
                RequireAdmin = requireAdmin
            };
        }
    }
}
