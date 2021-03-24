using System;
using System.Collections.Generic;

namespace Homework1
{
    internal static class Program
    {
        private static readonly List<Person> Persons = new List<Person>();

        public static void Main(string[] args)
        {
            bool keepGoing = true;
            do
            {
                Person person_ = GettingInfos();
                if (person_ == null)
                    break;
                Console.WriteLine("Do you want to show all persons ? ( y/n )");
                string resp = Console.ReadLine();
                if (resp == "yes" || resp == "y")
                {
                    foreach (var person in Persons)
                    {
                        Console.WriteLine($"{person.Name} is {person.Age} years old, his/her weight is {person.Weight} kg and his/her height is {person.Height} cm.");
                        Console.WriteLine($"Their BMI is {(decimal)person.Weight / (decimal)(person.Height * person.Height)}\n");
                    }
                }

                Console.WriteLine("Do you want to continue? ( y/n )");
                resp = Console.ReadLine();
                if (resp == "no" || resp == "n")
                {
                    keepGoing = false;
                }
            } while (keepGoing);
        }

        private static bool CheckIfValuesNotNull(Person person)
        {
            if (person.Age == null || person.Height == null || person.Name == null | person.Weight == null)
                {
                    return false;
                }
            return true;
        }

        private static Person GettingInfos()
        {
            Person person = new Person { Name = ConsoleQuestion("full name") };
            try
            {
                person.Age = short.Parse(ConsoleQuestion("age"));
                person.Weight = double.Parse(ConsoleQuestion("weight (kg)"));
                person.Height = double.Parse(ConsoleQuestion("height (m)"));
            }
            catch (Exception)
            {
                Console.WriteLine("One or more value that you entered is not a correct number, please retry");
                Console.WriteLine("Hint: It could maybe be cause because you used \".\" instead of \",\"");
            }

            if (!CheckIfValuesNotNull(person))
            {
                Console.WriteLine("One or more value you entered is empty, please retry");
                return null;
            }
            return person;
        }

        private static string ConsoleQuestion(string valueName)
        {
            Console.WriteLine($"What's your {valueName}");
            return Console.ReadLine();
        }
    }

    internal class Person
    {
        public string Name { get; set; }
        public short Age { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
    }
}