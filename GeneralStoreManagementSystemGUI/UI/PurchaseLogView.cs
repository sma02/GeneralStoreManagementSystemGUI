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
    public partial class PurchaseLogView : Form
    {
        private uint InvoiceNumber { set => labelInvoiceNumber.Text = value.ToString("D6"); }
        private double InvoiceAmount { set => labelInvoiceAmount.Text = value.ToString("N2"); }
        private string  CashierId { set => labelCashierId.Text = value; }
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
        public PurchaseLogView(PurchaseLog logs)
        {
            InitializeComponent();
            this.logs = logs;
            searchView = new SearchViewControl();
            searchView.SearchEvent += SearchView_SearchEvent;
            searchView.ItemDoubleClick += ViewDetails;
            searchView.SecondButton.Text = "Details";
            searchView.SecondButton.Visible = true;
            searchView.SecondButton.Click += ViewDetails;
            searchView.Visible = true;
            searchView.Dock = DockStyle.Fill;
            searchView.DataSource = logs.GetRecords();
            panelRecord.Visible = false;
            SearchViewAttributeAnnotations();
            Controls.Add(searchView);
        }
        private void SearchViewAttributeAnnotations()
        {
            searchView.HeaderTexts = new List<string> { "Invoice Number", "ID", "Username", "Invoice Amount" };
            DataGridViewColumnCollection columns = searchView.Columns;
            columns["InvoiceNumber"].DefaultCellStyle.Format = "D6";
            columns["InvoiceAmount"].DefaultCellStyle.Format = "N2";
        }
        private void AttributeAnnotations()
        {
            HeaderTexts = new List<string> { "ID", "Name", "Rate", "Tax", "Discount", "Net Price", "Q.ty" };
            DataGridViewColumnCollection columns = dataGridView.Columns;
            columns["ID"].DefaultCellStyle.Format = "D5";
            columns["RetailPrice"].DefaultCellStyle.Format = "N2";
            columns["TaxPercentage"].DefaultCellStyle.Format = "N2";
            columns["DiscountPercentage"].DefaultCellStyle.Format = "N2";
            columns["NetPrice"].DefaultCellStyle.Format = "N2";
        }
        private void ViewDetails(object sender, EventArgs e)
        {
            uint invoiceNumber = uint.Parse(searchView.SelectedItem);
            PurchaseRecord record = logs.GetRecord(invoiceNumber);
            dataGridView.DataSource = record.Cart.GetProducts();
            InvoiceNumber = record.InvoiceNumber;
            InvoiceAmount = record.InvoiceAmount;
            CashierId = record.Cashier.Id;
            AttributeAnnotations();
            panelRecord.Visible = true;
            searchView.Visible = false;
        }
        private void SearchView_SearchEvent(object sender, EventArgs e)
        {
            IEnumerable records = string.IsNullOrWhiteSpace(((SearchViewControl)sender).SearchTerm)
? logs.GetRecords()
: logs.GetRecords(searchView.SearchTerm);
            searchView.DataSource = records;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            searchView.Visible = true;
            panelRecord.Visible = false;
            dataGridView.DataSource = null;
        }
    }
}
