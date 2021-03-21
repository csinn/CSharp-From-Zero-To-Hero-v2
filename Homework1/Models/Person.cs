using System;

namespace Homework1.Models
{
    public enum Gender
    {
        Male,
        Female
    }

    public class Person
    {
        #region Public Properties

        public uint Age { get; set; }
        public string FirstName { get; set; }
        public Gender Gender { get; set; }
        public double Height { get; set; }
        public string LastName { get; set; }
        public double Weight { get; set; }

        #endregion Public Properties

        #region Public Methods

        public static Person MakePerson()
        {
            var ret = new Person();

            ret.FirstName = GetFromConsole("first name");

            ret.LastName = GetFromConsole("last name");

            ret.Age = uint.Parse(GetFromConsole("age"));

            ret.Weight = double.Parse(GetFromConsole("weight", "kg"));

            ret.Height = double.Parse(GetFromConsole("height", "cm"));

            return ret;
        }

        public double CalcBMI()
        {
            return Weight / Math.Pow(Height / 100, 2);
        }  
        
        public void WriteBMI()
        {
            Console.WriteLine($"{FirstName}'s BMI is {CalcBMI():f2}."); 
        }

        public override string ToString()
        {
            string pronoun = Gender switch
            {
                Gender.Male => "his",
                Gender.Female => "her",
                _ => "their",
            };

            return
                $"{FirstName} {LastName} is {Age} years old, " +
                $"{pronoun} weight is {Weight} kg and " +
                $"{pronoun} height is {Height} cm.";
        }

        #endregion Public Methods

        static string GetFromConsole(string property, string unit = default)
        {
            Console.WriteLine($"Enter a person's {property}{(unit is default(string) ? ": " : $" (in {unit}): ")}");
            return Console.ReadLine();
        }
    }
}