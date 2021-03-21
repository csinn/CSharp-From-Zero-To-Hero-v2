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
            GetPersonsData(out string personsName, out int personsAge, 
                out double personsWeight, out double personsHeight);

            double bmiResult = CalculateBmi(personsWeight, personsHeight);

            Console.WriteLine(
                $"{personsName} is {personsAge}, his weight is {personsWeight} kg and his height is {personsHeight} cm.");
            Console.WriteLine($"His Body Mass Index is {bmiResult:F1}");
        }

        private static void GetPersonsData(out string personsName, out int personsAge, 
            out double personsWeight, out double personsHeight)
        {
            const string messageNameRequest = "Input the persons name: ";
            personsName = PromptString(messageNameRequest);

            const string messageAgeRequest = "Input the persons age: ";
            personsAge = PromptInt(messageAgeRequest);

            const string messageWeightRequest = "Input the persons weight: ";
            personsWeight = PromptDouble(messageWeightRequest);

            const string messageHeightRequest = "Input the persons height:";
            personsHeight = PromptDouble(messageHeightRequest);
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