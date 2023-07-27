using GeneralStoreManagementSystemGUI.BL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralStoreManagementSystemGUI.DL
{
    class PurchaseLog : GenericList
    {
        private List<PurchaseRecord> records;
        private Database database;
        public PurchaseLog(string databasePath,Database database) : base(databasePath)
        {
            this.database = database;
            records = new List<PurchaseRecord>();
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
                double invoiceAmount = double.Parse(attributes[2]);
                Cashier cashier = (Cashier)database.UserList.GetUserById(cashierId);
                PurchaseRecord record = new PurchaseRecord(invoiceNumber, cashier, invoiceAmount, database.ProductList);
                attributes = attributes[3].Split(';');
                foreach(string attribute in attributes)
                {
                    string[] values = attribute.Split(':');
                    uint id = uint.Parse(values[0]);
                    uint quantity = uint.Parse(values[1]);
                    record.Cart.AddProduct(id, quantity);
                }
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
