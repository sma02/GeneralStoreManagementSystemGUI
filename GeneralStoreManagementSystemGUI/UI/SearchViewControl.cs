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
    public partial class SearchViewControl : UserControl
    {
        public Button FirstButton => buttonFirst;
        public Button SecondButton => buttonSecond;
        public Button ThirdButton => buttonThird;
        public event EventHandler SearchEvent;
        public string SearchTerm { get => textBoxSearchTerm.Text; }
        public int SelectedItemIndex { get => dataGridView.SelectedRows[0].Index; }
        public IEnumerable DataSource
        {
            set => dataGridView.DataSource = value;
        }
        public List<string> HeaderTexts
        {
            set
            {
                if (dataGridView.DataSource != null)
                {
                    for (int i = 0; i < value.Count; i++)
                    {
                        dataGridView.Columns[i].HeaderText = value[i];
                    }
                }
            }
        }
        public DataGridViewColumnCollection Columns
        {
            get
            {
                return dataGridView.Columns;
            }
        }
        public SearchViewControl()
        {
            InitializeComponent();
        }
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            SearchEvent?.Invoke(this, null);
        }
        private void textBoxSearchTerm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchEvent?.Invoke(this, null);
            }
        }
    }
}
