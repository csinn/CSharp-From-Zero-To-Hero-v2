using System;

namespace BootCampHomework1
{
    class Program
    {
        /*
         * Read name, surname, age, weight (in kg) and height(in cm) from console.
         * Print a message to the screen based on the information given in 1. (an example message shown below):
         *
         *    Tom Jefferson is 19 years old, his weight is 50 kg and his height is 156.5 cm.
         *
         * Calculate and print body-mass index(BMI)
         * Do 1 and 2 for another person.         
		 *
         */
        static void Main(string[] args)
        {
			char continueChar = ' ';	
				while(continueChar!='n' && continueChar!='N'){
					string name = PromptUserInfo("name - ") ;
					string surname = PromptUserInfo("surname - ");
					int age = int.Parse(PromptUserInfo("age - "));
					double weightInKg = double.Parse(PromptUserInfo("weight (kg) - "));
					double heightInCm = double.Parse(PromptUserInfo("height (cm) - "));
					double BMI = calculateBMI(weightInKg,heightInCm);

					PrintInfoForPerson(name,surname,age,weightInKg,heightInCm);
					PrintPersonBMI(name,BMI);
				
					Console.Write("Do you wish to continue (y/n) - ");
					continueChar=Console.ReadKey().KeyChar;
					Console.WriteLine();
				}
        }
		static string PromptUserInfo(string prompt){
			Console.Write($"Please enter your {prompt}");
			return Console.ReadLine();
		}

        static void PrintInfoForPerson(string name,string surname,int age,double weightInKg,double heightInCm)
        {
            Console.WriteLine($"{name} {surname} is {age} years old, his weight is {weightInKg} kg and his height is {heightInCm} cm.");
        }
		
		static void PrintPersonBMI(string name,double BMI){
			Console.WriteLine($"{name}'s BMI is {BMI:F3}");
		}
		
        static double calculateBMI(double weightInKg,double heightInCm)
        {
            return weightInKg / (heightInCm * heightInCm) * 10000;
        }
    }
}
