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
    public class PurchaseLog : GenericList
    {
        private List<PurchaseRecord> records;
        private ProductList productList;
        private UserList userList;
        public PurchaseLog(string databasePath,ProductList productList,UserList userList) : base(databasePath)
        {
            this.productList = productList;
            this.userList = userList;
            records = new List<PurchaseRecord>();
        }
        public uint GetInvoiceNumber()
        {
            return (uint)records.Count;
        }
        public void AddRecord(PurchaseRecord record)
        {
            records.Add(record);
            StoreData();
        }
        private static IEnumerable SelectAttributes(List<PurchaseRecord> records)
        {
            return records.Select(x => new { x.InvoiceNumber, x.Cashier.Id, x.Cashier.Username, x.InvoiceAmount }).ToList();
        }
        public IEnumerable GetRecords()
        {
            return SelectAttributes(records);
        }
        public IEnumerable GetRecords(string searchTerm)
        {
            List<PurchaseRecord> purchaseRecords = records.FindAll(x => x.InvoiceNumber.ToString() == searchTerm || x.Cashier.Id.ToString().Contains(searchTerm) || x.Cashier.Username.Contains(searchTerm)).ToList();
            return SelectAttributes(purchaseRecords);
        }
        public PurchaseRecord GetRecord(uint invoiceNumber)
        {
            return records.Find(x => x.InvoiceNumber == invoiceNumber);
        }
        protected override void ClearList()
        {
            records.Clear();
        }


        protected override void FromCSV(string data)
        {
            if (data == null) return;
            StringReader stream = new StringReader(data);
            string line;
            string[] attributes;
            while ((line = stream.ReadLine()) != null)
            {
                attributes = line.Split(',');
                uint invoiceNumber = uint.Parse(attributes[0]);
                string cashierId = attributes[1];
                Cashier cashier = (Cashier)userList.GetUserById(cashierId);
                PurchaseRecord record = new PurchaseRecord(invoiceNumber, cashier,productList);
                attributes = attributes[2].Split(';');
                foreach(string attribute in attributes)
                {
                    string[] values = attribute.Split(':');
                    uint id = uint.Parse(values[0]);
                    uint quantity = uint.Parse(values[1]);
                    record.Cart.AddProduct(id, quantity);
                }
                record.InvoiceAmount = record.Cart.CalculateTotal();
                records.Add(record);
            }
        }

        protected override string ToCSV()
        {
            StringWriter stream = new StringWriter();
            foreach (PurchaseRecord record in records)
            {
                stream.WriteLine(record.ToCSV());
            }
            stream.Close();
            return stream.ToString();
        }
    }
}
