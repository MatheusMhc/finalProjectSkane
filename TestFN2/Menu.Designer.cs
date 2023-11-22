namespace TestFN2
{
    partial class Menu
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
            label1 = new Label();
            pictureBox1 = new PictureBox();
            lblExit = new Label();
            lblAbout = new Label();
            lblNewGame = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Snap ITC", 46F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(317, 81);
            label1.Name = "label1";
            label1.Size = new Size(454, 80);
            label1.TabIndex = 1;
            label1.Text = "Snake Game";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.snake1_inPixio__1_;
            pictureBox1.Location = new Point(12, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(437, 436);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // lblExit
            // 
            lblExit.AutoSize = true;
            lblExit.Font = new Font("Snap ITC", 26F, FontStyle.Regular, GraphicsUnit.Point);
            lblExit.Location = new Point(506, 296);
            lblExit.Name = "lblExit";
            lblExit.Size = new Size(112, 45);
            lblExit.TabIndex = 4;
            lblExit.Text = "Exit";
            lblExit.MouseLeave += lblExit_MouseLeave;
            lblExit.MouseMove += lblExit_MouseMove;
            // 
            // lblAbout
            // 
            lblAbout.AutoSize = true;
            lblAbout.Font = new Font("Snap ITC", 26F, FontStyle.Regular, GraphicsUnit.Point);
            lblAbout.Location = new Point(491, 237);
            lblAbout.Name = "lblAbout";
            lblAbout.Size = new Size(137, 45);
            lblAbout.TabIndex = 5;
            lblAbout.Text = "About";
            lblAbout.MouseLeave += lblAbout_MouseLeave;
            lblAbout.MouseMove += lblAbout_MouseMove;
            // 
            // lblNewGame
            // 
            lblNewGame.AutoSize = true;
            lblNewGame.Font = new Font("Snap ITC", 26F, FontStyle.Regular, GraphicsUnit.Point);
            lblNewGame.Location = new Point(455, 182);
            lblNewGame.Name = "lblNewGame";
            lblNewGame.Size = new Size(228, 45);
            lblNewGame.TabIndex = 6;
            lblNewGame.Text = "New Game";
            lblNewGame.MouseClick += lblNewGame_MouseClick;
            lblNewGame.MouseLeave += lblNewGame_MouseLeave;
            lblNewGame.MouseMove += lblNewGame_MouseMove;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblNewGame);
            Controls.Add(lblAbout);
            Controls.Add(lblExit);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Name = "Menu";
            Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private PictureBox pictureBox1;
        private Label lblExit;
        private Label lblAbout;
        private Label lblNewGame;
    }
}