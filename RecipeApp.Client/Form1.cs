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
using RecipeApp.Core;

namespace RecipeApp.Client
{
    public partial class RecipeApp : Form
    {
        public RecipeApp()
        {
            InitializeComponent();
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
                // Browse files... if file was confirmed
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    ValidateRecipeFileExtension(dialog);

                    // Read the contents of that file
                    var stream = dialog.OpenFile();
                    var recipe = RecipeInOutUtils.ReadTextFromFile(stream);
                    RecipeValidator.ValidateRecipeUnits(recipe);

                    return recipe;
                }
            }

            // Happens if canceled.
            return string.Empty;
        }

        static void ValidateRecipeFileExtension(OpenFileDialog dialog)
        {
            var fileExtensionEndsWithRecipe = dialog.FileName.EndsWith(".recipe");
            if (!fileExtensionEndsWithRecipe)
                throw new InvalidRecipeException("File extension has to be .recipe");
        }

        private void ConvertButton_Click(object sender, EventArgs e)
        {
            var isConvertToSiUnits = SiUnitsRadioButton.Checked;
            var input = SourceRichTextBox.Text;
            ResultRichTextBox.Text = RecipeConverter.ConvertRecipe(input, isConvertToSiUnits);
        }

        private void RecipeApp_Load(object sender, EventArgs e)
        {

        }
    }
}
