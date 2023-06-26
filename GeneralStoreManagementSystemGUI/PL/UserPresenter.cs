using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GeneralStoreManagementSystemGUI.BL;
using GeneralStoreManagementSystemGUI.DL;
using GeneralStoreManagementSystemGUI.UI;

namespace GeneralStoreManagementSystemGUI.PL
{
    class UserPresenter
    {
        private readonly IUserView view;
        private readonly IUserList list;
        public UserPresenter(IUserList list, IUserView view)
        {
            this.list = list;
            this.view = view;
            this.list.LoadData();
            this.view.Show();
            view.DataSource = list.GetUsers();
            AssociateEvents();
        }

        private void AssociateEvents()
        {
            view.SearchEvent += View_SearchEvent;
            view.AddEvent += View_AddEvent;
            view.SaveEvent += View_SaveEvent;
        }

        private void View_SaveEvent(object sender, EventArgs e)
        {
            string username = view.Username;
            string password = view.Password;
            string role = view.Role;
            try
            {
                User user;
                switch (role.ToLower())
                {
                    case "admin":
                        user = new Admin(username, password);
                        break;
                    case "cashier":
                        user = new Cashier(username, password);
                        break;
                    default:
                        user = new User(username, password);
                        break;
                }
                list.RegisterUser(user);
                view.DataSource = list.GetUsers();
                view.IsSuccessful = true;
            }
            catch (Exception exception)
            {
                view.IsSuccessful = false;
                view.Message = exception.Message;
            }

        }

        private void View_AddEvent(object sender, EventArgs e)
        {
        }

        private void View_SearchEvent(object sender, EventArgs e)
        {
            IEnumerable users = string.IsNullOrWhiteSpace(view.SearchTerm)
                ? list.GetUsers()
                : list.GetUsers(view.SearchTerm);
            view.DataSource = users;
        }
    }
}
