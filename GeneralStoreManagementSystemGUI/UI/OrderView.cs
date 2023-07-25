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
    public partial class OrderView : Form
    {
        public object DataSource { set => dataGridView.DataSource = value; }
        public int SelectedItem
        {
            get
            {
                if(dataGridView.SelectedRows.Count>0)
                {
                    return int.Parse(dataGridView.SelectedRows[0].Cells[0].Value.ToString());
                }
                else
                {
                    return -1;
                }
            }
        }
        public uint Id { get => uint.Parse(textId.Text); set => textId.Text = value.ToString(); }
        public uint Quantity { get => uint.Parse(textQuantity.Text); set => textQuantity.Text = value.ToString(); }
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
        private Cart cart;
        public OrderView(ProductList list)
        {
            InitializeComponent();
            this.list = list;
            cart = new Cart(list);
            cart.DataUpdated += Cart_DataUpdated;
            textId.KeyPress += UnsignedNumberField_KeyPress;
            textQuantity.KeyPress += UnsignedNumberField_KeyPress;
        }

        private void UnsignedNumberField_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar))
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        public void AnnotateDataAttributes()
        {
            HeaderTexts = new List<string> { "ID", "Name", "Rate", "Tax", "Discount", "Net Price", "Q.ty" };
            DataGridViewColumnCollection columns = dataGridView.Columns;
            columns["ID"].DefaultCellStyle.Format = "D5";
            columns["RetailPrice"].DefaultCellStyle.Format = "N2";
            columns["TaxPercentage"].DefaultCellStyle.Format = "N2";
            columns["DiscountPercentage"].DefaultCellStyle.Format = "N2";
            columns["NetPrice"].DefaultCellStyle.Format = "N2";
        }
        private void Cart_DataUpdated(object sender, EventArgs e)
        {
            DataSource = cart.GetProducts();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                bool flag = false;
                if (dataGridView.Columns.Count == 0)
                {
                    flag = true;
                }
                cart.AddProduct(list.GetProduct(Id), Quantity);
                if (flag)
                {
                    AnnotateDataAttributes();
                }
                dataGridView.Rows[dataGridView.Rows.Count-1].Selected = true;
            }
            catch(FormatException)
            {
                CustomMessageBox.Show("Invalid format");
            }
            catch(Exception ex)
            {
                CustomMessageBox.Show(ex.Message);
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (SelectedItem != -1)
            {
                Product product = cart.GetProduct((uint)SelectedItem);
                cart.RemoveProduct(product);
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if(SelectedItem!=-1)
            {
                Product product = cart.GetProduct((uint)SelectedItem);
                cart.UpdateQuantity(product, Quantity);
                int index =  dataGridView.SelectedRows[0].Index;
                cart.UpdateDataEvent();
                dataGridView.Rows[index].Selected = true;
            }
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (SelectedItem != -1)
            {
                Id = (uint)SelectedItem;
                Quantity = cart.GetProduct(Id).Quantity;
            }
        }
    }
}
