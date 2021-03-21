// Import classes from system namespace
using System;

// Holder of classes
namespace RecipeApp
{
    // Here is a list of standard cooking units:
    //    Cup	0.24 l
    //    Gallon  3.79 l
    //    Fluid Ounce	29.57 ml
    //    Pint    0.47 l
    //    Quart   0.95 l
    //    Tablespoon  14.79 ml
    //    Teaspoon    4.93 ml

    // Holder of functions and data
    class Program
    {
        // The less a function implements itself- the higher level it is
        // Main function simply the application- so it is the highest level function
        // It just consumes other functions.

        // Named block of code
        // cw + tab autocompletes to Console.WriteLine();
        // strongly typed means that I don't need to guess what I can do with a class or a variable
        // So, when I get errors, they will be before my application runs- in compile time.
        // Weekly typed means that there is no check on what a function or variable cna do.
        // We can do that with dynamic keyword: dynamic a; a.IsPerfectly.Fine().CsharpCode().
        static void Main(string[] args)
        {
            double totalMl = PrintTeaspoonsToMl() + PrintTablespoonsToMl();
            PrintHowMany100MlBottles(totalMl);
        }

        static double PrintTeaspoonsToMl()
        {
            var teaspoons = GetAmountFromConsole("teaspoons");
            var mlOfTeaspoons = TeaspoonsToMl(teaspoons);
            Print(teaspoons, "teaspoons", mlOfTeaspoons);

            return mlOfTeaspoons;
        }

        static double PrintTablespoonsToMl()
        {
            double tablespoons = GetAmountFromConsole("tablespoons");
            double mlOfTablespoons = TableSpoonsToMl(tablespoons);
            Print(tablespoons, "tablespoons", mlOfTablespoons);

            return mlOfTablespoons;
        }

        static void PrintHowMany100MlBottles(double ml)
        {
            // 1 / 0 = error
            // 1 / 2 = 0
            // int / int = int
            // 1.0 / 2 = 0.5
            // double / int = double
            // 1.0 + 1 = 2.0
            // double + int = double
            // We have bottles of 100 ml.
            // How many bottles can we fill after the conversion?
            // int is a whole number
            int bottlesCount = (int)(ml / 100) + 1;
            Console.WriteLine($"{ml:F2} can fill {bottlesCount} bottles of 100ml");
        }

        // GetTeaspoonsFromConsole is a lower level function.
        // Because it implement HOW we can read a number from a console.
        static double GetAmountFromConsole(string unit)
        {
            Console.WriteLine($"Please enter {unit} amount: ");
            // variable
            // holds data
            // type, name, value
            var amountText = Console.ReadLine();
            // Floating point number with double precision.
            double amount = double.Parse(amountText);

            return amount;
        }

        static double TeaspoonsToMl(double teaspoons)
        {
            // 4.93m is a decimal - use it for money- for absolute accuracy- use decimal.
            // 4.93 is double
            // 4.93f is a float- use it when you don't plan to use math.
            double ml = teaspoons * 4.93;

            return ml;
        }

        static double TableSpoonsToMl(double teaspoons)
        {
            double tablespoons = teaspoons * 14.79;

            return tablespoons;
        }

        static void Print(double cookingUnitAmount, string cookingUnit, double ml)
        {
            // string convertedDescription = teaspoonsText + " teaspoons = " + ml + " ml";
            // $- string interpolation
            // F2- 2 digits after decimal point.
            string convertedDescription = $"{cookingUnitAmount} {cookingUnit} = {ml:F2} ml";
            Console.WriteLine(convertedDescription);
        }
    }
}
