using GeneralStoreManagementSystemGUI.BL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralStoreManagementSystemGUI.DL
{
    interface IProductList
    {
        IEnumerable GetList();
        IEnumerable GetList(string searchTerm);
        bool IsExists(string productName);
        void AddProduct(Product product);
        void RemoveProduct(string productName);
        void LoadData();
    }
}
