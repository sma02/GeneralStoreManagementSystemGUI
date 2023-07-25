﻿using GeneralStoreManagementSystemGUI.BL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralStoreManagementSystemGUI.DL
{
    public class Cart : ProductList
    {
        private ProductList list;
        public Cart(ProductList list):base()
        {
            this.list = list;
        }
        public void AddProduct(Product product, uint quantity)
        {
            if (product == null)
            {
                throw new Exception("Item ID not Found");
            }
            else if (quantity == 0)
            {
                throw new Exception("Quantity cannot be 0");
            }
            Product item;
            if (GetProduct(product.Id) == null)
            {
                if (quantity > product.Quantity)
                {
                    throw new Exception("Not enough stock (Requested: " + quantity + " Available: " + product.Quantity);
                }
                item = new Product(product);
                item.Quantity = quantity;
                item.NetPrice = product.NetPrice * quantity;
                Products.Add(item);
            }
            else
            {

                item = GetProduct(product.Id);
                if (quantity > product.Quantity)
                {
                    throw new Exception("Not enough stock (Requested: " + (item.Quantity + quantity) + " Available: " + product.Quantity);
                }
                item.Quantity += quantity;
                item.NetPrice = product.NetPrice * item.Quantity;
            }
            product.Quantity -= quantity;
            UpdateDataEvent();
        }
        public void UpdateQuantity(Product item, uint quantity)
        {
            Product product = list.GetProduct(item.Id);
            item.Quantity = quantity;
            item.NetPrice = product.NetPrice * item.Quantity;
        }
        public override void AddProduct(Product product)
        {
            AddProduct(product, 1);
        }
        public override void RemoveProduct(Product item)
        {
            list.GetProduct(item.Id).Quantity += item.Quantity;
            Products.Remove(item);
            UpdateDataEvent();
        }
        public override IEnumerable GetProducts()
        {
            if (Products.Count == 0)
            {
                return null;
            }
            return Products.Select(x => new { x.Id, x.Name, x.RetailPrice, x.TaxPercentage, x.DiscountPercentage, x.NetPrice, x.Quantity }).ToList();
        }
        public double CalculateTotal()
        {
            return Math.Ceiling(Products.Sum(x => x.RetailPrice));
        }
    }
}
