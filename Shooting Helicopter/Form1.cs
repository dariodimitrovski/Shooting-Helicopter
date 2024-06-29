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

        }

        private void KeyDown(object sender, KeyEventArgs e)
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

        private void KeyUp(object sender, KeyEventArgs e)
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
            pillar1.Left = 518;
            pillar2.Left = 253;

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

        }
    }
}
