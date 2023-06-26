
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralStoreManagementSystemGUI.BL
{
    public class Cashier : User
    {
        private readonly int performance;
        public Cashier(string username, string password, int performance = 0) : base(username, password)
        {
            this.performance = performance;
        }
        public Cashier(User user) : base(user)
        {
            performance = 0;
        }
        public override string ToString(string separator)
        {
            return base.ToString(separator) + separator + performance + separator + GetType().Name;
        }
    }
}
