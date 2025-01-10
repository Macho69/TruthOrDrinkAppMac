using TruthOrDrinkAppMac;

namespace TruthOrDrinkAppMac;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        MainPage = new NavigationPage(new LoginPage());

        string username = Preferences.Get("LoggedInUsername", string.Empty);

        if (!string.IsNullOrEmpty(username))
        {
            var user = new UsersRepository().GetUserByUsername(username);

            if (user != null)
            {
                MainPage = new NavigationPage(new HomePage(user));
            }
            else
            {
                MainPage = new NavigationPage(new LoginPage());
            }
        }
        else
        {
            MainPage = new NavigationPage(new LoginPage());
        }
    }
}