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
        PurchaseLog purchaseLog;
        User currentUser;
        public Database()
        {
            productList = new ProductList("productDatabase.txt");
            userList = new UserList("userDatabase.txt");
            purchaseLog = new PurchaseLog("purchaseLogDatabase.txt", productList, userList);
            userList.LoadData();
            productList.LoadData();
            purchaseLog.LoadData();
        }
        public UserList UserList { get => userList; set => userList = value; }
        public ProductList ProductList { get => productList; set => productList = value; }
        public User CurrentUser { get => currentUser; set => currentUser = value; }
        internal PurchaseLog PurchaseLog { get => purchaseLog; set => purchaseLog = value; }
    }
}
