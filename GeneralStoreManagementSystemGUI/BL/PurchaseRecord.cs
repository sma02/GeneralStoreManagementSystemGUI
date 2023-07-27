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
        private List<uint> itemsIds;

        public uint InvoiceNumber { get => invoiceNumber; set => invoiceNumber = value; }
        public Cashier Cashier { get => cashier; set => cashier = value; }
        public double InvoiceAmount { get => invoiceAmount; set => invoiceAmount = value; }
        public List<uint> ItemsIds { get => itemsIds; set => itemsIds = value; }

        private string ItemsIdsString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach(uint id  in ItemsIds)
            {
                stringBuilder.Append(id.ToString()+",");
            }
            stringBuilder.Remove(stringBuilder.Length - 1,1);
            return stringBuilder.ToString();
        }
        public override string ToString(string separator)
        {
            return string.Format("{0}{4}{1}{4}{2}{4}{3}", InvoiceNumber, Cashier.Id, InvoiceAmount,ItemsIdsString(),separator);
        }
    }
}
