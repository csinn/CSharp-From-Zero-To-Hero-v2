using System;

namespace RecipeApp.Homework
{
    class FirstHomework
    {
        //Entry point
        static void Main(string[] args)
        {
            //Person 1
            InitPerson();
            //Person 2
            InitPerson();
        }

        //Print a message and ask for an input
        static string GetConsoleInput(string message)
        {
            Console.WriteLine(message);

            var input = Console.ReadLine();
            return input;
        }

        //Try to convert the input to a double
        //var become 0 if convertion fails
        static double ConvertToDouble(string message)
        {
            double.TryParse(message, out double convertedOutput);

            return convertedOutput;
        }

        //Try to convert the input to an integer
        //var become 0 if convertion fails
        static int ConvertToInt(string message)
        {
            int.TryParse(message, out int convertedOutput);

            return convertedOutput;
        }

        //Print the collected data
        static void PrintUserData(string name, string surname, int age, double weight, double height)
        {
            Console.WriteLine($"{name} {surname} is {age} years old, his weight is {weight:F2} kg, and his height is {height:F2} m");
        }

        //Calaculate the Body-Mass-Index 
        static double CalculateBMI(double height, double weight)
        {
            var bmi = weight / (height * height);
            Console.WriteLine($"BMI: {bmi}");

            return bmi;
        }

        //Collect data of a person, calculate and print the BMI
        static void InitPerson()
        {
            string name = GetConsoleInput("Enter your name");
            string surname = GetConsoleInput("Enter your surname");
            int age = ConvertToInt(GetConsoleInput("Enter your age"));
            double weight = ConvertToDouble(GetConsoleInput("Enter your weight in kg"));
            double height = ConvertToDouble(GetConsoleInput("Enter your height in m"));

            PrintUserData(name, surname, age, weight, height);
            CalculateBMI(height, weight);
        }

    }
