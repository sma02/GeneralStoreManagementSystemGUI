using GeneralStoreManagementSystemGUI.BL;
using GeneralStoreManagementSystemGUI.DL;
using System;
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
    public partial class Register : Form
    {
        public string Username { get => textUsername.Text; }
        public string Password { get => textPassword.Text; }
        public string Email { get => textEmail.Text; }
        public string Address { get => textAddress.Text; }
        public string Id { get => maskedTextID.Text; }
        public DateTime BirthDate { get => customDateTimePicker1.Value.Date; }
        public string Phone { get => maskedTextPhone.Text; }
        public Register(Database database)
        {
            InitializeComponent();
            this.database = database;
            textUsername.KeyPress += TextBoxes_KeyPress;
            textPassword.KeyPress += TextBoxes_KeyPress;
            textEmail.KeyPress += TextEmail_KeyPress; ;
            textAddress.KeyPress += TextBoxes_KeyPress;
        }

        private void TextEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != '@' && e.KeyChar != '.'
                        && (char.IsPunctuation(e.KeyChar)
                        || char.IsSeparator(e.KeyChar)
                        || char.IsSymbol(e.KeyChar));
        }

        private void TextBoxes_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != ' '
                        && (char.IsPunctuation(e.KeyChar)
                        || char.IsSeparator(e.KeyChar)
                        || char.IsSymbol(e.KeyChar));
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            bool fields = Username.Length == 0 || Password.Length == 0 || Email.Length == 0 || Address.Length == 0 || !maskedTextID.MaskFull || !maskedTextPhone.MaskFull;
            if (fields)
            {
                labelFieldsEmpty.Visible = true;
                return;
            }
            try
            {
                User user = new User(Username, Password);
                user.Email = Email;
                user.Address = Address;
                user.Id = Id;
                user.BirthDate = BirthDate;
                user.Phone = Phone;
                database.UserList.RegisterUser(user);
                CustomMessageBox.Show("Account Registered Successfully and Await Approval by an Admin");
                Close();
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show(ex.Message);
            }
        }
    }

}
