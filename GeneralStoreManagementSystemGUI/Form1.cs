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
using GeneralStoreManagementSystemGUI.PL;
using GeneralStoreManagementSystemGUI.UI;

namespace GeneralStoreManagementSystemGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            btnUserManagement.Click += (x, y) =>
            {
               IUserList list=  new UserList("userDatabase.txt");
               IUserView view = new UserView();
               UserPresenter presenter = new UserPresenter(list, view);
            };
        }
    }
}
