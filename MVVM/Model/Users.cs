using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruthOrDrinkAppMac.MVVM.Model
{
    [Table("User")]
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int UserId { get; set; } // Primaire sleutel, automatisch gegenereerd

        [Required]
        [Unique]
        [StringLength(100)]
        public string Email { get; set; } // Email van de gebruiker

        [Required]
        [Unique]
        [StringLength(50)]
        public string Username { get; set; } // Gebruikersnaam van de gebruiker

        [Required]
        [StringLength(100)]
        public string Password { get; set; } // Wachtwoord (je zou hashing moeten toepassen!)

    }
}
