namespace CliniqaxSystem.WinFormsUI.Helpers
{
    public static class FormatterHelper
    {
        private static bool _isFormatting = false;

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
    }
}
