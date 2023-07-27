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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneralStoreManagementSystemGUI.UI
{
    public partial class ProductView : Form
    {
        public uint Id { get => uint.Parse(maskedID.Text); set => maskedID.Text = value.ToString("D5"); }
        public string ItemName { get => textName.Text; set => textName.Text = value; }
        public double CostPrice { get => double.TryParse(textRate.Text, out double result) ? result : 0; set => textRate.Text = value.ToString(); }
        public double RetailPrice
        {
            get => double.TryParse(textPrice.Text, out double result) ? result : 0;
            set => textPrice.Text = Math.Round(value, 2).ToString("#0.00");
        }
        public float TaxPercentage { get => (float)numericTaxPercentage.Value; set => numericTaxPercentage.Value = (decimal)value; }
        public float ProfitPercentage
        {
            get => (float)numericProfitPercentage.Value;
            set
            {
                numericProfitPercentage.Value = (decimal)value;
            }
        }
        public float DiscountPercentage { get => (float)numericDiscountPercentage.Value; set => numericDiscountPercentage.Value = (decimal)value; }
        public uint Quantity { get => uint.Parse(textQuantity.Text); set => textQuantity.Text = value.ToString(); }
        public double NetPrice { set => labelNetPrice.Text = value.ToString(); }
        public float NetProfit { set => labelNetProfit.Text = value.ToString(); }
        private bool isEdit;
        public ProductView(ProductList list)
        {
            InitializeComponent();
            searchView = new SearchViewControl
            {
                Visible = true,
                Dock = DockStyle.Fill
            };
            isEdit = false;
            this.list = list;
            searchView.DataSource = this.list.GetProducts();
            SearchViewAttributeAnnotations();
            list.DataUpdated += DataUpdateHandler;
            panelProductData.Visible = false;
            Controls.Add(searchView);
            searchView.FirstButton.Text = "Add";
            searchView.FirstButton.Visible = true;
            searchView.FirstButton.Click += AddProductButton_Click;
            searchView.SecondButton.Text = "Edit";
            searchView.SecondButton.Visible = true;
            searchView.SecondButton.Click += EditProductButton_Click;
            searchView.ThirdButton.Text = "Delete";
            searchView.ThirdButton.Visible = true;
            searchView.ThirdButton.Click += RemoveProductButton_Click;
            searchView.ItemDoubleClick += SearchView_ItemDoubleClick;
            searchView.SearchEvent += SearchView_SearchEvent;
            textPrice.KeyPress += DecimalPointFields_KeyPress;
            textRate.KeyPress += DecimalPointFields_KeyPress;
            textQuantity.KeyPress += UnsignedNumberFields_KeyPress;
            AttachRetailPriceChangeTriggers();
            AttachNetPriceTriggers();
        }

        private void SearchView_ItemDoubleClick(object sender, EventArgs e)
        {
            EditProductButton_Click(sender, e);
        }

        private void SearchViewAttributeAnnotations()
        {
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
        }
        private void RemoveProductButton_Click(object sender, EventArgs e)
        {
            Product product = list.GetProduct(uint.Parse(searchView.SelectedItem));
            DialogResult result = CustomMessageBox.Show("Are you sure you want to Delete This Product?", "Confirmation", CustomMessageBox.Type.YesNo);
            if (result == DialogResult.Yes)
            {
                list.RemoveProduct(product);
            }
        }

        private void EditProductButton_Click(object sender, EventArgs e)
        {
            searchView.Visible = false;
            panelProductData.Visible = true;
            uint id = uint.Parse(searchView.SelectedItem);
            Product product = list.GetProduct(id);
            Id = product.Id;
            ItemName = product.Name;
            CostPrice = product.CostPrice;
            TaxPercentage = product.TaxPercentage;
            ProfitPercentage = product.ProfitPercentage;
            DiscountPercentage = product.DiscountPercentage;
            Quantity = product.Quantity;
            isEdit = true;
        }

        private void DataUpdateHandler(object sender, EventArgs e)
        {
            searchView.DataSource = list.GetProducts();
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

        private void AddProductButton_Click(object sender, EventArgs e)
        {
            searchView.Visible = false;
            panelProductData.Visible = true;
            isEdit = false;
        }

        private void SearchView_AddEvent(object sender, EventArgs e)
        {
            HideSearchView();
        }
        private void ShowSearchView()
        {
            panelProductData.Visible = false;
            searchView.Visible = true;
        }
        private void HideSearchView()
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
        private void AttachRetailPriceChangeTriggers()
        {
            textPrice.TextChanged += ProfitPercentageChangeTriggered;
            numericTaxPercentage.ValueChanged += NumericFields_ValueChanged;
            numericProfitPercentage.ValueChanged += NumericFields_ValueChanged;
            textRate.TextChanged += TextRate_TextChanged;
        }

        private void NumericFields_ValueChanged(object sender, EventArgs e)
        {
            ((NumericUpDown)sender).ValueChanged -= NumericFields_ValueChanged;
            AdjustRetailPrice();
            ((NumericUpDown)sender).ValueChanged += NumericFields_ValueChanged;
        }

        private void TextRate_TextChanged(object sender, EventArgs e)
        {
            if (((Control)sender).Focused)
            {
                AdjustRetailPrice();
            }
        }
        private void ProfitPercentageChangeTriggered(object sender, EventArgs e)
        {
            numericProfitPercentage.ValueChanged -= NumericFields_ValueChanged;
            if (((Control)sender).Focused)
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
            numericProfitPercentage.ValueChanged += NumericFields_ValueChanged;
        }
        private void AdjustRetailPrice()
        {
            RetailPrice = Math.Round(CostPrice * (ProfitPercentage + TaxPercentage + 100) / 100, 2);
        }
        private void AttachNetPriceTriggers()
        {
            textPrice.TextChanged += NetPriceChangeTriggered;
            numericDiscountPercentage.ValueChanged += NetPriceChangeTriggered;
        }
        private void NetPriceChangeTriggered(object sender, EventArgs e)
        {
            NetPrice = Math.Round((CostPrice * (100 + ProfitPercentage + TaxPercentage - DiscountPercentage)) / 100, 2);
        }
        private void NetProfitChangeTriggered(object sender, EventArgs e)
        {
            NetProfit = ProfitPercentage - DiscountPercentage;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                Product product = new Product(Id, ItemName, CostPrice, ProfitPercentage, Quantity, TaxPercentage, DiscountPercentage);
                if (isEdit)
                {
                    uint oldId = uint.Parse(searchView.SelectedItem);
                    list.ReplaceProduct(list.GetProduct(oldId), product);
                    CustomMessageBox.Show("Product Edited Successfully");
                }
                else
                {
                    list.AddProduct(product);
                    CustomMessageBox.Show("Product Added Successfully");
                }
                ShowSearchView();
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show(ex.Message);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            searchView.Visible = true;
            panelProductData.Visible = false;
        }
    }
}
