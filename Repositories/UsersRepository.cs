using SQLite;
using System;
using TruthOrDrinkAppMac.MVVM.Model;

namespace TruthOrDrinkAppMac
{
    public class UsersRepository
    {
        private SQLiteConnection _connection;

        public UsersRepository()
        {
            _connection = new SQLiteConnection(Constants.DatabasePath, Constants.Flags);
            _connection.CreateTable<User>();
        }

        public string StatusMessage { get; set; }

        public int AddUser(User newUser)
        {
            try
            {
                if (string.IsNullOrEmpty(newUser.Email) || string.IsNullOrEmpty(newUser.Password))
                    throw new Exception("Valid email and password are required.");

                return _connection.Insert(newUser);
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
                return 0;
            }
        }

        public User GetUser(string usernameOrEmail, string password)
        {
            try
            {
                return _connection.Table<User>()
                    .FirstOrDefault(u =>
                        (u.Username == usernameOrEmail || u.Email == usernameOrEmail) &&
                        u.Password == password);
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
                return null;
            }
        }

        public User GetUserByUsername(string username)
        {
            try
            {
                return _connection.Table<User>().FirstOrDefault(u => u.Username == username);
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
                return null;
            }
        }

        public List<User> GetAllUsers()
        {
            try
            {
                return _connection.Table<User>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
                return new List<User>();
            }
        }

        public int UpdateUser(User updatedUser)
        {
            try
            {
                return _connection.Update(updatedUser);
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
                return 0;
            }
        }

        public int DeleteUser(int userId)
        {
            try
            {
                var user = _connection.Table<User>().FirstOrDefault(u => u.UserId == userId);
                if (user != null)
                {
                    return _connection.Delete(user);
                }
                return 0;
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
                return 0;
            }
        }
    }
}
