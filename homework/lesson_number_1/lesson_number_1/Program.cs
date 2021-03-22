using System;
using static lesson_number_1.Person;

namespace lesson_number_1
{
    class Program
    {
        /*
            Read name, surname, age, weight (in kg) and height (in cm) from console.
            Print a message to the screen based on the information given in 1. (an example message shown below):
            Tom Jefferson is 19 years old, his weight is 50 kg and his height is 156.5 cm. 
            Calculate and print body-mass index (BMI)
            Do 1 and 2 for another person.
        */

        static void Main(string[] args)
        {
            var personCount = GetPersonCount();

            for (int i = 0; i < personCount; i++)
            {
                var person = ReadStatsFromConsole(i + 1);
                CalculateBMI(person);
            }
        }

        static int GetPersonCount()
        {
            Console.WriteLine("How many people's BMI would you like to calculate");
            var personCount = Convert.ToInt32(Console.ReadLine());
            return personCount;
        }

        static Person ReadStatsFromConsole(int personNumber)
        {
            Console.WriteLine($"What is name of the person {personNumber}: ");
            var name = Console.ReadLine();

            Console.WriteLine($"What is the surname of person {personNumber}: ");
            var surname = Console.ReadLine();

            Console.WriteLine($"What is the age of person {personNumber}: ");
            var age = int.Parse(Console.ReadLine());

            Console.WriteLine($"What is the weight (in KG) of person {personNumber}: ");
            var weight = float.Parse(Console.ReadLine());

            Console.WriteLine($"What is the height of person {personNumber}: ");
            var height= float.Parse(Console.ReadLine());

            Console.WriteLine($"{name} {surname} is {age} years old, their weight is {weight} kg and their height is {height} cm");

            Person person = new Person(name, surname, age, weight, height);

            return person;
        }

        static void CalculateBMI(Person person)
        {
            var heightInMeters = person.Height / 100;

            var bmi = person.Weight / (heightInMeters * heightInMeters);

            Console.WriteLine($"Their bmi is: {bmi:f1}");
        }
    }
}
