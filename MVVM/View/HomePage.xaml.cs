namespace TruthOrDrinkAppMac;

public partial class HomePage : ContentPage
{
    private TruthOrDrinkAppMac.MVVM.Model.User _loggedInUser;
    public HomePage(TruthOrDrinkAppMac.MVVM.Model.User loggedInUser)
    {
        InitializeComponent();
        _loggedInUser = loggedInUser;

        // Update UsernameLabel with the username of the logged-in user
        UsernameLabel.Text = $"Welcome, {_loggedInUser.Username}!";
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
