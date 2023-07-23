using GeneralStoreManagementSystemGUI.BL;
using GeneralStoreManagementSystemGUI.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralStoreManagementSystemGUI.DL
{
    public class Database
    {
        UserList userList;
        ProductList productList;
        User currentUser;
        public Database()
        {
            productList = new ProductList("productDatabase.txt");
            userList = new UserList("userDatabase.txt");
            userList.LoadData();
            productList.LoadData();
        }
        public UserList UserList { get => userList; set => userList = value; }
        public ProductList ProductList { get => productList; set => productList = value; }
        public User CurrentUser { get => currentUser; set => currentUser = value; }
    }
}
