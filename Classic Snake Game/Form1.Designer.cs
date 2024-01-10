namespace Classic_Snake_Game
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
            components = new System.ComponentModel.Container();
            startButton = new Button();
            snapButton = new Button();
            picCanvas = new PictureBox();
            txtScore = new Label();
            txtHighScore = new Label();
            gameTimer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)picCanvas).BeginInit();
            SuspendLayout();
            // 
            // startButton
            // 
            startButton.BackColor = Color.Lime;
            startButton.Font = new Font("Showcard Gothic", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            startButton.Location = new Point(613, 12);
            startButton.Name = "startButton";
            startButton.Size = new Size(121, 74);
            startButton.TabIndex = 0;
            startButton.Text = "Start";
            startButton.UseVisualStyleBackColor = false;
            startButton.Click += startGame;
            // 
            // snapButton
            // 
            snapButton.BackColor = Color.Aquamarine;
            snapButton.Font = new Font("Showcard Gothic", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            snapButton.Location = new Point(613, 92);
            snapButton.Name = "snapButton";
            snapButton.Size = new Size(121, 74);
            snapButton.TabIndex = 2;
            snapButton.Text = "Snap";
            snapButton.UseVisualStyleBackColor = false;
            snapButton.MouseClick += takeSnapShot;
            // 
            // picCanvas
            // 
            picCanvas.BackColor = Color.Silver;
            picCanvas.Location = new Point(12, 12);
            picCanvas.Name = "picCanvas";
            picCanvas.Size = new Size(580, 680);
            picCanvas.TabIndex = 3;
            picCanvas.TabStop = false;
            picCanvas.Paint += updatePictureBoxGraphics;
            // 
            // txtScore
            // 
            txtScore.AutoSize = true;
            txtScore.Font = new Font("Showcard Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtScore.Location = new Point(626, 202);
            txtScore.Name = "txtScore";
            txtScore.Size = new Size(97, 26);
            txtScore.TabIndex = 4;
            txtScore.Text = "Score: 0";
            // 
            // txtHighScore
            // 
            txtHighScore.AutoSize = true;
            txtHighScore.Font = new Font("Showcard Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtHighScore.Location = new Point(603, 240);
            txtHighScore.Name = "txtHighScore";
            txtHighScore.Size = new Size(131, 26);
            txtHighScore.TabIndex = 5;
            txtHighScore.Text = "High Score";
            // 
            // gameTimer
            // 
            gameTimer.Interval = 50;
            gameTimer.Tick += gameTimerEvent;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(746, 717);
            Controls.Add(txtHighScore);
            Controls.Add(txtScore);
            Controls.Add(picCanvas);
            Controls.Add(snapButton);
            Controls.Add(startButton);
            Name = "Form1";
            Text = "Classic Snake Game by TD";
            KeyDown += keyIsDown;
            KeyUp += keyIsUp;
            ((System.ComponentModel.ISupportInitialize)picCanvas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button startButton;
        private Button snapButton;
        private PictureBox picCanvas;
        private Label txtScore;
        private Label txtHighScore;
        private System.Windows.Forms.Timer gameTimer;
    }
}
