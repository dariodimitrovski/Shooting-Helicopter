using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shooting_Helicopter
{
    public partial class Form1 : Form
    {
        public bool goUp { get; set; }
        public bool goDown { get; set; }
        public bool shot { get; set; }
        public bool gameOver { get; set; }
        public int playerSpeed { get; set; } = 7;
        public int index { get; set; } = 0;
        public int speed { get; set; } = 8;
        public int UFOSpeed { get; set; } = 10;
        public int score { get; set; } = 0;

        Random random = new Random();
        Random colorRandom = new Random();

        private int highScore = 0;
        public int Health { get; set; } = 3;

        private bool paused = false; // Flag to track if the game is paused

        public Form1()
        {
            InitializeComponent();
        }

        private void MainTimerEvent(object sender, EventArgs e)
        {
            if (!paused) // Check if the game is not paused
            {
                txtScore.Text = "Score: " + score + " Health: " + Health;

                if (goUp && helicopter.Top > 0)
                {
                    helicopter.Top -= playerSpeed;
                }
                if (goDown && helicopter.Top + helicopter.Height < ClientSize.Height)
                {
                    helicopter.Top += playerSpeed;
                }

                ufo.Left -= UFOSpeed;

                if (ufo.Left + ufo.Width < 0)
                {
                    ChangeUFO();
                }

                foreach (Control x in Controls)
                {
                    if (x is PictureBox && (string)x.Tag == "pillar")
                    {
                        x.Left -= speed;

                        if (x.Left <= -200)
                        {
                            x.Left = 1000;
                        }

                        if (helicopter.Bounds.IntersectsWith(x.Bounds))
                        {
                            DecreaseHealth();
                        }
                    }

                    if (x is PictureBox && (string)x.Tag == "bullet")
                    {
                        x.Left += 25;
                        if (x.Left > 800)
                        {
                            RemoveBullet((PictureBox)x);
                        }

                        if (ufo.Bounds.IntersectsWith(x.Bounds))
                        {
                            RemoveBullet((PictureBox)x);
                            score += 1;
                            ChangeUFO();
                        }
                    }
                }

                if (helicopter.Bounds.IntersectsWith(ufo.Bounds))
                {
                    DecreaseHealth();
                }

                if (score > 10)
                {
                    speed = 12;
                    UFOSpeed = 18;
                }
            }
        }

        private void RestartGame()
        {
            goUp = false;
            goDown = false;
            shot = false;
            gameOver = false;
            score = 0;
            speed = 8;
            UFOSpeed = 10;
            Health = 3;
            txtScore.Text = "Score: " + score + " Health: " + Health;

            ChangeUFO();

            helicopter.Top = 62;
            pillar1.Left = 600;
            pillar2.Left = 253;

            GameTimer.Start();
        }

        private void GameOver()
        {
            GameTimer.Stop();
            txtScore.Text = "Score: " + score + "  Game over, press enter to retry!";
            gameOver = true;

            if (score > highScore)
            {
                highScore = score;
                MessageBox.Show("New High Score: " + highScore);
            }
        }

        private void DecreaseHealth()
        {
            Health--;

            if (Health <= 0)
            {
                GameOver();
            }
            else
            {
                helicopter.Top = 62;
                pillar1.Left = 600;
                pillar2.Left = 253;
                ChangeUFO();
            }
        }

        private void RemoveBullet(PictureBox bullet)
        {
            Controls.Remove(bullet);
            bullet.Dispose();
        }

        private void MakeBullet()
        {
            PictureBox bullet = new PictureBox
            {
                BackColor = Color.Maroon,
                Height = 5,
                Width = 10,
                Left = helicopter.Left + helicopter.Width,
                Top = helicopter.Top + helicopter.Height / 2,
                Tag = "bullet"
            };

            Controls.Add(bullet);

            // Change background color when shooting
            BackColor = Color.FromArgb(colorRandom.Next(256),
                colorRandom.Next(256), colorRandom.Next(256));
        }

        private void ChangeUFO()
        {
            if (index > 3)
            {
                index = 1;
            }
            else
            {
                index += 1;
            }

            switch (index)
            {
                case 1:
                    ufo.Image = Properties.Resources.alien1;
                    break;
                case 2:
                    ufo.Image = Properties.Resources.alien2;
                    break;
                case 3:
                    ufo.Image = Properties.Resources.alien3;
                    break;
            }

            ufo.Left = 1000;
            ufo.Top = random.Next(20, ClientSize.Height - ufo.Height);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                goUp = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                goDown = true;
            }
            if (e.KeyCode == Keys.Space && !shot)
            {
                MakeBullet();
                shot = true;
            }
            if (e.KeyCode == Keys.P) // Pause the game when 'P' is pressed
            {
                if (paused)
                {
                    ResumeGame();
                }
                else
                {
                    PauseGame();
                }
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                goUp = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                goDown = false;
            }
            if (e.KeyCode == Keys.Space)
            {
                shot = false;
            }
            if (e.KeyCode == Keys.Enter && gameOver)
            {
                RestartGame();
            }
        }

        private void PauseGame()
        {
            paused = true;
            GameTimer.Stop();
            txtScore.Text = "Game Paused. Press 'P' to resume.";
        }

        private void ResumeGame()
        {
            paused = false;
            GameTimer.Start();
            txtScore.Text = "Score: " + score + " Health: " + Health;
        }
    }
}
