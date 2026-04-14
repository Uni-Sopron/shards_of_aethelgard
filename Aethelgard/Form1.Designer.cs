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
            lblEnemyHp.Click += lblEnemyHp_Click;
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
            btnAttack.Location = new Point(369, 392);
            btnAttack.Name = "btnAttack";
            btnAttack.Size = new Size(107, 46);
            btnAttack.TabIndex = 5;
            btnAttack.Text = "Támadás";
            btnAttack.UseVisualStyleBackColor = true;
            btnAttack.Click += btnAttack_Click;
            // 
            // btnStartGame
            // 
            btnStartGame.Location = new Point(570, 398);
            btnStartGame.Name = "btnStartGame";
            btnStartGame.Size = new Size(94, 29);
            btnStartGame.TabIndex = 6;
            btnStartGame.Text = "Új Játék";
            btnStartGame.UseVisualStyleBackColor = true;
            btnStartGame.Click += btnStartGame_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
    }
}
