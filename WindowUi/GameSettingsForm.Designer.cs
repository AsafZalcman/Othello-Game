namespace WindowUi
{
    public partial class GameSettingsForm
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
            this.BoardSizeButton = new System.Windows.Forms.Button();
            this.PlayerVsPlayerButton = new System.Windows.Forms.Button();
            this.PlayerVsPcButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BoardSizeButton
            // 
            this.BoardSizeButton.Location = new System.Drawing.Point(27, 12);
            this.BoardSizeButton.Name = "BoardSizeButton";
            this.BoardSizeButton.Size = new System.Drawing.Size(286, 47);
            this.BoardSizeButton.TabIndex = 0;
            this.BoardSizeButton.UseVisualStyleBackColor = true;
            this.BoardSizeButton.Click += new System.EventHandler(this.BoardSizeButton_Click);
            // 
            // PlayerVsPlayerButton
            // 
            this.PlayerVsPlayerButton.Location = new System.Drawing.Point(191, 81);
            this.PlayerVsPlayerButton.Name = "PlayerVsPlayerButton";
            this.PlayerVsPlayerButton.Size = new System.Drawing.Size(122, 59);
            this.PlayerVsPlayerButton.TabIndex = 1;
            this.PlayerVsPlayerButton.Text = "Play against your friend";
            this.PlayerVsPlayerButton.UseVisualStyleBackColor = true;
            this.PlayerVsPlayerButton.Click += new System.EventHandler(this.PlayerVsPlayerButton_Click);
            // 
            // PlayerVsPcButton
            // 
            this.PlayerVsPcButton.Location = new System.Drawing.Point(27, 81);
            this.PlayerVsPcButton.Name = "PlayerVsPcButton";
            this.PlayerVsPcButton.Size = new System.Drawing.Size(122, 59);
            this.PlayerVsPcButton.TabIndex = 2;
            this.PlayerVsPcButton.Text = "Play against the computer";
            this.PlayerVsPcButton.UseVisualStyleBackColor = true;
            this.PlayerVsPcButton.Click += new System.EventHandler(this.PlayerVsPcButton_Click);
            // 
            // GameSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 162);
            this.Controls.Add(this.PlayerVsPcButton);
            this.Controls.Add(this.PlayerVsPlayerButton);
            this.Controls.Add(this.BoardSizeButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Othello - Game Settings";
            this.Load += new System.EventHandler(this.GameSettingsForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BoardSizeButton;
        private System.Windows.Forms.Button PlayerVsPlayerButton;
        private System.Windows.Forms.Button PlayerVsPcButton;
    }
}