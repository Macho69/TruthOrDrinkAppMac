using TruthOrDrinkAppMac.MVVM.Model;

namespace TruthOrDrinkAppMac.MVVM.View;

public partial class CreateUserPage : ContentPage
{
    private UsersRepository _userRepository;
    public CreateUserPage()
	{
		InitializeComponent();
        _userRepository = new UsersRepository();
    }

    private async void OnRegisterButtonClicked(object sender, EventArgs e)
    {
        string email = RegisterEmailEntry.Text;
        string username = RegisterUsernameEntry.Text;
        string password = RegisterPasswordEntry.Text;

        var newUser = new User
        {
            Email = email,
            Username = username,
            Password = password // Hier kun je ook hashing toepassen
        };

        int result = _userRepository.AddUser(newUser);

        if (result > 0)
        {
            await DisplayAlert("Success", "Registration successful!", "OK");
        }
        else
        {
            await DisplayAlert("Error", _userRepository.StatusMessage, "OK");
        }
    }
}