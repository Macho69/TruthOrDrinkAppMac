namespace TruthOrDrinkAppMac;

public partial class SessionPage : ContentPage
{
    public SessionPage()
    {
        InitializeComponent();
    }

    private async void OnStartGameClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new QuestionPage());
    }
}