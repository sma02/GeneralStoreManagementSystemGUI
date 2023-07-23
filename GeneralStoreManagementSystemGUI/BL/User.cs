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
        private string id;
        private string email;
        private string phone;
        private DateTime birthDate;
        private string address;
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

        public string Id { get => id; set => id = value; }
        public string Email
        {
            get => email;
            set
            {
                try
                {
                    var mail = new System.Net.Mail.MailAddress(value);
                    email = mail.Address;
                }
                catch
                {
                    throw new Exception("Invalid Email");
                }
            }
        }
        public string Phone { get => phone; set => phone = value; }
        public string Address { get => address; set => address = value; }
        public DateTime BirthDate { get => birthDate; set => birthDate = value; }

        public override string ToString(string separator)
        {
            return username + separator + password;
        }
    }
}
