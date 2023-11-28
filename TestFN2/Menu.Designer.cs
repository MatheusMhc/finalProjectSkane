namespace SnakeGameSpace
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            label1 = new Label();
            pictureBox1 = new PictureBox();
            lblExit = new Label();
            lblAbout = new Label();
            lblNewGame = new Label();
            lblEasy = new Label();
            lblMedium = new Label();
            lblHard = new Label();
            loadingProgress = new ProgressBar();
            lblBack = new Label();
            lblAboutValue = new Label();
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
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
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
            lblExit.Click += lblExit_Click;
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
            lblAbout.Click += lblAbout_Click;
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
            // lblEasy
            // 
            lblEasy.AutoSize = true;
            lblEasy.Font = new Font("Snap ITC", 26F, FontStyle.Regular, GraphicsUnit.Point);
            lblEasy.Location = new Point(502, 173);
            lblEasy.Name = "lblEasy";
            lblEasy.Size = new Size(114, 45);
            lblEasy.TabIndex = 7;
            lblEasy.Text = "Easy";
            lblEasy.Click += lblEasy_Click;
            lblEasy.MouseLeave += lblEasy_MouseLeave;
            lblEasy.MouseMove += lblEasy_MouseMove;
            // 
            // lblMedium
            // 
            lblMedium.AutoSize = true;
            lblMedium.Font = new Font("Snap ITC", 26F, FontStyle.Regular, GraphicsUnit.Point);
            lblMedium.Location = new Point(478, 256);
            lblMedium.Name = "lblMedium";
            lblMedium.Size = new Size(170, 45);
            lblMedium.TabIndex = 8;
            lblMedium.Text = "Medium";
            lblMedium.Click += lblMedium_Click;
            lblMedium.MouseLeave += lblMedium_MouseLeave;
            lblMedium.MouseMove += lblMedium_MouseMove;
            // 
            // lblHard
            // 
            lblHard.AutoSize = true;
            lblHard.Font = new Font("Snap ITC", 26F, FontStyle.Regular, GraphicsUnit.Point);
            lblHard.Location = new Point(506, 341);
            lblHard.Name = "lblHard";
            lblHard.Size = new Size(116, 45);
            lblHard.TabIndex = 9;
            lblHard.Text = "Hard";
            lblHard.Click += lblHard_Click;
            lblHard.MouseLeave += lblHard_MouseLeave;
            lblHard.MouseMove += lblHard_MouseMove;
            // 
            // loadingProgress
            // 
            loadingProgress.ForeColor = SystemColors.MenuHighlight;
            loadingProgress.Location = new Point(23, 230);
            loadingProgress.Maximum = 400;
            loadingProgress.Name = "loadingProgress";
            loadingProgress.Size = new Size(765, 23);
            loadingProgress.TabIndex = 10;
            // 
            // lblBack
            // 
            lblBack.AutoSize = true;
            lblBack.Font = new Font("Snap ITC", 26F, FontStyle.Regular, GraphicsUnit.Point);
            lblBack.Location = new Point(655, 393);
            lblBack.Name = "lblBack";
            lblBack.Size = new Size(112, 45);
            lblBack.TabIndex = 11;
            lblBack.Text = "Back";
            lblBack.Click += lblBack_Click;
            lblBack.MouseLeave += lblBack_MouseLeave;
            lblBack.MouseMove += lblBack_MouseMove;
            // 
            // lblAboutValue
            // 
            lblAboutValue.AutoSize = true;
            lblAboutValue.Font = new Font("Snap ITC", 26F, FontStyle.Regular, GraphicsUnit.Point);
            lblAboutValue.Location = new Point(142, 208);
            lblAboutValue.Name = "lblAboutValue";
            lblAboutValue.Size = new Size(625, 45);
            lblAboutValue.TabIndex = 12;
            lblAboutValue.Text = "Developed by Matheus Colares";
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(loadingProgress);
            Controls.Add(lblAboutValue);
            Controls.Add(lblBack);
            Controls.Add(lblHard);
            Controls.Add(lblMedium);
            Controls.Add(lblEasy);
            Controls.Add(lblNewGame);
            Controls.Add(lblAbout);
            Controls.Add(lblExit);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Menu";
            Text = "Snake Game";
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
        private Label lblEasy;
        private Label lblMedium;
        private Label lblHard;
        public ProgressBar loadingProgress;
        private Label lblBack;
        private Label lblAboutValue;
    }
}