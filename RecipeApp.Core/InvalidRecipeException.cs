using System;

namespace RecipeApp
{
    public class InvalidRecipeException : Exception
    {
        public InvalidRecipeException(string reason) : base(reason)
        {
        }
    }
}
