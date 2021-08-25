using System;
using System.Collections.Generic;
using System.Text;

namespace BootCamp.Chapter1
{

    public static class BMICalculator
    {
        public static void BMI_Calculator()
        {

            CalculateBMI();
            CalculateBMI(); 
        }

        private static void CalculateBMI()
        {
            Console.Write("Can I have your name: ");
            var name = Console.ReadLine();
            Console.Write("Can I have your surname: ");
            var surname = Console.ReadLine();
            Console.Write("Can I have your age:");
            var age = Console.ReadLine();
            Console.Write("Can I have your weight in kg: ");
            var weight = Console.ReadLine();
            Console.Write("Can I have your height in cm: ");
            var height = Console.ReadLine();

            Console.WriteLine($"{name} {surname} is {age} years old, his weight is {weight} kg and his height is {height} cm.");

            var BMI = Calculate(height, weight);
            Console.WriteLine($"This person bmi is {BMI}");
        }

        private static double Calculate(string height, string weight)
        {
            var parsedHeight = double.Parse(height) / 100;
            var parsedWeight = double.Parse(weight);
            return parsedWeight / (parsedHeight * parsedHeight);
        }
    }
}
