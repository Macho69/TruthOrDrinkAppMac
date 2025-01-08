namespace TruthOrDrinkAppMac;

public partial class HomePage : ContentPage
{
    public HomePage()
    {
        InitializeComponent();
    }

    private async void OnHostClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SessionPage());
    }

    private async void OnJoinClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new JoinGamePage());
    }

    private async void OnSettingsClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SettingsPage());
    }

    private async void OnFriendsListClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new FriendsListPage());
    }

    private async void OnLogoutClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LoginPage());
    }
}
