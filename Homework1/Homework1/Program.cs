using System;

namespace Homework1
{
    class Program
    {
        static void CalculateBMI(double height, double weight)
        {
            height = height / 100; // converts from cm to m
            double bmi = weight / (height * height);
            Console.WriteLine($"Your BMI is {bmi}");
        }
        static void Print_Information(string name, string surname, int age, double weight, double height)
        {
            Console.WriteLine($"{name} {surname} is {age} years old, his weight is {weight}kg   and his height is {height}");
            CalculateBMI(height, weight);
        }

        static void Get_Information()
        {
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();

            Console.WriteLine("What is your surname?");
            string surname = Console.ReadLine();

            Console.WriteLine("What is your age?");
            int.TryParse(Console.ReadLine(), out int age);

            Console.WriteLine("What is your weight?");
            double.TryParse(Console.ReadLine(), out double weight);

            Console.WriteLine("What is your height?");
            double.TryParse(Console.ReadLine(), out double height);

            Print_Information(name, surname, age, weight, height);
        }


        static void Main(string[] args)
        {
            do
            {
                Get_Information();
                Console.WriteLine("Would you like to do another person?");
            } while (Console.ReadLine().ToLower() == "y");
        }
    }
}
