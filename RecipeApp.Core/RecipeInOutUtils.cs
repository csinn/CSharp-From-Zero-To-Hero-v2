using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RecipeApp.Core
{
    public class RecipeInOutUtils
    {
        public static string ReadTextFromFile(Stream stream)
        {
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
