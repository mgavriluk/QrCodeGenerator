namespace QrCodeGenerator
{
    public class ImageService
    {
        public void SaveBase64Image(string base64String, string filePath)
        {
            File.WriteAllBytes(filePath, Convert.FromBase64String(base64String));
        }
    }
}
