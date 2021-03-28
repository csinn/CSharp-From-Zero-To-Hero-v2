using System;

namespace Homework_1
{
    class Program
    {

        //Read name, surname, age, weight (in kg) and height(in cm) from console.
        //Print a message to the screen based on the information given in 1. (an example message is shown below):
        //Tom Jefferson is 19 years old, his weight is 50 kg and his height is 156.5 cm.
        //Calculate and print body-mass index(BMI)
        //Do 1 and 2 for another person.
        static void Main(string[] args)
        {
            DisplayToConsole();
            DisplayToConsole();
        }
        
        static void DisplayToConsole()
        {
            string inputName = PromptFromConsole("name");
            string inputSurname = PromptFromConsole("surname");
            int inputAge = int.Parse(PromptFromConsole("age"));
            double inputWeight = double.Parse(PromptFromConsole("weight (in kg)"));
            double inputHeight = double.Parse(PromptFromConsole("height (in cm)"));
            string inputInfo = $"{inputName} {inputSurname} is {inputAge} years old, his weight is {inputWeight:F1} kg and his height is {inputHeight:F1} cm.";
            Console.WriteLine(inputInfo);
            Console.WriteLine($"{inputName} {inputSurname}'s BMI is {CalculateBMI(inputWeight, inputHeight):F2}");
        }

        static string PromptFromConsole(string input)
        {
            Console.WriteLine($"Type your {input}: ");
            return Console.ReadLine();
        }
        static double CalculateBMI(double weight, double height)
        {
            return weight / (height * height) * 10000;
        }
    }
}
