using System;
using System.Dynamic;

namespace BMI_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double bmi = GetUserInfo();
            Console.WriteLine("Your BMI is {0}", bmi);

            Console.WriteLine();

            bmi = GetUserInfo();
            Console.WriteLine("Your BMI is {0}", bmi);
        }

        static double CalculateBmi(double weight, double height, string fName, string lName)
        {
            double bmi = (weight / (height * height)) * 10000;

            return bmi;
        }

        static double PrintUserInfo(string fName, string lName, double age, double weight, double height)
        {
            string userInfo = $"{fName} {lName} is {age} years old, his weight is {weight} kg and his height is {height} cm";
            Console.WriteLine(userInfo);
            
            double bmi = CalculateBmi(weight, height, fName, lName);

            return bmi;
        }

        static double GetUserInfo()
        {
            string firstName = PromptConsoleFor("First Name");
            
            string lastName = PromptConsoleFor("Last Name");

            string ageText = PromptConsoleFor("Age");
            double.TryParse(ageText, out double age);
            
            string weightText = PromptConsoleFor("Weight in Kg");
            double.TryParse(weightText, out double weight);
            
            string heightText = PromptConsoleFor("Height in cm");
            double.TryParse(heightText, out double height);

            double bmi = PrintUserInfo(firstName, lastName, age, weight, height);

            return bmi;
        }

        static string PromptConsoleFor(string text)
        {
            Console.WriteLine("Enter Your {0}", text);
            string textResult = Console.ReadLine();

            return textResult;
        }
    }
}
