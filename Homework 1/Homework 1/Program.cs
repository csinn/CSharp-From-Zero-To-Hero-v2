using System;

namespace Homework_1
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintInfo();
            PrintInfo();
        }
        static void PrintInfo()
        {
            string name = GetFromConsole("name");
            string surname = GetFromConsole("surname");
            int age = int.Parse(GetFromConsole("age"));
            double weight = double.Parse(GetFromConsole("weight"));
            double height = double.Parse(GetFromConsole("height"));
            string convertedInfo = $"{name} {surname} is {age} years old, his weight is {weight:F1} kg and his height is {height:F1} cm.";
            Console.WriteLine(convertedInfo);
            Console.WriteLine($"{name} {surname}'s BMI is {CalculatingBMI(weight, height):F2}");
        }
        static string GetFromConsole(string input)
        {
            Console.WriteLine($"Please type in your {input}: ");
            return Console.ReadLine();
        }
        
        static double CalculatingBMI(double weight, double height)
        {
            return weight / (height * height) * 10000;
        }
    }
}
