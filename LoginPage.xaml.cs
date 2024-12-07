using Microsoft.Maui.Controls;

namespace TruthOrDrinkAppMac
{
    public partial class LoginPage : ContentPage
    {
        private const string Username = "test";
        private const string Password = "test";

        public LoginPage()
        {
            InitializeComponent();
        }

        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            string enteredUsername = UsernameEntry.Text;
            string enteredPassword = PasswordEntry.Text;

            if (enteredUsername == Username && enteredPassword == Password)
            {
                // Navigate to HomePage on successful login
                await Navigation.PushAsync(new HomePage());
            }
            else
            {
                // Show error message
                ErrorMessageLabel.Text = "Invalid username or password.";
                ErrorMessageLabel.IsVisible = true;
            }
        }
    }
}