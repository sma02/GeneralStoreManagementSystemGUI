using GeneralStoreManagementSystemGUI.BL;
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
    public partial class OrderView : Form
    {
        private Cart cart;
        public object DataSource { set => dataGridView.DataSource = value; }
        private bool orderProcessed;
        public int SelectedItem
        {
            get
            {
                if (dataGridView.SelectedRows.Count > 0)
                {
                    return int.Parse(dataGridView.SelectedRows[0].Cells[0].Value.ToString());
                }
                else
                {
                    return -1;
                }
            }
        }
        public double TotalSaved { set => labelSave.Text = "Saved = " + value.ToString() + "Rs"; }
        public double Total { set => labelTotal.Text = "Total = " + value.ToString() + "Rs"; }
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
        public OrderView(Database database)
        {
            InitializeComponent();
            list = database.ProductList;
            purchaseLog = database.PurchaseLog;
            CurrentCashier = (Cashier)database.CurrentUser;
            cart = new Cart(list);
            cart.DataUpdated += Cart_DataUpdated;
            textId.KeyPress += UnsignedNumberField_KeyPress;
            textQuantity.KeyPress += UnsignedNumberField_KeyPress;
            cart.DataChanged += Cart_DataChanged;
            searchView = new SearchViewControl();
            searchView.DataSource = list.GetProducts(typeof(Cashier));
            AnnotateDataAttributes(searchView.Columns);
            List<string> headerTexts = HeaderTexts = new List<string> { "ID", "Name", "Rate", "Tax", "Discount", "Q.ty", "Net Price" };
            HeaderTexts = headerTexts;
            searchView.HeaderTexts = headerTexts;
            searchView.SearchEvent += SearchView_SearchEvent;
            searchView.ItemDoubleClick += SearchView_ItemDoubleClick;
            searchView.Visible = false;
            searchView.Dock = DockStyle.Fill;
            Controls.Add(searchView);
            orderProcessed = false;
        }

        private void SearchView_ItemDoubleClick(object sender, EventArgs e)
        {
            Id = uint.Parse(searchView.SelectedItem);
            PanelOrderView.Visible = true;
            searchView.Visible = false;
            textQuantity.Focus();
        }

        private void SearchView_SearchEvent(object sender, EventArgs e)
        {
            IEnumerable products = string.IsNullOrWhiteSpace(((SearchViewControl)sender).SearchTerm)
? list.GetProducts(typeof(Cashier))
: list.GetProducts(searchView.SearchTerm, typeof(Cashier));
            searchView.DataSource = products;
        }

        private void Cart_DataChanged(object sender, EventArgs e)
        {
            Total = cart.CalculateTotal();
            TotalSaved = cart.CalculateTotalSaved();
        }

        private void UnsignedNumberField_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar))
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }
        public void AnnotateDataAttributes(DataGridViewColumnCollection columns)
        {
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

        private void Add_Entry(object sender, EventArgs e)
        {
            try
            {
                dataGridView.SelectionChanged -= dataGridView_SelectionChanged;
                bool flag = false;
                if (dataGridView.Columns.Count == 0)
                {
                    flag = true;
                }
                cart.AddProduct(list.GetProduct(Id), Quantity);
                if (flag)
                {
                    HeaderTexts = new List<string> { "ID", "Name", "Rate", "Tax", "Discount", "Q.ty", "Net Price" };
                    AnnotateDataAttributes(dataGridView.Columns);
                }
                dataGridView.Rows[dataGridView.Rows.Count - 1].Selected = true;
                dataGridView.SelectionChanged += dataGridView_SelectionChanged;
            }
            catch (FormatException)
            {
                CustomMessageBox.Show("Invalid format");
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show(ex.Message);
            }
            textQuantity.Focus();
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
            if (SelectedItem != -1)
            {
                Product product = cart.GetProduct((uint)SelectedItem);
                cart.UpdateQuantity(product, Quantity);
                int index = dataGridView.SelectedRows[0].Index;
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

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            dataGridView.Enabled = false;
            orderProcessed = true;
            dataGridView.DefaultCellStyle.BackColor = Color.FromArgb(10);
            dataGridView.ClearSelection();
            PurchaseRecord record = new PurchaseRecord(purchaseLog.GetInvoiceNumber(), CurrentCashier, list, cart);
            purchaseLog.AddRecord(record);
            list.StoreData();
            searchView.DataSource = list.GetProducts(typeof(Cashier));

        }
        private void buttonNewOrder_Click(object sender, EventArgs e)
        {
            if (orderProcessed)
            {
                cart.Clear();
            }
            else
            {
                cart.RevertOrder();
            }
            dataGridView.Enabled = true;
        }
        private void textQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Add_Entry(sender, e);
            }
        }
        private void textId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textQuantity.Focus();
            }
        }
        private void OrderView_Load(object sender, EventArgs e)
        {
            textId.Focus();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            searchView.Visible = true;
            PanelOrderView.Visible = false;
        }
    }
}
