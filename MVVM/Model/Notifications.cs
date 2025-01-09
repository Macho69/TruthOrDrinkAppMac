using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruthOrDrinkAppMac.MVVM.Model
{
    public class NotificationSettings
    {
        public int Id { get; set; } // Primary key
        public int UserId { get; set; } // Foreign key to Users
        public bool IsEnabled { get; set; } // Toggle notifications on/off
        public DateTime LastNotified { get; set; } // Tracks the last time a notification was sent
    }

}
