using System;

namespace RecipeApp.Core
{
    public class InvalidRecipeException : Exception
    {
        public InvalidRecipeException(string reason) : base(reason)
        {
        }
    }

    public class NoNonRecipeFilesException : Exception
    {
        public NoNonRecipeFilesException(string reason) : base(reason)
        {
        }
    }
}