using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GeneralStoreManagementSystemGUI.DL;
using GeneralStoreManagementSystemGUI.UI;

namespace GeneralStoreManagementSystemGUI
{
    public partial class MainView : Form
    {
        private Form activeForm;
        public MainView()
        {
            InitializeComponent();
            activeForm = null;
            buttonUserManagement.Click += (s, e) =>
            {
                UserList list = new UserList("userDatabase.txt");
                Form form = new UserView(list);
                CurrentActiveForm = form;
            };
            buttonProductManagement.Click += (s, e) =>
            {
                ProductList list = new ProductList("productDatabase.txt");
                Form form = new ProductView(list);
                CurrentActiveForm = form;
            };
        }
        public Form CurrentActiveForm
        {
            set
            {
                activeForm?.Close();
                activeForm = value;
                activeForm.Dock = DockStyle.Fill;
                activeForm.TopLevel = false;
                activeForm.FormBorderStyle = FormBorderStyle.None;
                panelFormContainer.Controls.Add(activeForm);
                panelFormContainer.Tag = value;
                activeForm.BringToFront();
                activeForm.Show();
            }
        }
    }
}
