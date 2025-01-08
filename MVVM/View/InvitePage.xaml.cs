using QRCoder;

namespace TruthOrDrinkAppMac;

public partial class InvitePage : ContentPage
{
    public InvitePage()
    {
        InitializeComponent();
        GenerateSessionCode();
    }

    private void GenerateSessionCode()
    {
        // Genereer een willekeurige sessiecode
        var random = new Random();
        var sessionCode = random.Next(100000, 999999).ToString();

        // Stel de sessiecode in de label in
        SessionCodeLabel.Text = $"Sessiecode: {sessionCode}";

        // Genereer de QR-code
        GenerateQRCode(sessionCode);
    }

    private void GenerateQRCode(string sessionCode)
    {
        // Gebruik de QRCodeGenerator bibliotheek om een QR-code te maken
        var qrGenerator = new QRCodeGenerator();
        var qrCodeData = qrGenerator.CreateQrCode(sessionCode, QRCodeGenerator.ECCLevel.Q);
        var qrCode = new BitmapByteQRCode(qrCodeData);
        var qrCodeBytes = qrCode.GetGraphic(20);

        // Converteer de QR-code naar een afbeelding en toon deze
        QRCodeImage.Source = ImageSource.FromStream(() => new MemoryStream(qrCodeBytes));
    }

    private async void OnCancelButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync(); // Ga terug naar de vorige pagina
    }
}
