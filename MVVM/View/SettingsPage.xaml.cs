using System;
using Plugin.LocalNotification;
using Microsoft.Maui.Controls;

namespace TruthOrDrinkAppMac
{
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
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
    }
}
