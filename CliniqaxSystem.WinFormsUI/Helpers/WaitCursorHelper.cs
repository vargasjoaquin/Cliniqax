namespace CliniqaxSystem.WinFormsUI.Helpers
{
    public class WaitCursorHelper : IDisposable
    {
        private readonly Form _form;

        public WaitCursorHelper(Form form)
        {
            _form = form;
            _form.Cursor = Cursors.WaitCursor;
        }

        public void Dispose()
        {
            _form.Cursor = Cursors.Default;
        }
    }
}
