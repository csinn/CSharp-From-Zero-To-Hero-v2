using RecipeApp.Core.Services.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeApp.Core.Exceptions
{
    public class UnitNotFoundException : Exception
    {
        public UnitNotFoundException(string reason, ILogger logger = default) : base(reason)
        {
            logger?.Log(reason, LogLevel.Warning);
        }
    }
}
