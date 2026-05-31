namespace Aethelgard
{
    partial class PuzzleForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblPuzzleError = new Label();
            txtPuzzleAnswer = new TextBox();
            btnSubmitPuzzle = new Button();
            rtbQuestion = new RichTextBox();
            SuspendLayout();
            // 
            // lblPuzzleError
            // 
            lblPuzzleError.AutoSize = true;
            lblPuzzleError.Location = new Point(361, 372);
            lblPuzzleError.Name = "lblPuzzleError";
            lblPuzzleError.Size = new Size(50, 20);
            lblPuzzleError.TabIndex = 1;
            lblPuzzleError.Text = "label1";
            // 
            // txtPuzzleAnswer
            // 
            txtPuzzleAnswer.Location = new Point(331, 318);
            txtPuzzleAnswer.Name = "txtPuzzleAnswer";
            txtPuzzleAnswer.Size = new Size(125, 27);
            txtPuzzleAnswer.TabIndex = 2;
            // 
            // btnSubmitPuzzle
            // 
            btnSubmitPuzzle.Location = new Point(494, 318);
            btnSubmitPuzzle.Name = "btnSubmitPuzzle";
            btnSubmitPuzzle.Size = new Size(85, 29);
            btnSubmitPuzzle.TabIndex = 3;
            btnSubmitPuzzle.Text = "Megoldás";
            btnSubmitPuzzle.TextAlign = ContentAlignment.BottomLeft;
            btnSubmitPuzzle.UseVisualStyleBackColor = true;
            btnSubmitPuzzle.Click += btnSubmitPuzzle_Click;
            // 
            // rtbQuestion
            // 
            rtbQuestion.BorderStyle = BorderStyle.None;
            rtbQuestion.Location = new Point(245, 72);
            rtbQuestion.Name = "rtbQuestion";
            rtbQuestion.ReadOnly = true;
            rtbQuestion.Size = new Size(294, 212);
            rtbQuestion.TabIndex = 4;
            rtbQuestion.Text = "";
            // 
            // PuzzleForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(rtbQuestion);
            Controls.Add(btnSubmitPuzzle);
            Controls.Add(txtPuzzleAnswer);
            Controls.Add(lblPuzzleError);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "PuzzleForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "SoA";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblPuzzleError;
        private TextBox txtPuzzleAnswer;
        private Button btnSubmitPuzzle;
        private RichTextBox rtbQuestion;
    }
}