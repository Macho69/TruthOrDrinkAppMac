using System;
using Plugin.LocalNotification;
using Microsoft.Maui.Controls;

namespace TruthOrDrinkAppMac
{
    public partial class SettingsPage : ContentPage
    {
        private readonly UsersRepository _userRepository;
        private readonly TruthOrDrinkAppMac.MVVM.Model.User _currentUser;
        public SettingsPage(TruthOrDrinkAppMac.MVVM.Model.User currentUser)
        {
            InitializeComponent();
            _userRepository = new UsersRepository();
            _currentUser = currentUser;
        }

        private void OnTestNotificationClicked(object sender, EventArgs e)
        {
            var notification = new NotificationRequest
            {
                Title = "Truth or Drink",
                Description = "Begin met drinken! Of vertel de waarheid...",
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = DateTime.Now.AddSeconds(1),
                    NotifyRepeatInterval = TimeSpan.FromMinutes(5)
                }
            };
            LocalNotificationCenter.Current.Show(notification);
        }

        private async void OnUpdateButtonClicked(object sender, EventArgs e)
        {
            string newUsername = NewUsernameEntry.Text;
            string newPassword = NewPasswordEntry.Text;

            if (string.IsNullOrWhiteSpace(newUsername) && string.IsNullOrWhiteSpace(newPassword))
            {
                await DisplayAlert("Error", "Vul een nieuwe username of wachtwoord in.", "OK");
                return;
            }

            // Update the user object
            if (!string.IsNullOrWhiteSpace(newUsername))
                _currentUser.Username = newUsername;

            if (!string.IsNullOrWhiteSpace(newPassword))
                _currentUser.Password = newPassword;

            int result = _userRepository.UpdateUser(_currentUser);

            if (result > 0)
            {
                await DisplayAlert("Succes", "Gebruikersinformatie succesvol gewijzigd.", "OK");
            }
            else
            {
                await DisplayAlert("Error", "Fout bij het wijzigen van de gebruikersinformatie.", "OK");
            }
        }

        private async void OnDeleteAccountButtonClicked(object sender, EventArgs e)
        {
            bool confirm = await DisplayAlert("Bevestig", "Weet je zeker dat je het account wilt verwijderen?", "Ja", "Nee");
            if (!confirm) return;

            int result = _userRepository.DeleteUser(_currentUser.UserId);

            if (result > 0)
            {
                await DisplayAlert("Succes", "Account succesvol verwijderd.", "OK");
                await Navigation.PopToRootAsync();
            }
            else
            {
                await DisplayAlert("Error", "Fout bij het verwijderen van het account.", "OK");
            }
        }
    }
}
