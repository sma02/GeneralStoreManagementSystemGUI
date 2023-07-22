using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralStoreManagementSystemGUI.BL
{
    public class User : Serializable
    {
        private string username;
        private string password;
        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }
        public User(User user) : this(user.Username, user.Password)
        {
            username = user.Username;
            password = user.Password;
        }

        public string Username
        {
            get => username;
            set
            {
                if (value.Length == 0)
                    throw new Exception("username can't be empty");
                username = value;
            }
        }

        public string Password
        {
            get => password;
            set
            {
                if (value.Length == 0)
                    throw new Exception("password can't be empty");
                if (value.Length < 8)
                    throw new Exception("password length can't be less than 8");
                password = value;
            }
        }

        public override string ToString(string separator)
        {
            return username + separator + password;
        }
    }
}
