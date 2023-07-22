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
        private ProductView()
        {
            InitializeComponent();
            searchView = new SearchViewControl();
            searchView.Visible = true;
            searchView.Dock = DockStyle.Fill;
            panelProductData.Visible = false;
            Controls.Add(searchView);
            searchView.SearchEvent += SearchView_SearchEvent;
            searchView.AddEvent += SearchView_AddEvent;
        }
        public ProductView(ProductList list) : this()
        {
            this.list = list;
            this.list.LoadData();
            searchView.DataSource = this.list.GetProducts();
            searchView.HeaderTexts = new List<string> { "ID", "Name", "Cost","Actual","Tax","Profit","Discount","Net Profit","Net Price","Q.ty" };
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
