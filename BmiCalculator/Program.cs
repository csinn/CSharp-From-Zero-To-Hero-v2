using System;

namespace BmiCalculator
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            const string welcomeMessage = "Hello World! Welcome to the Bmi Calculator";
            Console.WriteLine(welcomeMessage);

            bool isUserContinuing;
            do
            {
                PrintBmi();
                const string continueMessage = "Calculate BMI for another person? (Y/N)";
                isUserContinuing = PromptBool(continueMessage, ConsoleKey.Y);
                Console.WriteLine();
            } while (isUserContinuing);
        }

        private static void PrintBmi()
        {
            GetPersonData(out string personName, out int personAge, 
                out double personWeight, out double personHeight);

            double bmiResult = CalculateBmi(personWeight, personHeight);

            Console.WriteLine(
                $"{personName} is {personAge}, his weight is {personWeight} kg and his height is {personHeight} cm.");
            Console.WriteLine($"His Body Mass Index is {bmiResult:F1}");
        }

        private static void GetPersonData(out string personName, out int personAge, 
            out double personWeight, out double personHeight)
        {
            const string messageNameRequest = "Input the persons name: ";
            personName = PromptString(messageNameRequest);

            const string messageAgeRequest = "Input the persons age: ";
            personAge = PromptInt(messageAgeRequest);

            const string messageWeightRequest = "Input the persons weight: ";
            personWeight = PromptDouble(messageWeightRequest);

            const string messageHeightRequest = "Input the persons height:";
            personHeight = PromptDouble(messageHeightRequest);
        }

        private static string PromptString(string message)
        {

            string userInput;
            do
            {
                Console.Write(message);
                userInput = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(userInput));

            return userInput;
        }

        private static int PromptInt(string message)
        {
            int output;
            do
            {
                Console.Write(message);
            } while (!int.TryParse(Console.ReadLine(), out output));

            return output;
        }

        private static double PromptDouble(string message)
        {
            double output;
            do
            {
                Console.Write(message);
            } while (!double.TryParse(Console.ReadLine(), out output));

            return output;
        }

        private static bool PromptBool(string message, ConsoleKey requiredKey)
        {
            Console.WriteLine(message);
            ConsoleKey pressedKey = Console.ReadKey(true).Key;

            return pressedKey == requiredKey;
        }

        private static double CalculateBmi(double weight, double height)
        {
            double heightInMeters = height / 100.0;
            double output = weight / Math.Pow(heightInMeters, 2);

            return output;
        }
    }
}