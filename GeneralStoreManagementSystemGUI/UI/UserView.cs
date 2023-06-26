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
using GeneralStoreManagementSystemGUI.BL;

namespace GeneralStoreManagementSystemGUI.UI
{
    public partial class UserView : Form, IUserView
    {
        public UserView()
        {
            InitializeComponent();
            tabControl1.TabPages.Remove(tabPageUserEntry);
            textBoxSearchTerm.KeyDown += TextBoxSearchTerm_KeyDown;
            buttonSearch.Click += (sender, args) =>
            {
                SearchEvent?.Invoke(this, EventArgs.Empty);
                textBoxSearchTerm.Focus();
            };
            buttonAdd.Click += ButtonAdd_Click;
            buttonSave.Click += ButtonSave_Click;
        }

        private void ButtonSave_Click(object sender, EventArgs args)
        {
            SaveEvent?.Invoke(sender, args);
            if (!IsSuccessful)
            {
                MessageBox.Show(Message);
            }
            else
            {
                tabControl1.TabPages.Add(tabPageUserList);
                tabControl1.TabPages.Remove(tabPageUserEntry);
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabPageUserList);
            tabControl1.TabPages.Add(tabPageUserEntry);
            AddEvent?.Invoke(this, EventArgs.Empty);
        }

        private void TextBoxSearchTerm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchEvent?.Invoke(this, EventArgs.Empty);
            }
        }

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
        public string SearchTerm
        {
            get => textBoxSearchTerm.Text;
            set => textBoxSearchTerm.Text = value;
        }

        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
        public event EventHandler SearchEvent;
        public event EventHandler AddEvent;
        public event EventHandler RemoveEvent;
        public event EventHandler EditEvent;
        public event EventHandler SaveEvent;
        public IEnumerable DataSource
        {
            set => dataGridView1.DataSource = value;
        }
    }
}
