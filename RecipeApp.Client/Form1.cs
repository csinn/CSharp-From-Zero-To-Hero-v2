using BootCamp.Chapter;
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

        private void LoadButton_Click(object sender, EventArgs e)
        {
            SourceRichTextBox.Text = ReadContentsFromFileBrowser();
        }

        private static string ReadContentsFromFileBrowser()
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Filter = "Recipe files (*.recipe)|*.recipe";

                //dialog.InitialDirectory = Environment.CurrentDirectory;
                dialog.InitialDirectory = GlobalSettings.filePath;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var stream = dialog.OpenFile();

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
            var isSiUnitsButton = SiUnitsRadioButton.Checked;

            var sourceTextInput = SourceRichTextBox.Text;
            try
            {
                ResultRichTextBox.Text = RecipeConverter.ConvertRecipe(sourceTextInput, isSiUnitsButton);
            }
            catch (InvalidRecipeException ex)
            {
                MessageBox.Show($"Cannot convert recipe because: {ex.Message}");
            }

        }
    }
}