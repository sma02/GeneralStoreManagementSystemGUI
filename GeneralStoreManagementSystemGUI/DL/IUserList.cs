using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralStoreManagementSystemGUI.BL;

namespace GeneralStoreManagementSystemGUI.DL
{
    public interface IUserList
    {
        bool AddUser(User user);
        bool RegisterUser(User user);
        IEnumerable GetUsers();
        IEnumerable GetUsers(string searchTerm);
        bool IsExists(string username);
        User GetUser(string username);
        User GetUser(User user);
        void ReplaceUser(User oldUser, User newUser);
        bool RemoveUser(string username);
        bool RemoveUser(User user);
        int GetUserIndex(string username);
        void LoadData();
    }
}
