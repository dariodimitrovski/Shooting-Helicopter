using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void MainTimerEvent(object sender, EventArgs e)
        {
            txtScore.Text = "Score: " + score;

            if (goUp == true && helicopter.Top > 0)
            {
                helicopter.Top -= playerSpeed;
            }
            if (goDown == true && helicopter.Top + helicopter.Height < this.ClientSize.Height)
            {
                helicopter.Top += playerSpeed;
            }

            ufo.Left -= UFOSpeed;

            if (ufo.Left + ufo.Width < 0)
            {
                ChangeUFO();
            }

            foreach (Control x in this.Controls)
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
                        GameOver();
                    }
                }

                if (x is PictureBox && (string)x.Tag == "bullet")
                {
                    x.Left += 25;
                    if (x.Left > 800)
                    {
                        RemoveBullet(((PictureBox)x));
                    }

                    if (ufo.Bounds.IntersectsWith(x.Bounds))
                    {
                        RemoveBullet(((PictureBox)x));
                        score += 1;
                        ChangeUFO();
                    }
                }
            }

            if (helicopter.Bounds.IntersectsWith(ufo.Bounds))
            {
                GameOver();
            }

            if (score > 10)
            {
                speed = 12;
                UFOSpeed = 18;
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
            txtScore.Text = "Score: " + score;

            ChangeUFO();

            helicopter.Top = 62;
            pillar1.Left = 600;
            pillar2.Left = 253;

            /*helicopter.Top = 62;
            pillar1.Left = 608;
            pillar2.Left = 315;*/

            GameTimer.Start();
        }

        private void GameOver()
        {
            GameTimer.Stop();
            txtScore.Text = "Score: " + score + "  Game over, press enter to retry!";
            gameOver = true;
        }

        private void RemoveBullet(PictureBox bullet)
        {
            this.Controls.Remove(bullet);
            bullet.Dispose();
        }

        private void MakeBullet()
        {
            PictureBox bullet = new PictureBox();
            bullet.BackColor = Color.Maroon;

            bullet.Height = 5;
            bullet.Width = 10;
            bullet.Left = helicopter.Left + helicopter.Width;
            bullet.Top = helicopter.Top + helicopter.Height / 2;
            bullet.Tag = "bullet";

            this.Controls.Add(bullet);
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

            if (index == 1)
            {
                ufo.Image = Properties.Resources.alien1;
            }
            else if (index == 2)
            {
                ufo.Image = Properties.Resources.alien2;
            }
            else if (index == 3)
            {
                ufo.Image = Properties.Resources.alien3;
            }

            ufo.Left = 1000;
            ufo.Top = random.Next(20, this.ClientSize.Height - ufo.Height);

            /*switch(index)
            {
                case 1: ufo.Image = Properties.Resources.alien1; break;
                case 2: ufo.Image = Properties.Resources.alien2; break;
                case 3: ufo.Image = Properties.Resources.alien3; break;
            }*/

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
            if (e.KeyCode == Keys.Space && shot == false)
            {
                MakeBullet();
                shot = true;
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
            if (shot == true)
            {
                shot = false;
            }
            if (e.KeyCode == Keys.Enter && gameOver == true)
            {
                RestartGame();
            }
        }

        private void helicopter_Click(object sender, EventArgs e)
        {

        }

        private void pillar1_Click(object sender, EventArgs e)
        {

        }
    }
}
