using ZXing.Net.Maui;

namespace TruthOrDrinkAppMac;

public partial class ScannerPage : ContentPage
{
    public Action<string>? OnScanCompleted; // Callback voor gescande data

    public ScannerPage()
    {
        InitializeComponent();
        Console.WriteLine("ScannerPage is geïnitialiseerd.");
    }

    private void OnBarcodesDetected(object sender, BarcodeDetectionEventArgs e)
    {
        if (e.Results.Any())
        {
            // Pak de eerste gescande barcode
            var barcode = e.Results.FirstOrDefault();
            if (barcode != null)
            {
                Dispatcher.Dispatch(() =>
                {
                    // Stuur het resultaat terug via de callback
                    OnScanCompleted?.Invoke(barcode.Value);

                    // Optioneel: toon een melding
                    DisplayAlert("QR-code Gedetecteerd", $"Inhoud: {barcode.Value}", "OK");

                    // Sluit de scanner
                    Navigation.PopAsync();
                });
            }
        }
    }

    private async void OnCancelClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync(); // Ga terug zonder te scannen
    }
}
