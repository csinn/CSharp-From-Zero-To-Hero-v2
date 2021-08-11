using System;
using System.Collections.Generic;
using System.Text;

namespace BootCamp.Chapter1
{
    public static class BMICalculator
    {
        public static void BMI_Calculator()
        {
            // Person 1 

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

            var BMI = calculate(height, weight);
            Console.WriteLine($"This person bmi is {BMI}");

            // Person 2 

            Console.Write("Can I have your name: ");
            var name2 = Console.ReadLine();
            Console.Write("Can I have your surname: ");
            var surname2 = Console.ReadLine();
            Console.Write("Can I have your age:");
            var age2 = Console.ReadLine();
            Console.Write("Can I have your weight in kg: ");
            var weight2 = Console.ReadLine();
            Console.Write("Can I have your height in cm: ");
            var height2 = Console.ReadLine();

            Console.WriteLine($"{name2} {surname2} is {age2} years old, his weight is {weight2} kg and his height is {height2} cm.");

            BMI = calculate(height, weight);
            Console.WriteLine($"This person bmi is {BMI}");



        }

        private static double calculate(string height, string weight)
        {
            var parsed_height = double.Parse(height) / 100;
            var parsed_weight = double.Parse(weight);
            return parsed_weight / (parsed_height * parsed_height);
        }
    }
}
