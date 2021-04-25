using RecipeApp.Core;
using System;
using System.IO;
using System.Windows.Forms;

namespace RecipeApp.Client
{
    public partial class RecipeApp : Form
    {
        public RecipeApp()
        {
            InitializeComponent();
        }

        private static string ReadContentsFromFileBrowser()
        {
            // Prepare for browsing files
            using (var dialog = new OpenFileDialog())
            {
                dialog.Filter = "Recipes (*.recipe)|*.recipe";

                // Browse files... if file was confirmed
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    // Read the contents of that file
                    var stream = dialog.OpenFile();
                    using (var reader = new StreamReader(stream))
                    {
                        return reader.ReadToEnd();
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
            ResultRichTextBox.Text = RecipeConverter.ConvertRecipe(input, isConvertToSiUnits);
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            string recipe = ReadContentsFromFileBrowser();

            if (string.IsNullOrWhiteSpace(recipe)) recipe = "Recipe must contain something.";
            if (!RecipeValidator.ValidateUnitsHaveAmounts(recipe)) recipe = "Recipe must contain same number of units and amounts.";

            SourceRichTextBox.Text = recipe;
        }

        private void PrettyButton_Click(object sender, EventArgs e)
        {
            var input = SourceRichTextBox.Text;
            ResultRichTextBox.Text = RecipeConverter.MakeUnitsPretty(input);
        }
    }
}