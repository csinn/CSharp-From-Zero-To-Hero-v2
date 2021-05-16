using RecipeApp.Core.Services;
using RecipeApp.Core.Units;
using System;
using System.IO;
using System.Windows.Forms;

namespace RecipeApp.Client
{
    public partial class RecipeApp : Form
    {
        private readonly IUnitRepository _unitRepo;
        private readonly RecipeConverter _converter;
        private readonly RecipeValidator _validator;

        public RecipeApp()
        {
            InitializeComponent();

            _unitRepo = new UnitRepository();
            _converter = new RecipeConverter(_unitRepo);
            _validator = new RecipeValidator(_unitRepo);
        }

        private string ReadContentsFromFileBrowser()
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
            ResultRichTextBox.Text = _converter.ConvertRecipe(input, isConvertToSiUnits);
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            string recipe = ReadContentsFromFileBrowser();

            if (string.IsNullOrWhiteSpace(recipe)) recipe = "Recipe must contain something.";
            if (!_validator.ValidateUnitsHaveAmounts(recipe)) recipe = "Recipe must contain same number of units and amounts.";

            SourceRichTextBox.Text = recipe;
        }

        private void PrettyButton_Click(object sender, EventArgs e)
        {
            var input = SourceRichTextBox.Text;
            ResultRichTextBox.Text = _converter.UseLargerUnits(input);
        }
    }
}