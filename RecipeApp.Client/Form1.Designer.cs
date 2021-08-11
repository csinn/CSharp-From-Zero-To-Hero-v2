
namespace RecipeApp.Client
{
    partial class RecipeApp
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SourceRichTextBox = new System.Windows.Forms.RichTextBox();
            this.ResultRichTextBox = new System.Windows.Forms.RichTextBox();
            this.LoadButton = new System.Windows.Forms.Button();
            this.ConvertButton = new System.Windows.Forms.Button();
            this.SourceLabel = new System.Windows.Forms.Label();
            this.ResultLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CookingUnitsRadioButton = new System.Windows.Forms.RadioButton();
            this.SIUnitsRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SourceRichTextBox
            // 
            this.SourceRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.SourceRichTextBox.Location = new System.Drawing.Point(12, 12);
            this.SourceRichTextBox.Name = "SourceRichTextBox";
            this.SourceRichTextBox.Size = new System.Drawing.Size(192, 303);
            this.SourceRichTextBox.TabIndex = 0;
            this.SourceRichTextBox.Text = "";
            // 
            // ResultRichTextBox
            // 
            this.ResultRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ResultRichTextBox.Location = new System.Drawing.Point(327, 15);
            this.ResultRichTextBox.Name = "ResultRichTextBox";
            this.ResultRichTextBox.Size = new System.Drawing.Size(192, 303);
            this.ResultRichTextBox.TabIndex = 1;
            this.ResultRichTextBox.Text = "";
            // 
            // LoadButton
            // 
            this.LoadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.LoadButton.Location = new System.Drawing.Point(210, 68);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(111, 49);
            this.LoadButton.TabIndex = 2;
            this.LoadButton.Text = "Load";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // ConvertButton
            // 
            this.ConvertButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ConvertButton.Location = new System.Drawing.Point(210, 123);
            this.ConvertButton.Name = "ConvertButton";
            this.ConvertButton.Size = new System.Drawing.Size(111, 49);
            this.ConvertButton.TabIndex = 3;
            this.ConvertButton.Text = "Convert";
            this.ConvertButton.UseVisualStyleBackColor = true;
            this.ConvertButton.Click += new System.EventHandler(this.ConvertButton_Click);
            // 
            // SourceLabel
            // 
            this.SourceLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SourceLabel.AutoSize = true;
            this.SourceLabel.Location = new System.Drawing.Point(13, 319);
            this.SourceLabel.Name = "SourceLabel";
            this.SourceLabel.Size = new System.Drawing.Size(43, 15);
            this.SourceLabel.TabIndex = 4;
            this.SourceLabel.Text = "Source";
            // 
            // ResultLabel
            // 
            this.ResultLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ResultLabel.AutoSize = true;
            this.ResultLabel.Location = new System.Drawing.Point(327, 319);
            this.ResultLabel.Name = "ResultLabel";
            this.ResultLabel.Size = new System.Drawing.Size(39, 15);
            this.ResultLabel.TabIndex = 5;
            this.ResultLabel.Text = "Result";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CookingUnitsRadioButton);
            this.groupBox1.Controls.Add(this.SIUnitsRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(210, 177);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(111, 140);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // CookingUnitsRadioButton
            // 
            this.CookingUnitsRadioButton.AutoSize = true;
            this.CookingUnitsRadioButton.Location = new System.Drawing.Point(5, 47);
            this.CookingUnitsRadioButton.Name = "CookingUnitsRadioButton";
            this.CookingUnitsRadioButton.Size = new System.Drawing.Size(100, 19);
            this.CookingUnitsRadioButton.TabIndex = 1;
            this.CookingUnitsRadioButton.Text = "Cooking Units";
            this.CookingUnitsRadioButton.UseVisualStyleBackColor = true;
            // 
            // SIUnitsRadioButton
            // 
            this.SIUnitsRadioButton.AutoSize = true;
            this.SIUnitsRadioButton.Checked = true;
            this.SIUnitsRadioButton.Location = new System.Drawing.Point(6, 22);
            this.SIUnitsRadioButton.Name = "SIUnitsRadioButton";
            this.SIUnitsRadioButton.Size = new System.Drawing.Size(64, 19);
            this.SIUnitsRadioButton.TabIndex = 0;
            this.SIUnitsRadioButton.TabStop = true;
            this.SIUnitsRadioButton.Text = "SI Units";
            this.SIUnitsRadioButton.UseVisualStyleBackColor = true;
            // 
            // RecipeApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 374);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ResultLabel);
            this.Controls.Add(this.SourceLabel);
            this.Controls.Add(this.ConvertButton);
            this.Controls.Add(this.LoadButton);
            this.Controls.Add(this.ResultRichTextBox);
            this.Controls.Add(this.SourceRichTextBox);
            this.Name = "RecipeApp";
            this.Text = "RecipeApp";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox SourceRichTextBox;
        private System.Windows.Forms.RichTextBox ResultRichTextBox;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.Button ConvertButton;
        private System.Windows.Forms.Label SourceLabel;
        private System.Windows.Forms.Label ResultLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton CookingUnitsRadioButton;
        private System.Windows.Forms.RadioButton SIUnitsRadioButton;
    }
}

