using System;

namespace LessonOneHomework
{
    class Program
    {
        static void Main(string[] args)
        {
            bool continueLoop = true;
            while(continueLoop)
            {
                (string firstName, string surname) = GetUserName();
                Console.Write("What is your age? ");
                int age = int.Parse(Console.ReadLine());
                (double height, double weight) = GetHeightandWeight();
                double bmi = CalculateBMI(height, weight);
                Console.WriteLine($"{firstName} {surname} is {age} years old, his weight is {weight} and his height is {height}.");
                Console.WriteLine($"Their BMI is {bmi}.");
                Console.Write("Another person? (y/n)");
                string looper = Console.ReadLine();
                continueLoop = looper.ToLower() == "n" ? false : true;
            }
        }

        private static (string, string) GetUserName()
        {
            Console.Write("What is your full name? ");
            string fullName = Console.ReadLine();
            string[] names = fullName.Split(" ");
            return (names[0], names[1]);
        }

        private static (double, double) GetHeightandWeight()
        {
            while (true)
            {
                Console.Write("What is your height (in centimeters)? ");
                bool heightSucceed = double.TryParse(Console.ReadLine(), out double height);
                Console.Write("What is your weight (in kilograms)? ");
                bool weightSucceed = double.TryParse(Console.ReadLine(), out double weight);
                if(heightSucceed && weightSucceed)
                {
                    return (height, weight);
                }
                else
                {
                    Console.WriteLine("Height and weight entry failure. Retrying...");
                }
            }
        }
        
        private static double CalculateBMI(double height, double weight)
        {
            return (weight / height / height) * 10_000;
        }
    }
}
