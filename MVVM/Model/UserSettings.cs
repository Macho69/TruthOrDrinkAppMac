using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruthOrDrinkAppMac.MVVM.Model
{
    [Table("UserSettings")]
    public class UserSettings
    {
        [PrimaryKey]
        public int UserId { get; set; }
        public bool NotificationsEnabled { get; set; }
    }
}
