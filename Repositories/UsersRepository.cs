using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruthOrDrinkAppMac
{
    public class UsersRepository
    {
        SQLiteConnection connection;
        public UsersRepository()
        {
            connection = new SQLiteConnection(
                Constants.DatabasePath,
                Constants.Flags);
        }
    }
}
