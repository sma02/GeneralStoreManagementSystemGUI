using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace GeneralStoreManagementSystemGUI.UI
{
    public class CustomDateTimePicker : DateTimePicker
    {
        public CustomDateTimePicker()
        {
            SetStyle(ControlStyles.UserPaint, true);
        }
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Graphics g = CreateGraphics();
            Rectangle dropDownRectangle = new Rectangle(ClientRectangle.Width - 17, 0, 17, 26);
            Brush bkgBrush = new SolidBrush(BackColor);
            g.FillRectangle(bkgBrush, 0, 0, ClientRectangle.Width, ClientRectangle.Height);
            g.DrawString(Text, Font, Brushes.WhiteSmoke, 0, 2);
            ComboBoxRenderer.DrawDropDownButton(g, dropDownRectangle, ComboBoxState.Normal);

            g.Dispose();
            bkgBrush.Dispose();
        }
        [Browsable(true)]
        public override Color BackColor
        {
            get { return base.BackColor; }
            set { base.BackColor = value; }
        }
    }
}
