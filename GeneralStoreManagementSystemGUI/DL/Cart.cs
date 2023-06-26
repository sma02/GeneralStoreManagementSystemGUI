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
        public override bool AddProduct(Product product)
        {
            Products.Add(product);
            if (product.Quantity == 0) return false;
            product.Quantity--;
            return true;
        }
        public double CalculateTotal()
        {
            return Math.Ceiling(Products.Sum(x => x.RetailPrice));
        }
    }
}
