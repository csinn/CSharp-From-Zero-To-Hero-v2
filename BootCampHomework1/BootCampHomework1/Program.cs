using System;

namespace BootCampHomework1
{
    class Program
    {
        /*
         * Read name, surname, age, weight (in kg) and height(in cm) from console.
         * Print a message to the screen based on the information given in 1. (an example message shown below):
         *
         *    Tom Jefferson is 19 years old, his weight is 50 kg and his height is 156.5 cm.
         *
         * Calculate and print body-mass index(BMI)
         * Do 1 and 2 for another person.         
         */
        static void Main(string[] args)
        {

            Console.Write("Your name - ");
            string name = Console.ReadLine() ;

            Console.Write("Your surname - ");
            string surname = Console.ReadLine();

            Console.Write("Your age - ");
            int age = int.Parse(Console.ReadLine());

            Console.Write("Your weight in kg - ");
            string weightString = Console.ReadLine();
            double weightInKg = double.Parse(weightString);

            Console.Write("Your height in cm - ");
            string heightString = Console.ReadLine(); 
            double heightInCm = double.Parse(heightString);

            PrintInfoForPerson(name,surname,age,weightInKg,heightInCm);

            var BMI = calculateBMI(weightInKg,heightInCm);
            Console.WriteLine($"{name}'s BMI is {BMI:F3}");
        }

        static void PrintInfoForPerson(string name,string surname,int age,double weightInKg,double heightInCm)
        {
            Console.WriteLine($"{name} {surname} is {age} years old, his weight is {weightInKg} kg and his height is {heightInCm} cm.");
        }

        static double calculateBMI(double weightInKg,double heightInCm)
        {
            return weightInKg / (heightInCm * heightInCm) * 10000;
        }
    }
}
