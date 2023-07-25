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
        public enum Type
        {
            Message,
            YesNo
        }
        private CustomMessageBox()
        {
            InitializeComponent();
            DialogResult = DialogResult.No;
        }
        public static void Show(string message, string title = "")
        {
            CustomMessageBox form = new CustomMessageBox();
            form.Text = title;
            form.labelMessage.Text = message;
            form.buttonOk.Visible = true;
            form.SetSize();
            form.ShowDialog();
        }
        public static DialogResult Show(string message, string title, Type type)
        {
            CustomMessageBox form = CreateForm(message, title);
            if (type == Type.YesNo)
            {
                form.buttonYes.Visible = true;
                form.buttonNo.Visible = true;
                form.SetSize();
            }
            return form.ShowDialog();
        }
        private static CustomMessageBox CreateForm(string message, string title)
        {
            CustomMessageBox form = new CustomMessageBox();
            form.Text = title;
            form.labelMessage.Text = message;
            return form;
        }
        private void SetSize()
        {
            int width = labelMessage.Width + panelBody.Padding.Right * 4;
            int height = panelBottom.Height + labelMessage.Height + labelMessage.Location.Y + panelBody.Padding.Bottom * 4;
            this.Size = new Size(width, height);
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonYes_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            Close();
        }

        private void buttonNo_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
