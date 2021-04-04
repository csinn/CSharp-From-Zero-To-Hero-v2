using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3.IO
{
    public static class Write
    {
        public static void AppendCredentials(string filename, string username, string password)
        {
            using (var fs = new FileStream(filename, FileMode.Append))
            {
                using (var sw = new StreamWriter(fs))
                {
                    sw.WriteLine($"{username}\t{password}");
                }
            }
        }
    }
}
