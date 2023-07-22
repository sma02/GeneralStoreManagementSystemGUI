using GeneralStoreManagementSystemGUI.BL;
using GeneralStoreManagementSystemGUI.DL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneralStoreManagementSystemGUI.UI
{
    public partial class UserView : Form
    {
        private readonly UserList list;
        public string Username
        {
            get => textBoxUsername.Text;
            set => textBoxUsername.Text = value;
        }
        public string Password
        {
            get => textBoxPassword.Text;
            set => textBoxPassword.Text = value;
        }
        public string Role
        {
            get => comboBoxRole.Text;
            set => comboBoxRole.Text = value;
        }
        private UserView()
        {
            InitializeComponent();
            searchView = new SearchViewControl();
            searchView.Visible = true;
            searchView.Dock = DockStyle.Fill;
            panelUserData.Visible = false;
            Controls.Add(searchView);
            searchView.SearchEvent += SearchView_SearchEvent;
            searchView.AddEvent += SearchView_AddEvent;
        }

        private void SearchView_AddEvent(object sender, EventArgs e)
        {
            panelUserData.Visible = true;
            searchView.Visible = false;
        }

        public UserView(UserList list) : this()
        {
            this.list = list;
            this.list.LoadData();
            searchView.DataSource = this.list.GetUsers();
        }

        private void SearchView_SearchEvent(object sender, EventArgs e)
        {
            IEnumerable users = string.IsNullOrWhiteSpace(((SearchViewControl)sender).SearchTerm)
     ? list.GetUsers()
     : list.GetUsers(searchView.SearchTerm);
            searchView.DataSource = users;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            searchView.Visible = true;
            panelUserData.Visible = false;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                User user;
                switch (Role.ToLower())
                {
                    case "admin":
                        user = new Admin(Username, Password);
                        break;
                    case "cashier":
                        user = new Cashier(Username, Password);
                        break;
                    default:
                        user = new User(Username, Password);
                        break;
                }
                list.RegisterUser(user);
                searchView.DataSource = list.GetUsers();
                searchView.Visible = true;
                panelUserData.Visible = false;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void UserView_Resize(object sender, EventArgs e)
        {
            comboBoxRole.Refresh();
        }

        private void panelUserData_Paint(object sender, PaintEventArgs e)
        {
            comboBoxRole.Refresh();
        }
    }
}
