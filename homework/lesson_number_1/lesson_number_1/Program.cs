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
            var person1 = ReadStatsFromConsole(1);
            CalculateBMI(person1);
            Console.WriteLine("");

            var person2 = ReadStatsFromConsole(2);
            CalculateBMI(person2);
        }

        static Person ReadStatsFromConsole(int personNumber)
        {
            Console.WriteLine($"What is name of the person {personNumber}: ");
            var name = Console.ReadLine();

            Console.WriteLine($"What is the surname of person {personNumber}: ");
            var surname = Console.ReadLine();

            Console.WriteLine($"What is the age of person {personNumber}: ");
            var ageString = Console.ReadLine();

            Console.WriteLine($"What is the weight (in KG) of person {personNumber}: ");
            var weightString = Console.ReadLine();

            Console.WriteLine($"What is the height of person {personNumber}: ");
            var heightString = Console.ReadLine();

            Console.WriteLine($"{name} {surname} is {ageString} years old, their weight is {weightString} kg and their height is {heightString} cm");

            int age = int.Parse(ageString);
            float weight = float.Parse(weightString);
            float height = float.Parse(heightString);

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
