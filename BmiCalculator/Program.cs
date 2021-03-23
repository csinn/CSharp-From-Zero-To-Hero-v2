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
            GetPersonData(out string personName, out SmallNumber personAge, 
                out SmallNumber personWeight, out SmallNumber personHeight);

            SmallNumber bmiResult = CalculateBmi(personWeight, personHeight);

            Console.WriteLine(
                $"{personName} is {personAge}, his weight is {personWeight} kg and his height is {personHeight} cm.");
            Console.WriteLine($"His Body Mass Index is {bmiResult}");
        }

        private static void GetPersonData(out string personName, out SmallNumber personAge, 
            out SmallNumber personWeight, out SmallNumber personHeight)
        {
            const string messageNameRequest = "Input the persons name: ";
            personName = PromptString(messageNameRequest);

            const string messageAgeRequest = "Input the persons age: ";
            personAge = PromptInt(messageAgeRequest);

            const string messageWeightRequest = "Input the persons weight: ";
            personWeight = PromptDouble(messageWeightRequest);

            const string messageHeightRequest = "Input the persons height: ";
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

        private static SmallNumber PromptInt(string message)
        {
            SmallNumber output;
            do
            {
                Console.Write(message);
            } while (!SmallNumber.TryParse(Console.ReadLine(), out output));

            return output;
        }

        private static SmallNumber PromptDouble(string message)
        {
            SmallNumber output;
            do
            {
                Console.Write(message);
            } while (!SmallNumber.TryParse(Console.ReadLine(), out output));

            return output;
        }

        private static bool PromptBool(string message, ConsoleKey requiredKey)
        {
            Console.WriteLine(message);
            ConsoleKey pressedKey = Console.ReadKey(true).Key;

            return pressedKey == requiredKey;
        }

        private static SmallNumber CalculateBmi(SmallNumber weight, SmallNumber height)
        {
            SmallNumber heightInMeters = height / 100;
            SmallNumber output = weight / (heightInMeters * heightInMeters);

            return output;
        }
    }
}