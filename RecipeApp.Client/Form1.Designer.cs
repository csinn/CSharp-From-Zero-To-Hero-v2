
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CookingUnitsRadioButton = new System.Windows.Forms.RadioButton();
            this.SiUnitsRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SourceRichTextBox
            // 
            this.SourceRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.SourceRichTextBox.Location = new System.Drawing.Point(20, 18);
            this.SourceRichTextBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.SourceRichTextBox.Name = "SourceRichTextBox";
            this.SourceRichTextBox.Size = new System.Drawing.Size(237, 290);
            this.SourceRichTextBox.TabIndex = 0;
            this.SourceRichTextBox.Text = "";
            // 
            // ResultRichTextBox
            // 
            this.ResultRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ResultRichTextBox.Location = new System.Drawing.Point(410, 18);
            this.ResultRichTextBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.ResultRichTextBox.Name = "ResultRichTextBox";
            this.ResultRichTextBox.Size = new System.Drawing.Size(228, 290);
            this.ResultRichTextBox.TabIndex = 1;
            this.ResultRichTextBox.Text = "";
            // 
            // LoadButton
            // 
            this.LoadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.LoadButton.Location = new System.Drawing.Point(258, 108);
            this.LoadButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(149, 22);
            this.LoadButton.TabIndex = 2;
            this.LoadButton.Text = "Load";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // ConvertButton
            // 
            this.ConvertButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ConvertButton.Location = new System.Drawing.Point(258, 141);
            this.ConvertButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.ConvertButton.Name = "ConvertButton";
            this.ConvertButton.Size = new System.Drawing.Size(149, 23);
            this.ConvertButton.TabIndex = 3;
            this.ConvertButton.Text = "Convert";
            this.ConvertButton.UseVisualStyleBackColor = true;
            this.ConvertButton.Click += new System.EventHandler(this.ConvertButton_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 315);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Source";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(390, 315);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Result";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CookingUnitsRadioButton);
            this.groupBox1.Controls.Add(this.SiUnitsRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(258, 185);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBox1.Size = new System.Drawing.Size(149, 50);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // CookingUnitsRadioButton
            // 
            this.CookingUnitsRadioButton.AutoSize = true;
            this.CookingUnitsRadioButton.Location = new System.Drawing.Point(4, 26);
            this.CookingUnitsRadioButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.CookingUnitsRadioButton.Name = "CookingUnitsRadioButton";
            this.CookingUnitsRadioButton.Size = new System.Drawing.Size(126, 19);
            this.CookingUnitsRadioButton.TabIndex = 1;
            this.CookingUnitsRadioButton.Text = "Cooking Units (Fix)";
            this.CookingUnitsRadioButton.UseVisualStyleBackColor = true;
            // 
            // SiUnitsRadioButton
            // 
            this.SiUnitsRadioButton.AutoSize = true;
            this.SiUnitsRadioButton.Checked = true;
            this.SiUnitsRadioButton.Location = new System.Drawing.Point(4, 6);
            this.SiUnitsRadioButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.SiUnitsRadioButton.Name = "SiUnitsRadioButton";
            this.SiUnitsRadioButton.Size = new System.Drawing.Size(64, 19);
            this.SiUnitsRadioButton.TabIndex = 0;
            this.SiUnitsRadioButton.TabStop = true;
            this.SiUnitsRadioButton.Text = "SI Units";
            this.SiUnitsRadioButton.UseVisualStyleBackColor = true;
            // 
            // RecipeApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 413);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ConvertButton);
            this.Controls.Add(this.LoadButton);
            this.Controls.Add(this.ResultRichTextBox);
            this.Controls.Add(this.SourceRichTextBox);
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.MinimumSize = new System.Drawing.Size(678, 452);
            this.Name = "RecipeApp";
            this.Text = "RecipeApp 1.0";
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton CookingUnitsRadioButton;
        private System.Windows.Forms.RadioButton SiUnitsRadioButton;
    }
}

