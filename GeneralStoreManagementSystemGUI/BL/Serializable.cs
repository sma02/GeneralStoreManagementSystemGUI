using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralStoreManagementSystemGUI.BL
{
    public abstract class Serializable
    {
        public abstract string ToString(string separator);
        public string ToCSV()
        {
            return ToString(",");
        }
    }
}
