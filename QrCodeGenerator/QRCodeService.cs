using QRCoder;

namespace QrCodeGenerator
{
    public class QRCodeService
    {
        private readonly ImageService _imageService;

        public QRCodeService(ImageService imageService)
        {
            _imageService = imageService;
        }

        public void GenerateAndSaveQRCode(string token)
        {
            var activationUrl = $"https://ua.seller1.vus.us/?qrCodeModal=true&token={token}";
            GenerateQRCodeImage(activationUrl, token);
        }

        private void GenerateQRCodeImage(string data, string token)
        {
            using var qrGenerator = new QRCodeGenerator();
            var qrCodeData = qrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.Q);
            using var qrCode = new Base64QRCode(qrCodeData);
            var base64String = qrCode.GetGraphic(25);

            _imageService.SaveBase64Image(base64String, "C:\\QRCodes\\" + token + ".png");
        }
    }
}
