namespace TruthOrDrinkAppMac;

public partial class HomePage : ContentPage
{
    public HomePage()
    {
        InitializeComponent();
    }

    private async void OnStartSessionClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SessionPage());
    }

    private async void OnCustomQuestionsClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CustomQuestionsPage());
    }

    private async void OnSettingsClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SettingsPage());
    }
}