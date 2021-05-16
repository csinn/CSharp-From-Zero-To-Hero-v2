using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeApp.Core.Exceptions
{
    public class UnitNotFoundException : Exception
    {
        public UnitNotFoundException(string reason) : base(reason)
        {
        }
    }
}
