using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralStoreManagementSystemGUI.BL;

namespace GeneralStoreManagementSystemGUI.UI
{
    public interface IUserView
    {
        string Username { get; set; }
        string Password { get; set; }
        string Role { get; set; }
        string SearchTerm { get; set; }
        bool IsSuccessful { get; set; }
        string Message { get; set; }

        event EventHandler SearchEvent;
        event EventHandler AddEvent;
        event EventHandler RemoveEvent;
        event EventHandler EditEvent;
        event EventHandler SaveEvent;
        IEnumerable DataSource { set; }
        void Show();
    }
}
