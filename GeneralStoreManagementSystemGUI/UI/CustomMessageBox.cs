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
    public partial class CustomMessageBox : Form
    {
        enum Type
        {
            Message,
            YesNo
        }
        private CustomMessageBox()
        {
            InitializeComponent();
        }
        public static void Show(string message,string title="")
        {
            CustomMessageBox form = new CustomMessageBox();
            form.Text = title;
            form.labelMessage.Text = message;
            form.buttonOk.Visible = true;
            form.SetSize();
            form.ShowDialog();
        }
        private void SetSize()
        {
            int width = labelMessage.Width + panelBody.Padding.Right*4;
            int height = panelBottom.Height + labelMessage.Height + labelMessage.Location.Y+panelBody.Padding.Bottom*4;
            this.Size = new Size(width, height);
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
