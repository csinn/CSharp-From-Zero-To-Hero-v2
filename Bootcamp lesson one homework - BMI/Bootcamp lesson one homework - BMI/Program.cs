using System;

namespace Bootcamp_lesson_one_homework___BMI
{
    class Program
    {
        static void Main(string[] args)
        {
            infoAndBMI();
            infoAndBMI();

        }


        static void infoAndBMI()
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            Console.Write("Enter your age: ");
            int age = int.Parse(Console.ReadLine());

            Console.Write("Enter your weight in KG: ");
            double weight = double.Parse(Console.ReadLine());

            Console.Write("Enter your height in centimeters: ");
            double height = double.Parse(Console.ReadLine());

            printInfo(name, age, weight, height);
            printBMI(weight, height);

        }


        static void printInfo(string name, int age, double weight, double height)
        {
            Console.WriteLine($"{name} is {age} years old, his weight is {weight} and his height is {height} cm.");
            
        }

        static void printBMI(double weight, double height)
        {
            height /= 100;
            double bmi = (weight / height) / height;

            Console.WriteLine($"Persons BMI is: {bmi}");
        }


    }

  
}
