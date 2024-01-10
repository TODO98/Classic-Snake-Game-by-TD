using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Drawing.Imaging; // add this for the JPG compressor


namespace Classic_Snake_Game
{
    public partial class Form1 : Form
    {

        private List <Circle> Snake = new List<Circle>();
        private Circle food = new Circle();

        int maxWidth;   
        int maxHeight;

        int score;
        int highScore;

        Random rand = new Random();

        bool goLeft, goRight, goDown, goUp;


        public Form1()
        {
            InitializeComponent();

            new Settings();
        }

      

        private void keyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && Settings.directions != "right")
            {
                goLeft = true;
            }

            if (e.KeyCode == Keys.Right && Settings.directions != "left")
            {
                goRight = true;
            }

            if (e.KeyCode == Keys.Up && Settings.directions != "down")
            {
                goUp = true;
            }

            if (e.KeyCode == Keys.Down && Settings.directions != "up")
            {
                goDown = true;
            }
        }

        private void keyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }

            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }

            if (e.KeyCode == Keys.Up)
            {
                goUp = false;
            }

            if (e.KeyCode == Keys.Down)
            {
                goDown = false;
            }

        }

        private void startGame(object sender, EventArgs e)
        {
            restartGame();
        }

        private void takeSnapShot(object sender, MouseEventArgs e)
        {
            Label caption = new Label();
            caption.Text = "I scored: " + score + " and my Highscore is " + highScore + " on the Classic Snake Game by TD";
            caption.Font = new Font("Showcard Gothic", 9, FontStyle.Regular);
            caption.ForeColor = Color.Purple;
            caption.AutoSize = false;
            caption.Width = picCanvas.Width;
            caption.Height = 30;
            caption.TextAlign = ContentAlignment.MiddleCenter;
            picCanvas.Controls.Add(caption);

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.FileName = "Snake Game SnapShot";
            dialog.DefaultExt = "jpg";
            dialog.Filter = "JPG Image File | *.jpg";
            dialog.ValidateNames = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                int width = Convert.ToInt32(picCanvas.Width);
                int height = Convert.ToInt32(picCanvas.Height);
                Bitmap bmp = new Bitmap(width, height);
                picCanvas.DrawToBitmap(bmp, new Rectangle(0, 0, width, height));
                bmp.Save(dialog.FileName, ImageFormat.Jpeg);
                picCanvas.Controls.Remove(caption);
            }


        }

        private void gameTimerEvent(object sender, EventArgs e)
        {

            // bestämmer vilket håll ormen ska röra sig i

            if (goLeft)
            {
                Settings.directions = "left";
            }
            if (goRight)
            {
                Settings.directions = "right";
            }
            if (goDown)
            {
                Settings.directions = "down";
            }
            if (goUp)
            {
                Settings.directions = "up";
            }
            // nästa

            for (int i = Snake.Count - 1; i >= 0; i--)
            {
                if (i == 0)
                {

                    switch (Settings.directions)
                    {
                        case "left":
                            Snake[i].X--;
                            break;
                        case "right":
                            Snake[i].X++;
                            break;
                        case "down":
                            Snake[i].Y++;
                            break;
                        case "up":
                            Snake[i].Y--;
                            break;
                    }

                    if (Snake[i].X < 0)
                    {
                        Snake[i].X = maxWidth;
                    }
                    if (Snake[i].X > maxWidth)
                    {
                        Snake[i].X = 0;
                    }
                    if (Snake[i].Y < 0)
                    {
                        Snake[i].Y = maxHeight;
                    }
                    if (Snake[i].Y > maxHeight)
                    {
                        Snake[i].Y = 0;
                    }


                    if (Snake[i].X == food.X && Snake[i].Y == food.Y)
                    {
                        EatFood();
                    }

                    for (int j = 1; j < Snake.Count; j++)
                    {

                        if (Snake[i].X == Snake[j].X && Snake[i].Y == Snake[j].Y)
                        {
                            gameOver();
                        }

                    }


                }
                else
                {
                    Snake[i].X = Snake[i - 1].X;
                    Snake[i].Y = Snake[i - 1].Y;
                }
            }


            picCanvas.Invalidate(); // uppdaterar canvasen

        }


        private void updatePictureBoxGraphics(object sender, PaintEventArgs e)
        {
           Graphics canvas = e.Graphics; // skapar en canvas som vi kan rita på linkad till Paint eventet

            Brush snakeColour;

            for (int i = 0; i < Snake.Count; i++)  // ritar ut ormen
            {
                if (i == 0)
                {
                    snakeColour = Brushes.Black;  // huvudet
                }
                else
                {
                    snakeColour = Brushes.Green;  // kroppen
                }

                canvas.FillEllipse(snakeColour, new Rectangle
                    (
                    Snake[i].X * Settings.Width,
                    Snake[i].Y * Settings.Height,
                    Settings.Width, Settings.Height));  // ritar ut ormen

                canvas.FillEllipse (Brushes.Red, new Rectangle
                    (
                    food.X * Settings.Width,
                    food.Y * Settings.Height,
                    Settings.Width, Settings.Height));  // ritar ut maten
            }
        }


        private void restartGame ()
        {
            maxWidth = picCanvas.Size.Width / Settings.Width - 1;
            maxHeight = picCanvas.Size.Height / Settings.Height - 1;
           
            Snake.Clear();  // rensar listan

            startButton.Enabled  = false;
            snapButton.Enabled = false;
            score = 0;
            txtScore.Text = "Score: " + score;

            Circle head = new Circle{X = 10, Y = 5};  // ser till att ormens huvud är i mitten av spelplanen
            Snake.Add(head);         // lägger till huvudet i listan <Circle>

            for (int i = 0; i < 10; i++)  //lägger till 10 mer kroppsdelar till ormen
            {
                Circle body = new Circle();
                Snake.Add(body);
            }
            food = new Circle { X = rand.Next(2, maxWidth), Y = rand.Next(2, maxHeight) };  // slumpar ut maten på spelplanen (2 för att inte hamna utanför spelplanen)

            gameTimer.Start();



        }

        private void EatFood ()
        {
            score += 1;

            txtScore.Text = "Score: " + score;

            Circle body = new Circle
            {
                X = Snake[Snake.Count - 1].X,
                Y = Snake[Snake.Count - 1].Y
            };

            Snake.Add(body);

            food = new Circle { X = rand.Next(2, maxWidth), Y = rand.Next(2, maxHeight) };  // slumpar ut maten på spelplanen (2 för att inte hamna utanför spelplanen)



        }   

        private void gameOver ()
        {
            gameTimer.Stop();
            startButton.Enabled = true;
            snapButton.Enabled = true;

            if (score > highScore)
            {
                highScore = score;

                txtHighScore.Text = "High Score: " + Environment.NewLine + highScore;
                txtHighScore.ForeColor = Color.Maroon;
                txtHighScore.TextAlign = ContentAlignment.MiddleCenter;
            }
        }

    }
}

