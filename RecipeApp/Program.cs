using System;

namespace RecipeApp
{
    class Program
    {
        // Here is a list of standard cooking units:
        //    Cup	0.24 l
        //    Gallon  3.79 l
        //    Fluid Ounce	29.57 ml
        //    Pint    0.47 l
        //    Quart   0.95 l
        //    Tablespoon  14.79 ml
        //    Teaspoon    4.93 ml

        static void Main(string[] args)
        {
            // Read user recipe from console
            // Don't allow empty recipe
            // Replace cooking units with ml
            // Make sure there is no 100 ml. That should be converted to 0.1 l.
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


        static double GetAmountFromConsole(string unit)
        {
            Console.WriteLine($"Please enter {unit} amount: ");
            var amountText = Console.ReadLine();
            double amount = double.Parse(amountText);

            return amount;
        }

        static double TeaspoonsToMl(double teaspoons)
        {
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
            string convertedDescription = $"{cookingUnitAmount} {cookingUnit} = {ml:F2} ml";
            Console.WriteLine(convertedDescription);
        }
    }
}
