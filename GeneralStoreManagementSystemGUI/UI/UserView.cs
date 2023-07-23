﻿using GeneralStoreManagementSystemGUI.BL;
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
        public string Role
        {
            get => comboBoxRole.Text;
            set => comboBoxRole.Text = value;
        }
        public string Username { set => textUsername.Text = value; }
        public string Email { set => textEmail.Text = value; }
        public string Address { set => textAddress.Text = value; }
        public string Id { set => maskedTextID.Text = value; }
        public DateTime BirthDate { set => customDateTimePicker1.Value = value; }
        public string Phone { set => maskedTextPhone.Text = value; }
        private UserView()
        {
            InitializeComponent();
            searchView = new SearchViewControl();
            searchView.Visible = true;
            searchView.Dock = DockStyle.Fill;
            panelUserData.Visible = false;
            Controls.Add(searchView);
            searchView.SearchEvent += SearchView_SearchEvent;
            searchView.SecondButton.Text = "Change Role";
            searchView.SecondButton.Visible = true;
            searchView.SecondButton.Click += SearchView_ChangeRoleEvent;
            comboBoxRole.SelectedItem = "User";
            textUsername.KeyPress += TextBoxes_KeyPress;
        }
        private void SetFields()
        {
            User user = list.GetUser(searchView.SelectedItemIndex);
            Username = user.Username;
            Email = user.Email;
            Address = user.Address;
            Phone = user.Phone;
            Id = user.Id;
            Role = user.GetType().Name;
            BirthDate = user.BirthDate;
            
        }
        private void TextBoxes_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Char.IsPunctuation(e.KeyChar) ||
                  Char.IsSeparator(e.KeyChar) ||
                  Char.IsSymbol(e.KeyChar);
        }

        public UserView(UserList list) : this()
        {
            this.list = list;
            searchView.DataSource = this.list.GetUsers();
        }

        private void SearchView_ChangeRoleEvent(object sender, EventArgs e)
        {
            SetFields();
            panelUserData.Visible = true;
            searchView.Visible = false;
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
                User user = list.GetUser(searchView.SelectedItemIndex);
                User newUser;
                switch (Role.ToLower())
                {
                    case "admin":
                        newUser = new Admin(user);
                        break;
                    case "cashier":
                        newUser = new Cashier(user);
                        break;
                    case "user":
                        newUser = new User(user);
                        break;
                    default:
                        throw new Exception("Invalid User");
                }
                list.ReplaceUser(user, newUser);
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
