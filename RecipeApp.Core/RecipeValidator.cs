using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RecipeApp.Core
{
    public class RecipeValidator
    {
        [Obsolete("OpenFileDialog.Filter is sufficient!")]
        public static bool ValiateFile(string filename)
        {
            return Path.GetExtension(filename)?.Equals(".recipe") ?? false;
        }
    }
}
