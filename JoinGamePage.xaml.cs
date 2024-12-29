namespace TruthOrDrinkAppMac;

public partial class JoinGamePage : ContentPage
{
    public JoinGamePage()
    {
        InitializeComponent();
    }

    private async void OnScanQRCodeClicked(object sender, EventArgs e)
    {
        try
        {
            Console.WriteLine("Navigeren naar ScannerPage...");
            var scannerPage = new ScannerPage();
            scannerPage.OnScanCompleted = (result) =>
            {
                Console.WriteLine($"Scanresultaat ontvangen: {result}");
                Dispatcher.Dispatch(() =>
                {
                    SessionCodeEntry.Text = result;
                });
            };
            await Navigation.PushAsync(scannerPage);
            Console.WriteLine("Navigatie voltooid.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fout: {ex.Message}");
            await DisplayAlert("Fout", $"Er is een fout opgetreden: {ex.Message}", "OK");
        }
    }



    private async void OnJoinGameClicked(object sender, EventArgs e)
    {
        var sessionCode = SessionCodeEntry.Text;

        if (string.IsNullOrEmpty(sessionCode))
        {
            await DisplayAlert("Fout", "Vul een sessiecode in of scan een QR-code.", "OK");
            return;
        }

        // Simuleer deelnemen aan een sessie
        await DisplayAlert("Succes", $"Je hebt deelgenomen aan de sessie met code: {sessionCode}", "OK");
        await Navigation.PopAsync(); // Ga terug naar de vorige pagina
    }

    private async void OnCancelButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync(); // Ga terug naar de vorige pagina
    }
}
