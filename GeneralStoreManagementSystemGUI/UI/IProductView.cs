using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralStoreManagementSystemGUI.UI
{
   public interface IProductView
    {
        string Name { get; set; }
        double CostPrice { get;set; }
        double RetailPrice { get; set; }
        float ProfitPercentage { get; set; }
        int Quantity { get; set; }
        bool IsSuccessful { get; set; }
        string Message { get; set; }

        void Show();

        event EventHandler SearchEvent;
        event EventHandler AddEvent;
        event EventHandler EditEvent;
        event EventHandler RemoveEvent;

    }
}
