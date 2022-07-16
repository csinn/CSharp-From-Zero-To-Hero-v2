using System;

namespace FirstLessonHomework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ReadAndPrintTwoPeoplesInformation();
        }

        static void ReadAndPrintTwoPeoplesInformation()
        {
            ReadAndPrintPersonsInformation();
            Console.WriteLine("");
            ReadAndPrintPersonsInformation();
        }

        static void ReadAndPrintPersonsInformation()
        {
            string name = PromptStringInput("What's your name?");
            string surname = PromptStringInput("What's your surname?");
            int age = PromptIntegerInput("What's your age?");
            double weightInKg = PromptDoubleInput("What's your weight in kilograms?");
            double heightInCm = PromptDoubleInput("What's your height in centimeters?");

            PrintPersonsDescription(name, surname, age, weightInKg, heightInCm);

            double bmi = CalculateBmiInMetricSystem(weightInKg, heightInCm);
            PrintPersonsBMI(bmi);
        }

        static string PromptStringInput(string question)
        {
            string textToWrite = $"{question} ";
            Console.Write(textToWrite);

            string textInput = Console.ReadLine();
            return textInput;
        }

        static int PromptIntegerInput(string question)
        {
            string textInput = PromptStringInput(question);
            int numberInput = int.Parse(textInput);
            return numberInput;
        }

        static double PromptDoubleInput(string question)
        {
            string textInput = PromptStringInput(question);
            double doubleInput = double.Parse(textInput);
            return doubleInput;
        }

        static void PrintPersonsDescription(string name, string surname, int age, double weightInKg, double heightInCm)
        {
            string informationAboutPerson = $"{name} {surname} is {age} years old, his weight is {weightInKg:F2} kg and his height is {heightInCm:F2} cm.";
            Console.WriteLine(informationAboutPerson);
        }

        static double CalculateBmiInMetricSystem(double weightInKg, double heightInCm)
        {
            double heightInMeters = heightInCm / 100;
            double heightInSquaredMeters = heightInMeters * heightInMeters;
            
            double bmi = weightInKg / heightInSquaredMeters;
            return bmi;
        }

        static void PrintPersonsBMI(double bmi)
        {
            string textToPrint = $"His BMI score is: {bmi:F1} kg/m^2";
            Console.WriteLine(textToPrint);
        }
    }
}
