using System;

namespace BMICalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // To be able to use "." instead of "," as decimal separator
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;

            Person p1 = new Person();
            p1.GetPersonInfo();
            p1.PrintMsg();

            Person p2 = new Person();
            p2.GetPersonInfo();
            p2.PrintMsg();
        }

    }

    class Person
    {
        string name, surname;
        int age;
        double weight, height;
        public void GetPersonInfo()
        {
            Console.Write("Enter your name: ");
            this.name = Console.ReadLine();
            Console.Write("Enter your surname: ");
            this.surname = Console.ReadLine();
            Console.Write("Enter your age: ");
            this.age = int.Parse(Console.ReadLine());
            Console.Write("Enter your weight in kg: ");
            this.weight = double.Parse(Console.ReadLine());
            Console.Write("Enter your height in cm: ");
            this.height = double.Parse(Console.ReadLine());
        }

        public double CalculateBMI(double weight, double height)
        {
            return weight / (height * height);
        }

        public void PrintMsg()
        {
            string msg = $"{name} {surname} is {age} years old, his weight is {weight} kg and his height is {height} cm.";
            double bmi = CalculateBMI(weight, height/100.0);
            Console.WriteLine(msg);
            Console.WriteLine($"{name}'s BMI is {bmi:F2}");
        }
    }
}
