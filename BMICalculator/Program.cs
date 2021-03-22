using System;

namespace BMICalculator
{
    class Program
    {
        static void Main(string[] args)
        {
        	// To be able to use "." instead of "," as decimal separator
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;

            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("Person " + (i+1));
                Console.Write("Enter your name: ");
                string name = Console.ReadLine();
                Console.Write("Enter your surname: ");
                string surname = Console.ReadLine();
                Console.Write("Enter your age: ");
                int age = int.Parse(Console.ReadLine());
                Console.Write("Enter your weight in kg: ");
                double weight = double.Parse(Console.ReadLine());
                Console.Write("Enter your height in cm: ");
                double heightC = double.Parse(Console.ReadLine());
                double heightM = heightC / 100.0;
                string msg = $"{name} {surname} is {age} years old, his weight is {weight} kg and his height is {heightC} cm.";
                double bmi = weight / (heightM * heightM);
                Console.WriteLine(msg);
                Console.WriteLine($"{name}'s BMI is {bmi:F2}");
            }
        }
    }
}
