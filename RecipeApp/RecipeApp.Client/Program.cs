using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace RecipeApp.Client
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new RecipeApp());          
        }
    }
}
