using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using System.Data.SqlClient;
using static System.Formats.Asn1.AsnWriter;
using System.Security.AccessControl;

namespace ElderGame
{
    public partial class MainForm : Form
    {
        private GameController gameController;
        private GameType curGameType = new GameType();
        HealthData healthData = new HealthData();
        Label[] Game1Labels = new Label[3];
        Label[] Game2Labels = new Label[3];
        Label[] Game3Labels = new Label[3];
        public int score = new int();

        public MainForm()
        {
            InitializeComponent();
            Game1Labels = [Game1TimeSpent, Game1Clicks, Game1Score];
            Game2Labels = [Game2TimeSpent, Game2Clicks, Game2Score];
            Game3Labels = [Game3TimeSpent, Game3Clicks, Game3Score];
            //gameController.LabelInitialize(game2Panel);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            gameController = new GameController(curGameType);
            gameController.LabelUpdate(Game1Labels, GameType.Game1);
            gameController.LabelUpdate(Game2Labels, GameType.Game2);
            gameController.LabelUpdate(Game3Labels, GameType.Game3);


            healthData.InitializeChart(heartRateChart, "Heart Rate");
            healthData.InitializeChart(bloodPressureChart, "Blood Pressure");
            timer1.Start();

        }

        private void Game1Button_Click(object sender, EventArgs e)
        {
            curGameType = GameType.Game1;
            try
            {
                Form game1 = new Game1Form(gameController);
                gameController.LoadGame(game1, curGameType, Game1Labels);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Game2Button_Click(object sender, EventArgs e)
        {
            curGameType = GameType.Game2;
            try
            {
                Form game2 = new Game2Form(gameController);
                gameController.LoadGame(game2, curGameType, Game2Labels);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            //gameController.LabelUpdate(Game2Labels, GameType.Game2);
        }
        private void Game3Button_Click(object sender, EventArgs e)
        {
            curGameType = GameType.Game3;
            try
            {
                Form game3 = new Game3Form(gameController);
                gameController.LoadGame(game3, curGameType, Game3Labels);
            }
            catch( Exception ex) 
            {
                MessageBox.Show(ex.ToString());
            }
            //gameController.LabelUpdate(Game3Labels, GameType.Game3);
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            //score=
            healthData.AddHeartRate();
            healthData.AddBloodPressure();
            healthData.UpdateChart(heartRateChart, healthData.HeartRates);
            healthData.UpdateChart(bloodPressureChart, healthData.BloodPressures);
            //gameController.SetScore(curGameType, score);
        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainPanel.Visible = false;
            dashboardPanel.Visible = true;

        }

        private void gameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainPanel.Visible = true;
            dashboardPanel.Visible = false;
        }

        
    }
}
