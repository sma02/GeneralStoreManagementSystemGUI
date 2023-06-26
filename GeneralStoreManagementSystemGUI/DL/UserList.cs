using GeneralStoreManagementSystemGUI.BL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralStoreManagementSystemGUI.DL
{
    public class UserList : GenericList, IUserList
    {
        private const int UserAttributesLength = 2;
        private readonly List<User> users;
        public UserList(string databasePath) : base(databasePath)
        {
            users = new List<User>();
        }
        public bool AddUser(User user)
        {
            if (IsExists(user.Username))
                throw new Exception("user already exists");
            users.Add(user);
            return true;
        }
        public bool RegisterUser(User user)
        {
            if (!AddUser(user)) return false;
            StoreData();
            return true;
        }
        public IEnumerable GetUsers()
        {
            return users.Select(x => new { Username = x.Username, Type = x.GetType().Name })?.ToList();
        }

        public IEnumerable GetUsers(string searchTerm)
        {
            return users.FindAll(x =>
                    x.Username.ToLower().Contains(searchTerm) || x.GetType().Name.ToLower().Contains(searchTerm))
                .Select(x => new { x.Username, Type = x.GetType().Name })
                ?.ToList();
        }

        public bool IsExists(string username)
        {
            return users.Exists(x => x.Username == username);
        }
        public User GetUser(string username)
        {
            return users.Find(x => x.Username == username);
        }
        public int GetUserIndex(string username)
        {
            return users.FindIndex(x => x.Username == username);
        }
        public User GetUser(User user)
        {
            return GetUser(user.Username);
        }
        public void ReplaceUser(User oldUser, User newUser)
        {
            users[users.FindIndex(x => x == oldUser)] = newUser;
            StoreData();
        }
        public bool RemoveUser(string username)
        {
            if (!users.Remove(GetUser(username))) return false;
            StoreData();
            return true;
        }
        public bool RemoveUser(User user)
        {
            return RemoveUser(user.Username);
        }

        protected override void FromCSV(string data)
        {
            StringReader stream = new StringReader(data);
            string line;
            while ((line = stream.ReadLine()) != null)
            {
                string[] attributes = line.Split(',');
                string username = attributes[0];
                string password = attributes[1];
                if (attributes.Length > UserAttributesLength)
                {
                    switch (attributes.Last())
                    {
                        case nameof(Admin):
                            users.Add(new Admin(username, password));
                            break;
                        case nameof(Cashier):
                            {
                                int performance = int.Parse(attributes[2]);
                                users.Add(new Cashier(username, password, performance));
                                break;
                            }
                    }
                }
                else if (attributes.Length == UserAttributesLength)
                {
                    users.Add(new User(username, password));
                }
            }
        }

        protected override string ToCSV()
        {
            StringWriter stream = new StringWriter();
            foreach (User user in users)
            {
                stream.WriteLine(user.ToCSV());
            }
            stream.Close();
            return stream.ToString();
        }
    }
}
