using System;
using System.IO;

namespace HW3.IO
{
    public static class Write
    {
        public static void AppendCredentials(string filename, string username, string password)
        {
            CheckForNewLine(filename);

            using (var fs = new FileStream(filename, FileMode.Append))
            {
                using (var sw = new StreamWriter(fs))
                {
                    sw.WriteLine($"{username}\t{password}");
                }
            }
        }

        private static void CheckForNewLine(string filename)
        {
            string contents;

            using (var fs = new FileStream(filename, FileMode.Open))
            {
                var sr = new StreamReader(fs);
                contents = sr.ReadToEnd();

                if (!contents.EndsWith(Environment.NewLine))
                {
                    var sw = new StreamWriter(fs);
                    sw.Write(Environment.NewLine);
                    sw.Flush();
                }
            }
        }
    }
}