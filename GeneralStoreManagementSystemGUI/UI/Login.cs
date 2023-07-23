﻿using GeneralStoreManagementSystemGUI.BL;
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
    public partial class Login : Form
    {
        public Login(Database database)
        {
            InitializeComponent();
            DialogResult = DialogResult.Cancel;
            this.database = database;
            MaximizeBox = false;
            buttonRegister.FlatAppearance.MouseOverBackColor = buttonRegister.BackColor;
            buttonRegister.FlatAppearance.MouseDownBackColor = buttonRegister.BackColor;
            buttonRegister.MouseDown += (s, e) => buttonRegister.ForeColor = Color.DeepPink;
            buttonRegister.MouseUp += (s, e) => buttonRegister.ForeColor = Color.DeepSkyBlue;
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string username = textUsername.Text;
            string password = textPassword.Text;
            User user = database.UserList.AuthenicatedUser(username, password);
            if(user!=null)
            {
                database.CurrentUser = user;
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
