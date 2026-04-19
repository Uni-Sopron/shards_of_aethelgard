namespace Aethelgard
{
    partial class Form1
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
            lblPlayerHp = new Label();
            progressBar1 = new ProgressBar();
            progressBar2 = new ProgressBar();
            lblEnemyHp = new Label();
            rtbLog = new RichTextBox();
            btnAttack = new Button();
            btnStartGame = new Button();
            txtPlayerName = new TextBox();
            label1 = new Label();
            cmbClassSelect = new ComboBox();
            btnSave = new Button();
            btnLoad = new Button();
            btnNextEnemy = new Button();
            SuspendLayout();
            // 
            // lblPlayerHp
            // 
            lblPlayerHp.AutoSize = true;
            lblPlayerHp.Location = new Point(133, 289);
            lblPlayerHp.Name = "lblPlayerHp";
            lblPlayerHp.Size = new Size(75, 20);
            lblPlayerHp.TabIndex = 0;
            lblPlayerHp.Text = "Te HP-d: -";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(116, 312);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(125, 29);
            progressBar1.TabIndex = 1;
            // 
            // progressBar2
            // 
            progressBar2.Location = new Point(510, 312);
            progressBar2.Name = "progressBar2";
            progressBar2.Size = new Size(125, 29);
            progressBar2.TabIndex = 3;
            // 
            // lblEnemyHp
            // 
            lblEnemyHp.AutoSize = true;
            lblEnemyHp.Location = new Point(519, 289);
            lblEnemyHp.Name = "lblEnemyHp";
            lblEnemyHp.Size = new Size(100, 20);
            lblEnemyHp.TabIndex = 2;
            lblEnemyHp.Text = "Ellenség HP: -";
            // 
            // rtbLog
            // 
            rtbLog.Location = new Point(102, 33);
            rtbLog.Name = "rtbLog";
            rtbLog.Size = new Size(549, 71);
            rtbLog.TabIndex = 4;
            rtbLog.Text = "";
            // 
            // btnAttack
            // 
            btnAttack.Location = new Point(324, 392);
            btnAttack.Name = "btnAttack";
            btnAttack.Size = new Size(107, 46);
            btnAttack.TabIndex = 5;
            btnAttack.Text = "Támadás";
            btnAttack.UseVisualStyleBackColor = true;
            btnAttack.Click += btnAttack_Click;
            // 
            // btnStartGame
            // 
            btnStartGame.Location = new Point(641, 402);
            btnStartGame.Name = "btnStartGame";
            btnStartGame.Size = new Size(94, 29);
            btnStartGame.TabIndex = 6;
            btnStartGame.Text = "Új Játék";
            btnStartGame.UseVisualStyleBackColor = true;
            btnStartGame.Click += btnStartGame_Click;
            // 
            // txtPlayerName
            // 
            txtPlayerName.Location = new Point(491, 402);
            txtPlayerName.Name = "txtPlayerName";
            txtPlayerName.Size = new Size(125, 27);
            txtPlayerName.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(510, 379);
            label1.Name = "label1";
            label1.Size = new Size(73, 20);
            label1.TabIndex = 8;
            label1.Text = "Hős neve:";
            // 
            // cmbClassSelect
            // 
            cmbClassSelect.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbClassSelect.FormattingEnabled = true;
            cmbClassSelect.Location = new Point(77, 401);
            cmbClassSelect.Name = "cmbClassSelect";
            cmbClassSelect.Size = new Size(151, 28);
            cmbClassSelect.TabIndex = 9;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(694, 33);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 10;
            btnSave.Text = "Mentés";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(694, 75);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(94, 29);
            btnLoad.TabIndex = 11;
            btnLoad.Text = "Betöltés";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnNextEnemy
            // 
            btnNextEnemy.Enabled = false;
            btnNextEnemy.Location = new Point(324, 355);
            btnNextEnemy.Name = "btnNextEnemy";
            btnNextEnemy.Size = new Size(107, 31);
            btnNextEnemy.TabIndex = 12;
            btnNextEnemy.Text = "Következő";
            btnNextEnemy.UseVisualStyleBackColor = true;
            btnNextEnemy.Click += btnNextEnemy_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnNextEnemy);
            Controls.Add(btnLoad);
            Controls.Add(btnSave);
            Controls.Add(cmbClassSelect);
            Controls.Add(label1);
            Controls.Add(txtPlayerName);
            Controls.Add(btnStartGame);
            Controls.Add(btnAttack);
            Controls.Add(rtbLog);
            Controls.Add(progressBar2);
            Controls.Add(lblEnemyHp);
            Controls.Add(progressBar1);
            Controls.Add(lblPlayerHp);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPlayerHp;
        private ProgressBar progressBar1;
        private ProgressBar progressBar2;
        private Label lblEnemyHp;
        private RichTextBox rtbLog;
        private Button btnAttack;
        private Button btnStartGame;
        private TextBox txtPlayerName;
        private Label label1;
        private ComboBox cmbClassSelect;
        private Button btnSave;
        private Button btnLoad;
        private Button btnNextEnemy;
    }
}
