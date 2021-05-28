using RecipeApp.Core.Services.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeApp.Core.Exceptions
{
    public class InvalidRecipeException : Exception
    {

        public InvalidRecipeException(string reason, ILogger logger = default) : base(reason)
        {
            logger?.Log(reason, LogLevel.Warning);
        }
    }
}
