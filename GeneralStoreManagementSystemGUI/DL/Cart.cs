using GeneralStoreManagementSystemGUI.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralStoreManagementSystemGUI.DL
{
    public class Cart : ProductList
    {
        public override void AddProduct(Product product)
        {
            Products.Add(product);
            product.Quantity--;
        }
        public double CalculateTotal()
        {
            return Math.Ceiling(Products.Sum(x => x.RetailPrice));
        }
    }
}
