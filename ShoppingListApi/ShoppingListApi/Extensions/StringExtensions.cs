namespace ShoppingListApi.Extensions
{
    public static class StringExtensions
    {
        // Capitalize first letter of a text.
        public static string CapitalizeFirstLetter(this string name)
        {
            return name[0].ToString().ToUpper() + name.Substring(1);
        }
    }
}
