using Homework1.Models;
using System;

namespace Homework1
{
    internal class Program
    {
        #region Private Methods

        private static void Main(string[] args)
        {
            var p1 = new Person
            {
                FirstName = "Tom",
                LastName = "Jefferson",
                Age = 19,
                Height = 156.5,
                Weight = 50
            };

            Console.WriteLine(p1);
            p1.WriteBMI();

            var p2 = Person.MakePerson();
            Console.WriteLine(p2);
            p2.WriteBMI();

            var p3 = Person.MakePerson();
            Console.WriteLine(p3);
            p3.WriteBMI();
        }

        #endregion Private Methods
    }
}