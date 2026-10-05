namespace CliniqaxSystem.WinFormsUI.Helpers
{
    public static class DataGridViewHelper
    {
        public static void ApplyStyle(DataGridView dgv)
        {
            UIHelper.FormatGrid(dgv);
        }

        public static void ColorRowsByStatus(DataGridView dgv, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgv.Rows.Count)
                return;

            var item = dgv.Rows[e.RowIndex].DataBoundItem;
            
            if (item == null)
                return;

            // 1. Resaltado por Estado Activo/Inactivo
            var propActive = item.GetType().GetProperty("IsActive");
            
            if (propActive != null && propActive.GetValue(item) is bool isActive && !isActive)
            {
                e.CellStyle.ForeColor = UIThemeHelper.Danger;
                e.CellStyle.SelectionForeColor = UIThemeHelper.Danger;
            }

            // 2. Resaltado por Estado del Turno
            var propStatus = item.GetType().GetProperty("StatusName");
            
            if (propStatus != null && propStatus.GetValue(item) is string statusName)
            {
                if (statusName == "Cancelado" || statusName == "Ausente")
                {
                    e.CellStyle.ForeColor = UIThemeHelper.Danger;
                }
                else if (statusName == "Atendido")
                {
                    e.CellStyle.ForeColor = UIThemeHelper.Success;
                }
                else if (statusName == "En Espera")
                {
                    e.CellStyle.ForeColor = UIThemeHelper.Primary;
                }
            }
        }
    }
}
