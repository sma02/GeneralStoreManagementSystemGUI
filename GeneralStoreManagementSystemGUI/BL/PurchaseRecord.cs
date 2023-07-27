using GeneralStoreManagementSystemGUI.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralStoreManagementSystemGUI.BL
{
    public class PurchaseRecord : Serializable
    {
        private uint invoiceNumber;
        private Cashier cashier;
        private double invoiceAmount;
        private Cart cart;

        public uint InvoiceNumber { get => invoiceNumber; set => invoiceNumber = value; }
        public Cashier Cashier { get => cashier; set => cashier = value; }
        public double InvoiceAmount { get => invoiceAmount; set => invoiceAmount = value; }
        public Cart Cart { get => cart; set => cart = value; }

        public PurchaseRecord(uint invoiceNumber,Cashier cashier,ProductList list):this(invoiceNumber,cashier,list,new Cart(list))
        {
        }
        public PurchaseRecord(uint invoiceNumber, Cashier cashier, ProductList list, Cart cart)
        {
            InvoiceNumber = invoiceNumber;
            Cashier = cashier;
            this.cart = cart;
            InvoiceAmount = cart.CalculateTotal();
        }
        public override string ToString(string separator)
        {
            return string.Format("{0}{3}{1}{3}{2}", InvoiceNumber, Cashier.Id,cart.ToString(),separator);
        }
    }
}
