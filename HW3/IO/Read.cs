using HW3.Exceptions;
using System.Collections.Generic;
using System.IO;

namespace HW3.IO
{
    public static class Read
    {
        public static Dictionary<string, string> UserCredentials(string filename)
        {
            Dictionary<string, string> users = new Dictionary<string, string>();

            try
            {
                using (var fs = new FileStream(filename, FileMode.Open))
                {
                    using (var sr = new StreamReader(fs))
                    {
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();

                            if (string.IsNullOrWhiteSpace(line)) continue;

                            string[] usernamePassword = line.Split("\t");

                            if (users.ContainsKey(usernamePassword[0]))
                            {
                                throw new DuplicateUserCredentialsException();
                            }

                            users.Add(usernamePassword[0], usernamePassword[1]);
                        }
                    }   
                }
            }
            catch (FileNotFoundException ex)
            {
                throw new UsersNotFoundException(ex);
            }

            return users;
        }
    }
}