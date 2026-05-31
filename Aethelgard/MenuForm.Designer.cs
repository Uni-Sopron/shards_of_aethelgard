namespace Aethelgard
{
    partial class MenuForm
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
            txtPlayerName = new TextBox();
            cmbClassSelect = new ComboBox();
            btnNewGame = new Button();
            btnLoadGame = new Button();
            btnStory = new Button();
            btnExit = new Button();
            SuspendLayout();
            // 
            // txtPlayerName
            // 
            txtPlayerName.Location = new Point(304, 392);
            txtPlayerName.Name = "txtPlayerName";
            txtPlayerName.Size = new Size(125, 27);
            txtPlayerName.TabIndex = 0;
            // 
            // cmbClassSelect
            // 
            cmbClassSelect.FormattingEnabled = true;
            cmbClassSelect.Items.AddRange(new object[] { "Rúnaharcos", "Számmágus", "Árnyékalgoritmus" });
            cmbClassSelect.Location = new Point(553, 356);
            cmbClassSelect.Name = "cmbClassSelect";
            cmbClassSelect.Size = new Size(151, 28);
            cmbClassSelect.TabIndex = 1;
            // 
            // btnNewGame
            // 
            btnNewGame.Location = new Point(42, 132);
            btnNewGame.Name = "btnNewGame";
            btnNewGame.Size = new Size(94, 50);
            btnNewGame.TabIndex = 2;
            btnNewGame.Text = "Új játék";
            btnNewGame.UseVisualStyleBackColor = true;
            btnNewGame.Click += btnNewGame_Click;
            // 
            // btnLoadGame
            // 
            btnLoadGame.Location = new Point(42, 188);
            btnLoadGame.Name = "btnLoadGame";
            btnLoadGame.Size = new Size(94, 52);
            btnLoadGame.TabIndex = 3;
            btnLoadGame.Text = "Játék betöltése";
            btnLoadGame.UseVisualStyleBackColor = true;
            btnLoadGame.Click += btnLoadGame_Click;
            // 
            // btnStory
            // 
            btnStory.Location = new Point(42, 263);
            btnStory.Name = "btnStory";
            btnStory.Size = new Size(94, 40);
            btnStory.TabIndex = 4;
            btnStory.Text = "Történet";
            btnStory.UseVisualStyleBackColor = true;
            btnStory.Click += btnStory_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(42, 390);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(94, 29);
            btnExit.TabIndex = 5;
            btnExit.Text = "Kilépés";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // MenuForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnExit);
            Controls.Add(btnStory);
            Controls.Add(btnLoadGame);
            Controls.Add(btnNewGame);
            Controls.Add(cmbClassSelect);
            Controls.Add(txtPlayerName);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MenuForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MenuForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtPlayerName;
        private ComboBox cmbClassSelect;
        private Button btnNewGame;
        private Button btnLoadGame;
        private Button btnStory;
        private Button btnExit;
    }
}