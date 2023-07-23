using GeneralStoreManagementSystemGUI.BL;
using GeneralStoreManagementSystemGUI.DL;
using GeneralStoreManagementSystemGUI.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneralStoreManagementSystemGUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Database database = new Database();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            while (true)
            {
                DialogResult Result = (new Login(database)).ShowDialog();
                if (Result == DialogResult.OK)
                {
                    (new MainView(database)).ShowDialog();
                }
                else if (Result == DialogResult.Cancel)
                {
                    break;
                }
            }
        }
    }
}
