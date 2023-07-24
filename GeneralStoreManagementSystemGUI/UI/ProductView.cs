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
    public partial class ProductView : Form
    {
        public string ItemName { get => textName.Text; }
        public double CostPrice { get => double.Parse(textRatePrice.Text); }
        public double RetailPrice { get => double.Parse(textPrice.Text); }
        public float TaxPercentage { get => (float)numericTaxPercentage.Value; }
        public float DiscountPercentage { get => (float)numericTaxPercentage.Value; }
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
            searchView.HeaderTexts = new List<string> { "ID", "Name", "Rate","Price","Tax","Profit","Discount","Net Profit","Net Price","Q.ty" };
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
    }
}
