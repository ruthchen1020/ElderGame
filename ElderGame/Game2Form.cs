
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

using System.Xml.Linq;

namespace ElderGame
{

    public partial class Game2Form : Form
    {

        public Game2Form(GameController _gameController)
        {
            this.gameController = _gameController;
            InitializeComponent();
        }

        private void Game2Form_Load(object sender, EventArgs e)
        {
            panel_car.Size = this.Size;
            labelScore.Location = new Point(0, 0);
            car_state = new CarState();
            car_state = CarState.GameStart;
            direction = new Directionc();
            timerMyCar.Start();
        }

        private void Game2Form_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 65:
                    direction = Directionc.Left;
                    break;
                case 68:
                    direction = Directionc.Right;
                    break;
                case 32:
                    switch (car_state)
                    {
                        case CarState.GameStart:
                            car_state = CarState.GameSet;
                            break;
                        case CarState.GameOver:
                            DialogResult = MessageBox.Show("Do You Want To Start Again?", "Play?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (DialogResult == DialogResult.Yes)
                            {
                                car_state = CarState.GameStart;
                            }
                            break;
                        case CarState.GamePlaying:
                            DialogResult = MessageBox.Show("Do You Want To End?", "Delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (DialogResult == DialogResult.Yes)
                            {
                                car_state = CarState.GameOver;
                            }
                            break;
                    }
                    break;
            }

        }

        private void Game2Form_KeyUp(object sender, KeyEventArgs e)
        {
            direction = Directionc.Middle;
        }

        private void timerMyCar_Tick(object sender, EventArgs e)
        {
            switch (car_state)
            {
                case CarState.GameStart:
                    pictureBox_MyCar.Visible = false;
                    panel_car.Controls.Clear();
                    panel_car.Controls.Add(labelGame);
                    labelGame.Text = "GAME START TAP SPACE START";
                    labelGame.Location = new Point(panel_car.Width / 2 - labelGame.Width / 2,
                                           panel_car.Height / 2 - labelGame.Height / 2);
                    labelGame.Visible = true;
                    break;
                case CarState.GameSet:
                    prv_score = gameController.GetScore(GameType.Game2);
                    score = 0; 
                    car_race = new CarRace(panel_car);
                    panel_car.Controls.Add(labelScore);
                    labelScore.Text = "SCORE : " + score.ToString();
                    pictureBox_MyCar.Visible = true;
                    panel_car.Controls.Add(pictureBox_MyCar);
                    labelGame.Visible = false;
                    car_race.CreatBoundary();
                    car_race.CreatDashLine();
                    car_race.ReadCarPic();
                    pictureBox_MyCar.Size = new Size(this.Size.Width / 15, 200);
                    pictureBox_MyCar.Location = new Point(this.Size.Width / 2, this.Height - pictureBox_MyCar.Size.Height - 20);
                    car_state = CarState.GamePlaying;
                    break;
                case CarState.GetPoint:
                    score += 1;
                    labelScore.Text = "SCORE : " + score.ToString();
                    gameController.SetScore(GameType.Game2, score + prv_score);
                    car_state = CarState.GamePlaying;
                    switch (direction)
                    {
                        case Directionc.Middle:
                            break;
                        case Directionc.Left:
                            pictureBox_MyCar.Location = new Point(pictureBox_MyCar.Location.X - 5, pictureBox_MyCar.Location.Y);
                            break;
                        case Directionc.Right:
                            pictureBox_MyCar.Location = new Point(pictureBox_MyCar.Location.X + 5, pictureBox_MyCar.Location.Y);
                            break;
                    }
                    car_state = car_race.MovingBack(pictureBox_MyCar);
                    break;
                case CarState.GamePlaying:
                    switch (direction)
                    {
                        case  Directionc.Middle:
                            break;
                        case  Directionc.Left:
                            pictureBox_MyCar.Location = new Point(pictureBox_MyCar.Location.X - 5, pictureBox_MyCar.Location.Y);
                            break;
                        case  Directionc.Right:
                            pictureBox_MyCar.Location = new Point(pictureBox_MyCar.Location.X + 5, pictureBox_MyCar.Location.Y);
                            break;
                    }
                    car_state = car_race.MovingBack(pictureBox_MyCar);
                    break;
                case CarState.GameOver:
                    panel_car.Controls.Clear();
                    car_race.CarTemp.Clear();
                    panel_car.Controls.Add(labelGame);
                    labelGame.Visible = true;
                    labelGame.Text = "GAME OVER TAP SPACE START";
                    gameController.SetScore(GameType.Game2, score + prv_score);
                    break;
            }
        }
    }
}
