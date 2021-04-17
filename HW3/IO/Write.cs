using System;
using System.IO;

namespace HW3.IO
{
    public static class Write
    {
        public static void AppendCredentials(string filename, string username, string password)
        {
            bool newLineReq = !EndsWithNewLine(filename);

            using (var fs = new FileStream(filename, FileMode.Append))
            {
                using (var sw = new StreamWriter(fs))
                {
                    if (newLineReq)
                    {
                        sw.Write(Environment.NewLine);
                    }

                    sw.WriteLine($"{username}\t{password}");
                }
            }
        }

        private static bool EndsWithNewLine(string filename)
        {
            using (var fs = new FileStream(filename, FileMode.Open))
            {
                using (var sr = new StreamReader(fs))
                {
                    var contents = sr.ReadToEnd();

                    return contents.EndsWith(Environment.NewLine);
                }
            }
        }
    }
}