using System;
using System.Dynamic;

namespace BMI_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double bmi = GetUserInfo();
            Console.WriteLine(bmi);

            bmi = GetUserInfo();
            Console.WriteLine(bmi);
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

            double bmi = PrintUserInfo(fName, lName, age, weight, height);

            return bmi;
        }
    }
}
