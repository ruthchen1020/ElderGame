using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Formats.Asn1.AsnWriter;

namespace ElderGame
{

    public partial class Game1Form : Form
    {

        PictureBox[] blockArray = new PictureBox[15];
        GameController gameController;

        public Game1Form(GameController _gameController)
        {
            InitializeComponent();
            this.gameController = _gameController;
        }

        private void Game1Form_Load(object sender, EventArgs e)
        {


        }

        private void button_Start_Click(object sender, EventArgs e)
        {
            SetupGame();
            button_Start.Visible = false;
            button_Start.Enabled = false;
        }
        public void SetupGame()
        {
            isGameOver = false;
            score = 0 ;
            prv_score = gameController.GetScore(GameType.Game1);
            Gametime = 0;
            ballx = 5;
            bally = 5;
            playerSpeed = 12;
            label_score.Text = "Score: " + score;

            ball.Location = new Point(rnd.Next(1, 951), rnd.Next(326, 400));
            player.Top = this.ClientSize.Height - 50;


            int a = 0;
            int top = 50;
            int left = 100;

            for (int i = 0; i < blockArray.Length; i++)
            {
                blockArray[i] = new PictureBox();
                blockArray[i].Height = 32;
                blockArray[i].Width = 100;
                blockArray[i].Tag = "Blocks";
                blockArray[i].BackColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));

                if (a == 5)
                {
                    top = top + 50;
                    left = 100;
                    a = 0;
                }

                if (a < 5)
                {
                    a++;
                    blockArray[i].Left = left;
                    blockArray[i].Top = top;
                    Controls.Add(blockArray[i]);
                    left = left + 200;

                }
            }

            gametimer.Start();
        }

        private void gametimer_Tick(object sender, EventArgs e)
        {
            

            label_score.Text = "Score : " + score ;


            if (goLeft == true && player.Left > 0)
            {
                player.Left -= playerSpeed;
            }

            if (goRight == true && player.Left < this.ClientSize.Width - player.Width)//882
            {
                player.Left += playerSpeed;
            }

            ball.Left += ballx;
            ball.Top += bally;

            if (ball.Left < 0 || ball.Left > this.ClientSize.Width - ball.Width)//952
            {
                ballx = -ballx;
            }
            if (ball.Top < 0)
            {
                bally = -bally;
            }

            if (ball.Bounds.IntersectsWith(player.Bounds))
            {

                ball.Top = this.ClientSize.Height - 50 - player.Height;//471

                bally = rnd.Next(5, 12) * -1;

                if (ballx < 0)
                {
                    ballx = rnd.Next(5, 12) * -1;
                }
                else
                {
                    ballx = rnd.Next(5, 12);
                }
            }

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "Blocks")
                {
                    if (ball.Bounds.IntersectsWith(x.Bounds))
                    {
                        score += 1;
                        gameController.SetScore(GameType.Game1, score + prv_score);
                        bally = -bally;

                        this.Controls.Remove(x);
                    }
                }

            }


            if (score == 15)
            {
                //win
                isGameOver = true;
                gametimer.Stop();
                label_End.Visible = true;

                //endPanel.Visible = true;
                //endPanel.Enabled = true;
            }

            if (ball.Top > this.ClientSize.Height)
            {
                //lose
                isGameOver = true;
                gametimer.Stop();
                label_End.Visible = true;
                //endPanel.Visible = true;
                //endPanel.Enabled = true;
            }

            if (isGameOver == true)
            {
                foreach (PictureBox x in blockArray)
                {
                    this.Controls.Remove(x);
                }

            }
        }

        private void keydown_event(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.A)
            {
                goLeft = true;

            }
            if (e.KeyCode == Keys.D)
            {
                goRight = true;
            }
        }


        private void keyup_event(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.D)
            {
                goRight = false;
            }

        }

        private void Game1Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}
