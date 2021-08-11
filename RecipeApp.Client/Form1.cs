using System;
using System.IO;
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
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select Recipe";
                openFileDialog.Filter = "Recipe files (*.recipe)|*.recipe"; // will only let extension be .recipe

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var stream = openFileDialog.OpenFile();
                    using (var reader = new StreamReader(stream))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }

            return string.Empty;
        }

        private void ConvertButton_Click(object sender, EventArgs e)
        {
            string input = SourceRichTextBox.Text;
            bool isConvertToSiUnit = SIUnitsRadioButton.Checked;
            string converted;

            try
            {
                bool isValidRecipe = RecipeConverter.ValidateRecipe(input, isConvertToSiUnit);

                if (isValidRecipe)
                {
                    converted = RecipeConverter.CallConversion(input, isConvertToSiUnit);
                    ResultRichTextBox.Text = converted;
                }
            }
            catch (InvalidRecipeException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (NoNonRecipeFilesException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}