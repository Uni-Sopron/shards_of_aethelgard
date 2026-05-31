namespace Aethelgard
{
    partial class StoryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StoryForm));
            rtbStoryText = new RichTextBox();
            btnClose = new Button();
            SuspendLayout();
            // 
            // rtbStoryText
            // 
            rtbStoryText.BorderStyle = BorderStyle.None;
            rtbStoryText.Location = new Point(156, 110);
            rtbStoryText.Name = "rtbStoryText";
            rtbStoryText.ReadOnly = true;
            rtbStoryText.Size = new Size(492, 222);
            rtbStoryText.TabIndex = 0;
            rtbStoryText.Text = resources.GetString("rtbStoryText.Text");
            // 
            // btnClose
            // 
            btnClose.Location = new Point(327, 399);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(94, 29);
            btnClose.TabIndex = 1;
            btnClose.Text = "Vissza";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // StoryForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnClose);
            Controls.Add(rtbStoryText);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "StoryForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "SoA";
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox rtbStoryText;
        private Button btnClose;
    }
}