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

        static void Main(string[] args)
        {
            Console.WriteLine("Hello!\n");
            RequestAndReadInput();
        }

        private static void RequestAndReadInput()
        {
            Console.WriteLine("Please input name:");
            string personName = Console.ReadLine();

            Console.WriteLine("Surname:");
            string personSurname = Console.ReadLine();

            float personWeight = GetPersonWeight();
            float personHeight = GetPersonHeight();

            Console.WriteLine($"{personName} {personSurname} is {GetPersonAge()} years old, his weight is {personWeight} kg and his height is {personHeight} cm.\n");
            Console.WriteLine($"{personName}'s BMI is {personWeight / Math.Pow(personHeight / 100, 2):F2}");

            Console.WriteLine("Do you want to do another person? y/n");
            if (Console.ReadLine().ToLower() == "y")
            {
                RequestAndReadInput();
            }
        }

        private static int GetPersonAge() {
            Console.WriteLine("Age:");
            if (!int.TryParse(Console.ReadLine(), out int personAge))
            {
                Console.WriteLine("Bad value input. Try again.\n");
                return GetPersonAge();
            }
            else {
                return personAge;
            }
        }

        private static float GetPersonWeight() {
            Console.WriteLine("Weight(kg):");
            if (!float.TryParse(Console.ReadLine(), out float personWeight))
            {
                Console.WriteLine("Bad value input. Try again.\n");
                return GetPersonWeight();
            }
            else {
                return personWeight;
            }
        }

        private static float GetPersonHeight() {
            Console.WriteLine("Height(cm):");
            if (!float.TryParse(Console.ReadLine(), out float personHeight))
            {
                Console.WriteLine("Bad value input. Try again.\n");
                return GetPersonHeight();
            }
            else {
                return personHeight;
            }
        }
    }
}
