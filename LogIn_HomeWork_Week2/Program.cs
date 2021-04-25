using System;

namespace LogIn_HomeWork_Week2
{
    class Program
    {
        public static string[] UserNames = new string[] {"CrowBar", "MasterOgre", "redClown", "bLLoom"};
        public static string[] PassWords = new string[] {"1234", "meNace", "mYworld", "forwarDash"};
        static void Main(string[] args)
        {
            string[] userInfo = GetUserInfo();
            VerifyUserInfo(userInfo);
            
        }

        static string[] GetUserInfo()
        {
            var info = new string[2];

            Console.Write("Enter Your\nUser Name: ");
            info[0] = Console.ReadLine();

            Console.Write("Enter Your\nPassword: ");   
            info[1] = Console.ReadLine();

            return info;

        }

        static void VerifyUserInfo(string[] info)
        {
            for (int i = 0; i < UserNames.Length; i++)
            {
                if (UserNames[i].Equals(info[0], StringComparison.OrdinalIgnoreCase))
                {
                    if (PassWords[i].Equals(info[1]))
                    {
                        Console.WriteLine("Logged in!");
                    }
                    else
                    {
                        Console.WriteLine("Incorrect Password or User name!");
                        break;
                    }
                }
            }
        }
    }

}
