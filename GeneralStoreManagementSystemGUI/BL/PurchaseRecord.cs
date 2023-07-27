using GeneralStoreManagementSystemGUI.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralStoreManagementSystemGUI.BL
{
    class PurchaseRecord : Serializable
    {
        private uint invoiceNumber;
        private Cashier cashier;
        private double invoiceAmount;
        private Cart cart;

        public uint InvoiceNumber { get => invoiceNumber; set => invoiceNumber = value; }
        public Cashier Cashier { get => cashier; set => cashier = value; }
        public double InvoiceAmount { get => invoiceAmount; set => invoiceAmount = value; }
        public Cart Cart { get => cart; set => cart = value; }

        public PurchaseRecord(uint invoiceNumber,Cashier cashier,double invoiceAmount,ProductList list)
        {
            InvoiceNumber = invoiceNumber;
            Cashier = cashier;
            InvoiceAmount = invoiceAmount;
            cart = new Cart(list);
        }
        public override string ToString(string separator)
        {
            return string.Format("{0}{4}{1}{4}{2}{4}{3}", InvoiceNumber, Cashier.Id, InvoiceAmount,cart.ToString(),separator);
        }
    }
}
