
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralStoreManagementSystemGUI.BL
{
    public class Product : Serializable
    {
        private uint id;
        private string name;
        private double costPrice;
        private float taxPercentage;
        private float discountPercentage;
        private float profitPercentage;
        private float netProfitPercentage;
        private double retailPrice;
        private double netPrice;
        private uint quantity;
        private Product(uint id, string name, double costPrice,uint quantity,float taxPercentage,float discountPercentage)
        {
            Id = id;
            Name = name;
            CostPrice = costPrice;
            Quantity = quantity;
            TaxPercentage = taxPercentage;
            DiscountPercentage = discountPercentage;
        }
        public Product(uint id, string name, double costPrice, float profitPercentage, uint quantity, float taxPercentage = 0, float discountPercentage = 0) : this(id, name, costPrice,quantity,taxPercentage,discountPercentage)
        {
            ProfitPercentage = profitPercentage;
        }
        public Product(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            CostPrice = product.CostPrice;
            ProfitPercentage = product.ProfitPercentage;
            Quantity = product.Quantity;
            TaxPercentage = product.TaxPercentage;
            DiscountPercentage = product.DiscountPercentage;
        }
        public Product(uint id, string name, double costPrice, double retailPrice, uint quantity, float taxPercentage = 0, float discountPercentage = 0) : this(id, name, costPrice,quantity,taxPercentage,discountPercentage)
        {
            RetailPrice = retailPrice;
        }
        public uint Id { get => id; set => id = value; }
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
        public double RetailPrice
        {
            get => Math.Round(retailPrice, 2);
            set
            {
                retailPrice = Math.Abs(value);
                CalculateProfitPercentage();
            }
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
        public float ProfitPercentage
        {
            get => (float)Math.Round(profitPercentage, 2);
            set
            {
                profitPercentage = Math.Abs(value);
                CalculateNetProfit();
                CalculateRetailPrice();
            }
        }
        public float DiscountPercentage
        {
            get => discountPercentage;
            set
            {
                discountPercentage = value;
                CalculateNetProfit();
                CalculateRetailPrice();
            }
        }
        public float NetProfitPercentage { get => netProfitPercentage; }
        public double NetPrice { get => netPrice; set => netPrice = value; }
        public uint Quantity
        {
            get => quantity;
            set => quantity = value;
        }

        public override string ToString(string separator)
        {
            return string.Format("{0}{7}{1}{7}{2}{7}{3}{7}{4}{7}{5}{7}{6}",
                id,
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
            retailPrice = (costPrice * (100 + profitPercentage + taxPercentage) / 100);
            CalculatNetPrice();
        }
        private void CalculateProfitPercentage()
        {
            profitPercentage = (float)(retailPrice * 100 / costPrice) - 100;
            CalculateNetProfit();
        }
        private void CalculateNetProfit()
        {
            netProfitPercentage = profitPercentage - discountPercentage;
        }
        private void CalculatNetPrice()
        {
            netPrice = (retailPrice * (100 - discountPercentage)) / 100;
        }
    }
}
