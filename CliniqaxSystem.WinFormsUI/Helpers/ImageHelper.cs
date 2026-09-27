namespace CliniqaxSystem.WinFormsUI.Helpers
{
    public static class ImageHelper
    {
        private const long MaxFileSizeBytes = 5 * 1024 * 1024; // 5 MB

        public static Image? LoadFromBytes(byte[]? imageBytes)
        {
            if (imageBytes == null || imageBytes.Length == 0)
                return null;

            try
            {
                using var ms = new MemoryStream(imageBytes);
                return new Bitmap(Image.FromStream(ms));
            }
            catch
            {
                return null;
            }
        }

        public static bool SelectImage(out byte[]? imageBytes, out Image? displayImage, out string? errorMessage)
        {
            imageBytes = null;
            displayImage = null;
            errorMessage = null;

            using var ofd = new OpenFileDialog
            {
                Title = "Seleccionar Imagen",
                Filter = "Archivos de Imagen|*.jpg;*.jpeg;*.png;*.bmp;*.webp",
                FilterIndex = 1,
                RestoreDirectory = true
            };

            if (ofd.ShowDialog() != DialogResult.OK)
                return false;

            try
            {
                var fileInfo = new FileInfo(ofd.FileName);
                
                if (fileInfo.Length > MaxFileSizeBytes)
                {
                    errorMessage = "La imagen seleccionada supera el límite máximo permitido de 5 MB.";
                    return false;
                }

                byte[] bytes = File.ReadAllBytes(ofd.FileName);
                
                using (var ms = new MemoryStream(bytes))
                {
                    using var img = Image.FromStream(ms);
                    displayImage = new Bitmap(img);
                }

                imageBytes = bytes;
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = "No se pudo cargar el archivo de imagen: " + ex.Message;
                return false;
            }
        }

        public static void Clear(PictureBox pictureBox)
        {
            pictureBox.Image?.Dispose();
            pictureBox.Image = null;
        }
    }
}
