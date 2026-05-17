namespace Aethelgard
{
    partial class HarcForm
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
            lblPlayerHp = new Label();
            lblEnemyHp = new Label();
            btnAttack = new Button();
            btnNext = new Button();
            btnSpecialAttack = new Button();
            rtbLog = new RichTextBox();
            button2 = new Button();
            SuspendLayout();
            // 
            // lblPlayerHp
            // 
            lblPlayerHp.AutoSize = true;
            lblPlayerHp.Location = new Point(149, 256);
            lblPlayerHp.Name = "lblPlayerHp";
            lblPlayerHp.Size = new Size(50, 20);
            lblPlayerHp.TabIndex = 0;
            lblPlayerHp.Text = "label1";
            // 
            // lblEnemyHp
            // 
            lblEnemyHp.AutoSize = true;
            lblEnemyHp.Location = new Point(551, 256);
            lblEnemyHp.Name = "lblEnemyHp";
            lblEnemyHp.Size = new Size(50, 20);
            lblEnemyHp.TabIndex = 1;
            lblEnemyHp.Text = "label1";
            // 
            // btnAttack
            // 
            btnAttack.Location = new Point(244, 376);
            btnAttack.Name = "btnAttack";
            btnAttack.Size = new Size(94, 29);
            btnAttack.TabIndex = 2;
            btnAttack.Text = "Ütés";
            btnAttack.UseVisualStyleBackColor = true;
            btnAttack.Click += btnAttack_Click;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(641, 390);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(94, 29);
            btnNext.TabIndex = 3;
            btnNext.Text = "Következő";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // btnSpecialAttack
            // 
            btnSpecialAttack.Location = new Point(356, 376);
            btnSpecialAttack.Name = "btnSpecialAttack";
            btnSpecialAttack.Size = new Size(94, 29);
            btnSpecialAttack.TabIndex = 4;
            btnSpecialAttack.Text = "Képesség";
            btnSpecialAttack.UseVisualStyleBackColor = true;
            btnSpecialAttack.Click += btnSpecialAttack_Click;
            // 
            // rtbLog
            // 
            rtbLog.Location = new Point(135, 49);
            rtbLog.Name = "rtbLog";
            rtbLog.Size = new Size(497, 97);
            rtbLog.TabIndex = 5;
            rtbLog.Text = "";
            // 
            // button2
            // 
            button2.Location = new Point(641, 343);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 7;
            button2.Text = "Mentés";
            button2.UseVisualStyleBackColor = true;
            button2.Click += btnSave_Click;
            // 
            // HarcForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(rtbLog);
            Controls.Add(btnSpecialAttack);
            Controls.Add(btnNext);
            Controls.Add(btnAttack);
            Controls.Add(lblEnemyHp);
            Controls.Add(lblPlayerHp);
            Name = "HarcForm";
            Text = "HarcForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPlayerHp;
        private Label lblEnemyHp;
        private Button btnAttack;
        private Button btnNext;
        private Button btnSpecialAttack;
        private RichTextBox rtbLog;
        private Button button2;
    }
}