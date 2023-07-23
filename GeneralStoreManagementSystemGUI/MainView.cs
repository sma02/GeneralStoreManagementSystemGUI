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

namespace GeneralStoreManagementSystemGUI
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
            panelButtons.Controls.Add(panel);
        }
        private void AddAdminButtons()
        {
            Button userManagementButton = AddButton("User Management");
            Button productManagementButton = AddButton("Product Management");
            userManagementButton.Click += (s, e) =>
            {
                Form form = new UserView(database.UserList);
                CurrentActiveForm = form;
            };
            productManagementButton.Click += (s, e) =>
            {
                Form form = new ProductView(database.ProductList);
                CurrentActiveForm = form;
            };
        }
        private Button AddButton(string text)
        {
            Button button = new Button();
            button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            button.Dock = System.Windows.Forms.DockStyle.Top;
            button.FlatAppearance.BorderSize = 0;
            button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            button.ForeColor = System.Drawing.Color.Gainsboro;
            button.Size = new System.Drawing.Size(200, 38);
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
