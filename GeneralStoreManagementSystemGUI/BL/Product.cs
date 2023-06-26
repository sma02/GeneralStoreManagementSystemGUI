
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralStoreManagementSystemGUI.BL
{
    public class Product : Serializable
    {
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
        private string name;
        private double costPrice;
        private double retailPrice;
        private float profitPercentage;
        private int quantity;
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

        public override string ToString(string separator)
        {
            return name + separator + costPrice + separator + profitPercentage + separator + quantity;
        }
        private void CalculateRetailPrice()
        {
            retailPrice = costPrice * (100 + profitPercentage) / 100;
        }
        private void CalculateProfitPercentage()
        {
            profitPercentage = (float)(retailPrice * 100 / costPrice) - 100;
        }
    }
}
