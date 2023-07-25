using GeneralStoreManagementSystemGUI.DL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneralStoreManagementSystemGUI.UI
{
    public partial class ProductView : Form
    {
        public string ItemName { get => textName.Text; }
        public double CostPrice
        {
            get
            {
                double result;
                return double.TryParse(textRate.Text, out result) ? result : 0;
            }
        }
        public double RetailPrice
        {
            get
            {
                double result;
                return double.TryParse(textPrice.Text, out result) ? result : 0;
            }
            set => textPrice.Text = Math.Round(value, 2).ToString();
        }
        public float TaxPercentage { get => (float)numericTaxPercentage.Value; }
        public float ProfitPercentage
        {
            get => (float)numericProfitPercentage.Value; set
            {
                numericProfitPercentage.Value = (decimal)value;
            }
        }
        public float DiscountPercentage { get => (float)numericDiscountPercentage.Value; }
        public uint Quantity { get => uint.Parse(textQuantity.Text); }
        public double NetPrice { set => labelNetPrice.Text = value.ToString(); }
        public float NetProfit { set => labelNetProfit.Text = value.ToString(); }

        private ProductView()
        {
            InitializeComponent();
            searchView = new SearchViewControl();
            searchView.Visible = true;
            searchView.Dock = DockStyle.Fill;
            panelProductData.Visible = false;
            Controls.Add(searchView);
            searchView.FirstButton.Text = "Add";
            searchView.FirstButton.Visible = true;
            searchView.FirstButton.Click += FirstButton_Click;
            searchView.SearchEvent += SearchView_SearchEvent;
            textPrice.KeyPress += DecimalPointFields_KeyPress;
            textRate.KeyPress += DecimalPointFields_KeyPress;
            textQuantity.KeyPress += UnsignedNumberFields_KeyPress;
            AttachTextChangedEvents();
        }

        private void UnsignedNumberFields_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar))
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void DecimalPointFields_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (e.KeyChar == '.' && textBox.Text.Contains('.'))
            {
                e.Handled = true;
            }
            if (char.IsNumber(e.KeyChar) || e.KeyChar == '.')
            {
                if ((Regex.IsMatch(textBox.Text, "^\\d*\\.\\d{2}$") && textBox.SelectionStart > textBox.Text.IndexOf('.'))
                    || (e.KeyChar == '.' && textBox.SelectionStart < textBox.Text.Length - 2))
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void FirstButton_Click(object sender, EventArgs e)
        {
            searchView.Visible = false;
            panelProductData.Visible = true;
        }

        public ProductView(ProductList list) : this()
        {
            this.list = list;
            searchView.DataSource = this.list.GetProducts();
            searchView.HeaderTexts = new List<string> { "ID", "Name", "Rate", "Price", "Tax", "Profit", "Discount", "Net Profit", "Net Price", "Q.ty" };
            DataGridViewColumnCollection columns = searchView.Columns;
            columns["ID"].DefaultCellStyle.Format = "D5";
            columns["CostPrice"].DefaultCellStyle.Format = "N2";
            columns["RetailPrice"].DefaultCellStyle.Format = "N2";
            columns["TaxPercentage"].DefaultCellStyle.Format = "N2";
            columns["ProfitPercentage"].DefaultCellStyle.Format = "N2";
            columns["DiscountPercentage"].DefaultCellStyle.Format = "N2";
            columns["NetProfitPercentage"].DefaultCellStyle.Format = "N2";
            columns["NetPrice"].DefaultCellStyle.Format = "N2";
            //list.AddProduct(new BL.Product(0, "Bread", 20, 5f, 100, 1.5f, 2.5f));
        }
        private void SearchView_AddEvent(object sender, EventArgs e)
        {
            panelProductData.Visible = true;
            searchView.Visible = false;
        }


        private void SearchView_SearchEvent(object sender, EventArgs e)
        {
            IEnumerable products = string.IsNullOrWhiteSpace(((SearchViewControl)sender).SearchTerm)
     ? list.GetProducts()
     : list.GetProducts(searchView.SearchTerm);
            searchView.DataSource = products;
        }
        private void AttachTextChangedEvents()
        {
            textPrice.TextChanged += textPrice_TextChanged;
            numericTaxPercentage.ValueChanged += NumericFields_ValueChanged; ;
            numericProfitPercentage.ValueChanged += NumericFields_ValueChanged;
            textRate.TextChanged += textRate_TextChanged;
        }

        private void NumericFields_ValueChanged(object sender, EventArgs e)
        {
            ((NumericUpDown)sender).ValueChanged -= NumericFields_ValueChanged;
            AdjustRetailPrice();
            ((NumericUpDown)sender).ValueChanged += NumericFields_ValueChanged;
        }

        private void textRate_TextChanged(object sender, EventArgs e)
        {
            if (((Control)sender).Focused)
            {
                AdjustRetailPrice();
            }
        }
        private void textPrice_TextChanged(object sender, EventArgs e)
        {
            if (((Control)sender).Focused)
            {
                AdjustProfitPercentage();
            }
        }
        private void AdjustRetailPrice()
        {
            RetailPrice = CostPrice * (ProfitPercentage + TaxPercentage + 100) / 100;
        }
        private void AdjustProfitPercentage()
        {
            if (CostPrice == 0)
            {
                ProfitPercentage = 0;
            }
            else
            {
                ProfitPercentage = (float)((RetailPrice * 100 / CostPrice) - 100);
            }
        }
        private void AdjustNetProfit()
        {
            NetProfit = ProfitPercentage - DiscountPercentage;
        }

        private void PercentageFields_ValueChanged(object sender, EventArgs e)
        {
            AdjustNetProfit();
        }
    }
}
