using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GeneralStoreManagementSystemGUI.BL;
using GeneralStoreManagementSystemGUI.DL;
using GeneralStoreManagementSystemGUI.UI;

namespace GeneralStoreManagementSystemGUI.UI
{
    public partial class MainView : Form
    {
        private Form activeForm;
        public MainView(Database database)
        {
            InitializeComponent();
            this.database = database;
            activeForm = null;
            Panel panel = (Panel)panelButtons.Controls[0];
            panelButtons.Controls.Remove(panel);
            if (database.CurrentUser.GetType() == typeof(Admin))
            {
                AddAdminButtons();
            }
            else if(database.CurrentUser.GetType()==typeof(Cashier))
            {
                AddCashierButtons();
            }
            panelButtons.Controls.Add(panel);
        }
        private void AddAdminButtons()
        {
            Button userManagementButton = AddButton("User Management");
            Button productManagementButton = AddButton("Product Management");
            userManagementButton.Click += (s, e) =>CurrentActiveForm = new UserView(database.UserList);
            productManagementButton.Click += (s, e) =>CurrentActiveForm = new ProductView(database.ProductList);
        }
        private void AddCashierButtons()
        {
            Button newOrderButton = AddButton("New Order");
            newOrderButton.Click += (s, e) => CurrentActiveForm = new OrderView(database);
        }
        private Button AddButton(string text)
        {
            Button button = new Button();
            button.BackColor = Color.FromArgb(45, 50, 50);
            button.Dock = DockStyle.Top;
            button.FlatAppearance.BorderSize = 0;
            button.FlatStyle = FlatStyle.Flat;
            button.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button.ForeColor = Color.Gainsboro;
            button.Size = new Size(200, 38);
            button.TabIndex = 2;
            button.Text = text;
            button.UseVisualStyleBackColor = false;
            panelButtons.Controls.Add(button);
            return button;
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
