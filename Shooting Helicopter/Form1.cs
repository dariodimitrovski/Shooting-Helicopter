using System;
using System.Drawing;
using System.Windows.Forms;

namespace Shooting_Helicopter
{
    public partial class Form1 : Form
    {
        private int playerSpeed;
        private int speed;
        private int UFOSpeed;
        private int score;
        private int highScore;
        private int index;
        private int Health;

        private bool goUp;
        private bool goDown;
        private bool shot;
        private bool gameOver;
        private bool paused;

        Random random = new Random();
        Random colorRandom = new Random();

        private DifficultyForm difficultyForm;

        public Form1()
        {
            InitializeComponent();
            StartGameWithDifficultySelection();
        }

        private void StartGameWithDifficultySelection()
        {
            difficultyForm = new DifficultyForm();

            DialogResult result = difficultyForm.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrEmpty(difficultyForm.SelectedDifficulty))
            {
                InitializeGame(difficultyForm.SelectedDifficulty);
            }
            else
            {
                InitializeGame("Easy");
            }
        }

        private void InitializeGame(string difficulty)
        {
            switch (difficulty)
            {
                case "Easy":
                    playerSpeed = 5;
                    speed = 5;
                    UFOSpeed = 10;
                    break;
                case "Medium":
                    playerSpeed = 10;
                    speed = 10;
                    UFOSpeed = 20;
                    break;
                case "Hard":
                    playerSpeed = 15;
                    speed = 15;
                    UFOSpeed = 30;
                    break;
                default:
                    playerSpeed = 5;
                    speed = 5;
                    UFOSpeed = 10;
                    break;
            }

            score = 0;
            highScore = 0;
            index = 0;
            Health = 3;

            txtScore.Text = "Score: " + score + " Health: " + Health;

            GameTimer.Start();
        }

        private void MainTimerEvent(object sender, EventArgs e)
        {
            txtScore.Text = "Score: " + score + " Health: " + Health;

            if (!paused)
            {
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
                            if (index == 1) 
                            {
                                index = 0; 
                            }
                            else
                            {
                                score += 1;
                                ChangeUFO();
                            }
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

            StartGameWithDifficultySelection();
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

            BackColor = Color.FromArgb(colorRandom.Next(256),
                colorRandom.Next(256), colorRandom.Next(256));
        }

        private void Alien3Shoot()
        {
            PictureBox bullet = new PictureBox
            {
                BackColor = Color.Red,
                Size = new Size(10, 10),
                Left = ufo.Left,
                Top = ufo.Top + ufo.Height / 2,
                Tag = "alien3bullet"
            };

            Controls.Add(bullet);

            Timer bulletTimer = new Timer();
            bulletTimer.Interval = 20;
            bulletTimer.Tick += (sender, e) =>
            {
                bullet.Left -= 10;

                if (bullet.Bounds.IntersectsWith(helicopter.Bounds))
                {
                    bulletTimer.Stop();
                    Controls.Remove(bullet);
                    DecreaseHealth();
                }

                if (bullet.Left < 0)
                {
                    bulletTimer.Stop();
                    Controls.Remove(bullet);
                }
            };

            bulletTimer.Start();
        }

        private void ChangeUFO()
        {
            index++;
            if (index > 3)
            {
                index = 1;
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
                    Alien3Shoot();
                    break;
            }

            ufo.Left = 1000;
            ufo.Top = random.Next(20, ClientSize.Height - ufo.Height);

            int ufoSpeedIndex;
            switch (difficultyForm.SelectedDifficulty)
            {
                case "Easy":
                    ufoSpeedIndex = 10;
                    break;
                case "Medium":
                    ufoSpeedIndex = 25;
                    break;
                case "Hard":
                    ufoSpeedIndex = 40;
                    break;
                default:
                    ufoSpeedIndex = 10;
                    break;
            }

            UFOSpeed = ufoSpeedIndex;
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
            if (e.KeyCode == Keys.P)
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
