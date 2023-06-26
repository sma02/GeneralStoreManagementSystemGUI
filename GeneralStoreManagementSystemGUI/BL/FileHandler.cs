using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralStoreManagementSystemGUI.BL
{
    public static class FileHandler
    {
        public static void Store(string data, string path)
        {
            File.WriteAllText(path, data);
        }
        public static string Load(string path)
        {
            return File.Exists(path) ? File.ReadAllText(path) : null;
        }
    }
}
