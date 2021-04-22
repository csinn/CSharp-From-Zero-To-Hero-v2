using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecipeApp.Client
{
    public partial class RecipeApp : Form
    {
        public RecipeApp()
        {
            InitializeComponent();
            RecipeConverter.InitialSetup();
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            SourceRichTextBox.Text = ReadContentsFromFileBrowser();
        }

        private static string ReadContentsFromFileBrowser()
        {
            // Prepare for browsing files
            using (var dialog = new OpenFileDialog())
            {
                // Adding restrictions and initial dialog settings:
                dialog.InitialDirectory = Environment.CurrentDirectory;
                dialog.Title = "Browse Recipe files";
                dialog.DefaultExt = "recipe";
                dialog.Filter = "recipe files (*.recipe)|*.recipe";

                // Browse files... if file was confirmed
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    // Read the contents of that file
                    var stream = dialog.OpenFile();
                    using (var reader = new StreamReader(stream))
                    {
                        
                        string recipeText = reader.ReadToEnd();
                        string validationText = RecipeConverter.RecipeValidation(recipeText);

                        // File validation:
                        if (validationText != "")
                        {
                            MessageBox.Show(validationText);
                        }
                        else {
                            return recipeText;
                        }
                    }
                }
            }
            // Happens if canceled.
            return string.Empty;
        }

        private void ConvertButton_Click(object sender, EventArgs e)
        {
            var isConvertToSiUnits = SiUnitsRadioButton.Checked;
            var input = SourceRichTextBox.Text;
            // Check the recipe
            string validationText = RecipeConverter.RecipeValidation(input);
            if (validationText == "")
            {
                ResultRichTextBox.Text = RecipeConverter.ConvertRecipe(input, isConvertToSiUnits);
            }
            else 
            {
                MessageBox.Show(validationText);
            }
        }
    }
}
