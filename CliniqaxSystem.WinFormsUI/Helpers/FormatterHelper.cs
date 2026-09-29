namespace CliniqaxSystem.WinFormsUI.Helpers
{
    public static class FormatterHelper
    {
        private static bool _isFormatting = false;
        private static bool _isFormattingKey = false;

        public static void HandleCuitFormat(TextBox textBox)
        {
            if (_isFormatting) 
                return;

            int originalSelectionStart = textBox.SelectionStart;
            int originalLength = textBox.Text.Length;

            string rawText = new string(textBox.Text.Where(char.IsDigit).ToArray());
            
            if (rawText.Length > 11)
                rawText = rawText.Substring(0, 11);

            string formattedText = rawText;
            
            if (rawText.Length > 2 && rawText.Length <= 10)
                formattedText = rawText.Insert(2, "-");
            else if (rawText.Length > 10)
                formattedText = rawText.Insert(2, "-").Insert(11, "-");

            if (textBox.Text == formattedText)
                return;

            _isFormatting = true;
            textBox.Text = formattedText;

            int newLength = textBox.Text.Length;
            int diff = newLength - originalLength;
            int newSelectionStart = originalSelectionStart + diff;

            if (newSelectionStart < 0) 
                newSelectionStart = 0;
            
            if (newSelectionStart > newLength) 
                newSelectionStart = newLength;

            textBox.SelectionStart = newSelectionStart;
            _isFormatting = false;
        }

        public static void HandleLicenseKeyChange(TextBox currentEdit, TextBox? nextEdit, TextBox key1, TextBox key2, TextBox key3, TextBox key4)
        {
            if (_isFormattingKey)
                return;

            string rawText = new string(currentEdit.Text.Where(char.IsLetterOrDigit).ToArray()).ToUpper();

            if (rawText.Length >= 16 || (rawText.Length > 4 && nextEdit != null))
            {
                _isFormattingKey = true;

                try
                {
                    key1.Text = rawText.Length >= 4 ? rawText.Substring(0, 4) : rawText;
                    key2.Text = rawText.Length >= 8 ? rawText.Substring(4, 4) : (rawText.Length > 4 ? rawText.Substring(4) : string.Empty);
                    key3.Text = rawText.Length >= 12 ? rawText.Substring(8, 4) : (rawText.Length > 8 ? rawText.Substring(8) : string.Empty);
                    key4.Text = rawText.Length >= 16 ? rawText.Substring(12, 4) : (rawText.Length > 12 ? rawText.Substring(12) : string.Empty);

                    key4.Focus();
                    key4.SelectionStart = key4.Text.Length;
                }
                finally
                {
                    _isFormattingKey = false;
                }
                return;
            }

            if (nextEdit == null && rawText.Length > 4)
            {
                rawText = rawText.Substring(0, 4);
            }

            if (currentEdit.Text != rawText)
            {
                _isFormattingKey = true;

                try
                {
                    currentEdit.Text = rawText;
                    currentEdit.SelectionStart = rawText.Length;
                }
                finally
                {
                    _isFormattingKey = false;
                }
            }

            if (rawText.Length == 4 && nextEdit != null && currentEdit.Focused)
            {
                nextEdit.Focus();
                nextEdit.SelectAll();
            }
        }

        public static void HandleLicenseKeyBackspace(TextBox currentEdit, TextBox prevEdit, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back && currentEdit.SelectionStart == 0 && currentEdit.SelectionLength == 0)
            {
                prevEdit.Focus();
                prevEdit.SelectionStart = prevEdit.Text.Length;
            }
        }
    }
}
