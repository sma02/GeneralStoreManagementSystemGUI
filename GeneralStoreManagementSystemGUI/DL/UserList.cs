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
    public class UserList : GenericList
    {
        private const int UserAttributesLength = 7;
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
            UpdateDataEvent();
            return true;
        }
        private static IEnumerable SelectData(List<User> users)
        {
            return users.Select(x => new { Username = x.Username, ID = x.Id, Phone = x.Phone, Email = x.Email, Type = x.GetType().Name ,DOB =x.BirthDate,Address = x.Address})?.ToList();
        }
        public IEnumerable GetUsers()
        {
            return SelectData(users);
        }

        public IEnumerable GetUsers(string searchTerm)
        {
            List<User> data = users.FindAll(x => x.Username.ToLower().Contains(searchTerm) || x.GetType().Name.ToLower().Contains(searchTerm)||x.Id.ToLower().Contains(searchTerm));
            return SelectData(data);
        }

        public bool IsExists(string username)
        {
            return users.Exists(x => x.Username == username);
        }
        public User AuthenicatedUser(string username, string password)
        {
            return users.Find(x => x.Username == username && x.Password == password);
        }
        public User GetUser(string username)
        {
            return users.Find(x => x.Username == username);
        }
        public User GetUserById(string id)
        {
            return users.Find(x => x.Id == id);
        }
        public User GetUser(int index)
        {
            return users[index];
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
            UpdateDataEvent();
        }
        public bool RemoveUser(string username)
        {
            if (!users.Remove(GetUser(username))) return false;
            StoreData();
            UpdateDataEvent();
            return true;
        }
        public bool RemoveUser(User user)
        {
            return RemoveUser(user.Username);
        }

        protected override void FromCSV(string data)
        {
            if (data == null) return;
            StringReader stream = new StringReader(data);
            string line;
            while ((line = stream.ReadLine()) != null)
            {
                string[] attributes = line.Split(',');
                string username = attributes[0];
                string password = attributes[1];
                string id = attributes[2];
                string email = attributes[3];
                string phone = attributes[4];
                DateTime birthDate = Convert.ToDateTime(attributes[5]);
                string address = attributes[6];
                User user = null;
                if (attributes.Length > UserAttributesLength)
                {
                    switch (attributes.Last())
                    {
                        case nameof(Admin):
                            user = new Admin(username, password);
                            break;
                        case nameof(Cashier):
                            {
                                int performance = int.Parse(attributes[7]);
                                user = new Cashier(username, password, performance);
                                break;
                            }
                    }
                }
                else if (attributes.Length == UserAttributesLength)
                {
                    user = new User(username, password);
                }
                user.Id = id;
                user.Email = email;
                user.Address = address;
                user.Phone = phone;
                user.BirthDate = birthDate;
                users.Add(user);
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

        protected override void ClearList()
        {
            users.Clear();
        }
    }
}
