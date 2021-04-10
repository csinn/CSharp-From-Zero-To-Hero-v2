using System;
using System.Dynamic;

namespace BMI_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            PromptUserInfo();
            PromptUserInfo();
        }

        static void CalculateBmi(double weight, double height, string fName, string lName)
        {
            double bmi = (weight / (height * height)) * 10000;
            Console.WriteLine("{0} {1}, your BMI is: {2:F2}", fName, lName, bmi);
        }

        static void PrintUserInfo(string fName, string lName, double age, double weight, double height)
        {
            string userInfo = $"{fName} {lName} is {age} years old, his weight is {weight} kg and his height is {height} cm";
            Console.WriteLine(userInfo);

            CalculateBmi(weight, height, fName, lName);
        }

        static void PromptUserInfo()
        {
            Console.WriteLine("Enter Your Name: ");
            string fName = Console.ReadLine();
            Console.WriteLine("Enter Your Surname: ");
            string lName = Console.ReadLine();
            Console.WriteLine("Enter Your Age: ");
            string ageText = Console.ReadLine();
            double.TryParse(ageText, out double age);
            Console.WriteLine("Enter Your Weight in kg: ");
            string weightText = Console.ReadLine();
            double.TryParse(weightText, out double weight);
            Console.WriteLine("Enter Your Height in cms: ");
            string heightText = Console.ReadLine();
            double.TryParse(heightText, out double height);

            PrintUserInfo(fName, lName, age, weight, height);
        }
    }
}
