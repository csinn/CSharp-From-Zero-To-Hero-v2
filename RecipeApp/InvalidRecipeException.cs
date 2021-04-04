using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeApp
{
    public class InvalidRecipeException : Exception
    {
        public InvalidRecipeException(string reason) : base(reason)
        {
        }
    }
}
