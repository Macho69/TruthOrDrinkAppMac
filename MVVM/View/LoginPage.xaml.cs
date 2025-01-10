using Microsoft.Maui.Controls;
using TruthOrDrinkAppMac.MVVM.Model;
using TruthOrDrinkAppMac.MVVM.View;

namespace TruthOrDrinkAppMac
{
    public partial class LoginPage : ContentPage
    {
        private UsersRepository _userRepository;

        public LoginPage()
        {
            InitializeComponent();
            _userRepository = new UsersRepository();
        }

        private async void OnCreateUserClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateUserPage());
        }

        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            string enteredUsername = UsernameEntry.Text;
            string enteredPassword = PasswordEntry.Text;

            var user = _userRepository.GetUser(enteredUsername, enteredPassword);

            if (user != null)
            {
                await Navigation.PushAsync(new HomePage(user));
            }
            else
            {
                ErrorMessageLabel.Text = "Invalid username or password.";
                ErrorMessageLabel.IsVisible = true;
            }
        }
    }
}
