
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralStoreManagementSystemGUI.BL
{
    public class Product : Serializable
    {
        private string name;
        private double costPrice;
        private double retailPrice;
        private float taxPercentage;
        private float discountPercentage;
        private float profitPercentage;
        private int quantity;
        public Product(string name, double costPrice, float profitPercentage, int quantity)
        {
            Name = name;
            CostPrice = costPrice;
            ProfitPercentage = profitPercentage;
            Quantity = quantity;
        }
        public Product(string name, double costPrice, double retailPrice, int quantity)
        {
            Name = name;
            CostPrice = costPrice;
            RetailPrice = retailPrice;
            Quantity = quantity;
        }
        public string Name { get => name; set => name = value; }
        public double CostPrice
        {
            get => costPrice;
            set
            {
                costPrice = Math.Abs(value);
                CalculateRetailPrice();
            }

        }
        public float ProfitPercentage
        {
            get => (float)Math.Round(profitPercentage, 2);
            set
            {
                profitPercentage = Math.Abs(value);
                CalculateRetailPrice();
            }
        }
        public double RetailPrice
        {
            get => Math.Round(retailPrice, 2);
            set
            {
                retailPrice = Math.Abs(value);
                CalculateProfitPercentage();
            }
        }

        public int Quantity
        {
            get => quantity;
            set => quantity = Math.Abs(value);
        }

        public float TaxPercentage
        {
            get => taxPercentage;
            set
            {
                taxPercentage = value;
                CalculateRetailPrice();
            }
        }

        public float DiscountPercentage
        {
            get => discountPercentage;
            set
            {
                discountPercentage = value;
                CalculateRetailPrice();
            }
        }

        public override string ToString(string separator)
        {
            return string.Format("{0}{6}{1}{6}{2}{6}{3}{6}{4}{6}{5}",
                name,
                costPrice,
                profitPercentage,
                discountPercentage,
                taxPercentage,
                quantity,
                separator);
        }
        private void CalculateRetailPrice()
        {
            retailPrice = (costPrice * (100 + profitPercentage - discountPercentage + taxPercentage) / 100);
        }
        private void CalculateProfitPercentage()
        {
            profitPercentage = (float)(retailPrice * 100 / costPrice) - 100;
        }
    }
}
