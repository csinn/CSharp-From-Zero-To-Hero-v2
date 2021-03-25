using System;

namespace Homework1
{
    class CalcBMI
    {
        /*
            Homework:
            1. Read name, surname, age, weight (in kg) and height (in cm) from console.
            2. Print a message to the screen based on the information given in 1. (an example message is shown below):
            ex.    Tom Jefferson is 19 years old, his weight is 50 kg and his height is 156.5 cm. 
            3. Calculate and print body-mass index (BMI)
            4. Do 1 and 2 for another person.
        */

        static string personName;
        static string personSurname;
        static int personAge;
        static float personWeight;
        static float personHeight;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello!\n");
            RequestAndReadInput();
        }

        private static void RequestAndReadInput()
        {
            Console.WriteLine("Please input name:");
            personName = Console.ReadLine();
            Console.WriteLine("Surname:");
            personSurname = Console.ReadLine();
            Console.WriteLine("Age:");
            if (!int.TryParse(Console.ReadLine(), out int personAge))
            {
                Console.WriteLine("Bad value input. Try again.\n");
                RequestAndReadInput();
                return;
            }
            Console.WriteLine("Weight(kg):");
            if (!float.TryParse(Console.ReadLine(), out float personWeight))
            {
                Console.WriteLine("Bad value input. Try again.\n");
                RequestAndReadInput();
                return;
            }
            Console.WriteLine("Height(cm):");
            if (!float.TryParse(Console.ReadLine(), out float personHeight))
            {
                Console.WriteLine("Bad value input. Try again.\n");
                RequestAndReadInput();
                return;
            }
            Console.WriteLine($"{personName} {personSurname} is {personAge} years old, his weight is {personWeight} kg and his height is {personHeight} cm.\n");
            Console.WriteLine($"BMI is {personWeight / Math.Pow(personHeight / 100, 2):F2}");
            Console.WriteLine("Do you want to do another person? y/n");
            if (Console.ReadLine().ToLower() == "y")
            {
                RequestAndReadInput();
            }
        }
    }
}
