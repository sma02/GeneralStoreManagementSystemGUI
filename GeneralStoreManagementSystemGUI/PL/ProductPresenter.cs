using GeneralStoreManagementSystemGUI.DL;
using GeneralStoreManagementSystemGUI.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralStoreManagementSystemGUI.PL
{
    class ProductPresenter
    {
        private IProductList list;
        private IProductView view;
        public ProductPresenter(IProductList list,IProductView view)
        {
            this.list = list;
            this.view = view;
            list.LoadData();
            view.Show();
        }
    }
}
