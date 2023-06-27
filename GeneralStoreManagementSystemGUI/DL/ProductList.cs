
using GeneralStoreManagementSystemGUI.BL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralStoreManagementSystemGUI.DL
{
    public class ProductList : GenericList , IProductList
    {
        protected readonly List<Product> Products;
        public ProductList(string databasePath) : base(databasePath)
        {
            Products = new List<Product>();
        }
        public ProductList()
        {
            Products = new List<Product>();
        }
        public  IEnumerable GetList()
        {
            return Products;
        }
        public IEnumerable GetList(string searchTerm)
        {
            return Products.FindAll(x => x.Name.Contains(searchTerm));
        }
        public bool IsExists(string productName)
        {
            return Products.Exists(x => x.Name == productName);
        }
        public Product GetProduct(string productName)
        {
            return Products.Find(x => x.Name == productName);
        }
        public virtual void AddProduct(Product product)
        {
            Products.Add(product);
            StoreData();
        }
        public void RemoveProduct(string productName)
        {
                Products.RemoveAll(x => x.Name == productName);
                StoreData();
        }

        protected override void FromCSV(string data)
        {
            StringReader stream = new StringReader(data);
            string line;
            while ((line = stream.ReadLine()) != null)
            {
                string[] attributes = line.Split(',');
                string name = attributes[0];
                double costPrice = double.Parse(attributes[1]);
                float profitPercentage = float.Parse(attributes[2]);
                int quantity = int.Parse(attributes[3]);
                Products.Add(new Product(name, costPrice, profitPercentage, quantity));

            }
        }

        protected override string ToCSV()
        {
            StringWriter stream = new StringWriter();
            foreach (Product product in Products)
            {
                stream.WriteLine(product.ToCSV());
            }
            stream.Close();
            return stream.ToString();
        }
    }
}
