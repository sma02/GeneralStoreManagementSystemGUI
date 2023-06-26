using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralStoreManagementSystemGUI.BL
{
    public class Admin : User
    {
        public Admin(string username, string password) : base(username, password)
        {

        }
        public Admin(User user) : base(user)
        {

        }
        public override string ToString(string separator)
        {
            return base.ToString(separator) + separator + GetType().Name;
        }
    }
}
