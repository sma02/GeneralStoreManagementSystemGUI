using GeneralStoreManagementSystemGUI.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralStoreManagementSystemGUI.DL
{
    public abstract class GenericList
    {
        private readonly string databasePath;
        public event EventHandler DataUpdated;
        protected GenericList(string databasePath)
        {
            this.databasePath = databasePath;
        }

        protected GenericList()
        {
            databasePath = null;
        }
        public void StoreData()
        {
            if (databasePath != null)
            {
                FileHandler.Store(ToCSV(), databasePath);
            }
        }
        public void LoadData()
        {
            if (databasePath != null)
            {
                ClearList();
                FromCSV(FileHandler.Load(databasePath));
            }
        }
        public void UpdateDataEvent()
        {
            DataUpdated?.Invoke(this, null);
        }
        protected abstract void FromCSV(string data);
        protected abstract string ToCSV();
        protected abstract void ClearList();
    }
}
