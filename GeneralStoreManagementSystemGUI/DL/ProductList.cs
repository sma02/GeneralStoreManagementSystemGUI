﻿
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
    public class ProductList : GenericList
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
        public IEnumerable GetList()
        {
            return Products;
        }
        public IEnumerable GetProducts()
        {
            return Products.Select(x=>x).ToList();
        }
        public IEnumerable GetProducts(string searchTerm)
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
                uint id = uint.Parse(attributes[0]);
                string name = attributes[1];
                double costPrice = double.Parse(attributes[2]);
                float profitPercentage = float.Parse(attributes[3]);
                float taxPercentage = float.Parse(attributes[4]);
                float discountPercentage = float.Parse(attributes[5]);
                int quantity = int.Parse(attributes[6]);
                Products.Add(new Product(id, name, costPrice, profitPercentage, quantity, taxPercentage, discountPercentage));

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

        protected override void ClearList()
        {
            Products.Clear();
        }
    }
}
