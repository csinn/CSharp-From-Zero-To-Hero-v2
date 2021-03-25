using System;

namespace Homework_1_User_input
{
    class Program
    {
       
        static void Main(string[] args)
        {
            for (int i = 0; i<=1;) { 
            Console.WriteLine("Please enter name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Please enter surname: ");
            string surname = Console.ReadLine();

            Console.WriteLine("Please enter age: ");
            string ageText = Console.ReadLine();
            int age = int.Parse(ageText);

            Console.WriteLine("Please enter kg: ");
            string kgText = Console.ReadLine();
            double kg = double.Parse(kgText);

            Console.WriteLine("Please enter height: ");
            string heightText = Console.ReadLine();
            double height = double.Parse(heightText);

            PrintPerson(height, kg, name, surname, age);
            
            }
        }

        static void PrintPerson(double height,double kg,string name,string surname,int age)
        {
            Console.WriteLine($"{name} {surname} is {age} years old, his weight is {kg:F2} and his height is {height:F2} cm .");
            Console.WriteLine($"{name} your BMI is: {BMI(kg, height):F2} . ");
        }
        static double BMI(double weight,double height)
        {
            return weight / (height * height) * 10000;
        }
    }
}
