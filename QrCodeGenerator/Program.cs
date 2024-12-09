using QrCodeGenerator;

QRCodeService qRCodeService = new QRCodeService(new ImageService());

for (int i = 0; i < 5; i++)
{
    var token = Convert.ToBase64String(Guid.NewGuid().ToByteArray())
        .Replace("=", "")
        .Replace("+", "")
        .Replace("/", "");

    Console.WriteLine(token);
    qRCodeService.GenerateAndSaveQRCode(token);
}