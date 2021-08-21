using System;
using LINQ_Collections;

namespace LINQ_Colletcions
{
    class Program
    {
        static void Main()
        {
            object[] anyArray = { 2, 9, 1 };

            var expandedArray = anyArray.InsertAt("Hello and", 3);

            foreach (var item in expandedArray)
            {
                Console.Write(item + ", ");
            }

            Console.WriteLine(Environment.NewLine);

            Login login = new Login();
            login.LoginSequence();
        }
    }
}
