
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace ElderGame
{

    public partial class Game3Form : Form
    {

        public Game3Form(GameController _gameController)
        {
            InitializeComponent();
            gameController = _gameController;
        }

        private void Game3Form_Load(object sender, EventArgs e)
        {
            WidthHeight = (Point)this.Size;
            panel_home.Size = this.Size;
            labelGame.Location = new Point(WidthHeight.X / 2 - labelGame.Width / 2,
                                           WidthHeight.Y / 2 - labelGame.Height / 2);
            labelScore.Location = new Point(0, 0);
            Curstate = SnakeState.GameStart;
            graphicsPathCircle = new System.Drawing.Drawing2D.GraphicsPath();
            graphicsPathCircle.AddEllipse(0, 0, 15, 15);
            region = new Region(graphicsPathCircle);
            timerMovement.Start();
            snake = new Snake(region, panel_home);
        }

        private void Game3Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 32)
            {
                switch (Curstate)
                {
                    case SnakeState.GameStart:
                        Curstate = SnakeState.GameSet;
                        break;
                    case SnakeState.GameOver:
                        DialogResult = MessageBox.Show("Do You Want To Start Again?", "Play?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (DialogResult == DialogResult.Yes)
                        {
                            Curstate = SnakeState.GameSet;
                        }
                        break;
                    case SnakeState.GamePlaying:
                        DialogResult = MessageBox.Show("Do You Want To End?", "Delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (DialogResult == DialogResult.Yes)
                        {
                            Curstate = SnakeState.GameOver;
                        }
                        break;
                }
            }
            snake.MovementDirection(Convert.ToInt32(e.KeyValue));
        }

        private void timerMovement_Tick(object sender, EventArgs e)
        {
            switch (Curstate)
            {
                case SnakeState.GameStart:
                    WidthHeight = (Point)this.Size;
                    panel_home.Controls.Clear();
                    panel_home.Controls.Add(labelGame);
                    labelGame.Text = "GAME START";
                    labelGame.Visible = true;
                    break;
                case SnakeState.GameSet:
                    WidthHeight = (Point)this.Size;
                    prv_score = gameController.GetScore(GameType.Game3);
                    score = 0;
                    panel_home.Controls.Add(labelScore);
                    labelScore.Text = "SCORE : " + score.ToString();
                    snake.SnakeBody_Create();
                    Curstate = SnakeState.GamePlaying;
                    timerFruit_Tick(sender, EventArgs.Empty);
                    labelGame.Visible = false;
                    Curstate = SnakeState.GamePlaying;
                    break;
                case SnakeState.GamePlaying:
                    Curstate = snake.MovementTick();
                    break;
                case SnakeState.GetPoint:
                    score++;
                    labelScore.Text = "SCORE : " + score.ToString();
                    Curstate = snake.MovementTick();
                    gameController.SetScore(GameType.Game3, score + prv_score);
                    break;
                case SnakeState.GameOver:
                    panel_home.Controls.Clear();
                    panel_home.Controls.Add(labelGame);
                    labelGame.Text = "GAME OVER";
                    labelGame.Visible = true;
                    gameController.SetScore(GameType.Game3, score + prv_score);
                    break;
            }
        }

        private void timerFruit_Tick(object sender, EventArgs e)
        {
            snake.FruitTick();
        }
    }
}
