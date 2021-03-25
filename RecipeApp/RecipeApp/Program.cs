//Import classes from system namespace
using System;

//Holder of classes
namespace RecipeApp
{
   /* Cup 0.24 l
    Gallon 3.79 l
    Fluid Ounce 29.57 ml
    Pint 0.47 l 
    Quart 0.95 l
    Tablespoon 14.79 ml
    Teaspoon 4.93 ml
   */

    //Holder of functions and data
    class Program
    {
        //The less a function implements itself- the higher level it is
        // Main function simply the application- so it is the highest level fucntion

        // Named block of code
        //strongly typed means that I don't need to guess what i can do with class or a variable
        // So, when i get errors, they will be before my application runs- in compile time.
        // Weekly typed means that here is no check on what a function or variable can do.
        // We can do that with dynamic keyword : dynamic a; a.IsPerfectly.Fine().
        static void Main(string[] args)
        {
            dynamic text = "abc";
            text = 1;
            text.This.Can.Be.Anything.Really();
            double totalMl = PrintTeaspoonsToMl() + PrintTablespoonsToMl();
            PrintHowMany100MlBottles(totalMl);
        }

        static double PrintTeaspoonsToMl() {
            var teaspoons = GetAmountFromConsole(unit: "teaspoons");
            var mlOfTeaspoons = TeaspoonsToml(teaspoons);
            Print(cookingUnitAmount: teaspoons, cookingUnit: "teaspoons", mlOfTeaspoons);
            return mlOfTeaspoons;
        }
        static double PrintTablespoonsToMl()
        {
            double tablespoons = GetAmountFromConsole(unit: "tablespoons");
            double mlOfTablespoons = TableSpoonsoMl(tablespoons);
            Print(cookingUnitAmount: tablespoons, cookingUnit: "teaspoons", mlOfTablespoons);
            return mlOfTablespoons;
        }
        //GetTeaspoonsFromConsole is a lower level function
        //Because it implements How we can read a number from console
        static void PrintHowMany100MlBottles(double totalMl) {
            // 1 / 0 = error
            // 1 / 2 = 0 you drop the fraction
            // int / int = int
            // 1.0 / 2 = 0.5
            // 1.0 + 1 = 2.0
            // double + int = double
            // We have bottles of 100ml
            // How many bottles can we fill after the conversion?
            // int is a whole number
            int bottlesCount = (int)(totalMl / 100) + 1;
            Console.WriteLine($"{totalMl:F2} can fill {bottlesCount} bottles of 100 ml");
        }
        static double GetAmountFromConsole(string unit) {

            Console.WriteLine($"Please enter {unit} amount:");
            // variable
            // holds data
            // type,name,value
            string amountText = Console.ReadLine();

            // Floating point number with double precision.
            double amount = double.Parse(amountText);

            return amount;
        }
        static double TeaspoonsToml(double teaspoons) {
            // 4.93m is a decimal
            // 4.93 is double
            // 4.93f is a float - use it when you don't plan to use math.
            double ml = teaspoons * 4.93;
            return ml;
        }

        static double TableSpoonsoMl(double tablespoons)
        {
            // 4.93m is a decimal
            // 4.93 is double
            // 4.93f is a float - use it when you don't plan to use math.
            double ml = tablespoons * 14.79;
            return ml;
        }

        static void Print(double cookingUnitAmount,string cookingUnit, double ml) {
            // just goes back to void Print if return is here;
            // for absolute accuracy- use decimal
            // string convertedDescription = teaspoonsText + " teaspoons = " + ml + " ml"; // same as the string convertion below
            // F2 - 2 digits after decimal point.
            string convertedDescription = $"{cookingUnitAmount} {cookingUnit} = {ml:F2} ml";   //always use this shit Readability is key
            Console.WriteLine(convertedDescription);
            //Console.WriteLine(teaspoonsText + " teaspoons = " + ml + " ml");
        }
    }
}
