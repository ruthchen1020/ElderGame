using System;
using System.Security.AccessControl;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using static System.Formats.Asn1.AsnWriter;

namespace ElderGame
{
    public enum GameType
    {
        Game1,
        Game2,
        Game3
    }

    public class GameController : GameStatistics
    {
        private Form currentGameForm;
        private DateTime gameStartTime;
        private GameType gametype;
        private Label[] GameLabels;


        //private Panel gamePanel;
        public GameController(GameType gametype)
        {
            this.gametype = gametype;
        }

        public void LoadGame(Form gameForm,GameType _gametype, Label[] _GameLabels)
        {
            GameLabels = _GameLabels;
            gametype = _gametype;
            if (currentGameForm != null)
            {
                currentGameForm.FormClosed -= CurrentGameForm_FormClosed;
                currentGameForm.Close();
                
            }

            if (gameForm != null)
            {
                
                gameForm.FormClosed += CurrentGameForm_FormClosed;
                gameStartTime = DateTime.Now;
                IncrementClicks(gametype);
                LabelUpdate(GameLabels, gametype);
                gameForm.Show();
                currentGameForm = gameForm;
            }
            
        }

        private void CurrentGameForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            TimeSpan timeSpent = DateTime.Now - gameStartTime;
            
            AddTimeSpent(gametype,  timeSpent);
            LabelUpdate(GameLabels, gametype);
            currentGameForm = null;
           
        }

        

    }


    public class GameStatistics
    {
        private Dictionary<GameType, int> gameClicks;
        private Dictionary<GameType, TimeSpan> gameTimeSpent;
        private Dictionary<GameType, int> gameScore;

        public GameStatistics()
        {
            gameClicks = new Dictionary<GameType, int>
                {
                    { GameType.Game1, 0 },
                    { GameType.Game2, 0 },
                    { GameType.Game3, 0 }
                };
            gameTimeSpent = new Dictionary<GameType, TimeSpan>
                {
                    { GameType.Game1, TimeSpan.Zero },
                    { GameType.Game2, TimeSpan.Zero },
                    { GameType.Game3, TimeSpan.Zero }
                };
            gameScore = new Dictionary<GameType, int>
                {
                    { GameType.Game1, 0 },
                    { GameType.Game2, 0 },
                    { GameType.Game3, 0 }
                };

        }
        public void UpdateScore(Label label, int score)
        {
            label.Text = $"Score: {score}";
        }

        public void UpdateClicks(Label label, int times)
        {
            label.Text = $"Times: {times}";
        }

        public void UpdateTimeSpent(Label label, TimeSpan timeSpent)
        {
            label.Text = $"Time Spent: {(int)timeSpent.TotalSeconds} seconds";
        }

        public void LabelUpdate(Label[] label,GameType game)
        {
            UpdateScore(label[0], GetScore(game));
            UpdateClicks(label[1], GetClicks(game));
            UpdateTimeSpent(label[2], GetTimeSpent(game));
        }

        public void IncrementClicks(GameType game)
        {
            if (gameClicks.ContainsKey(game))
            {
                gameClicks[game]++;
            }
        }

        public int GetClicks(GameType game)
        {
            return gameClicks.ContainsKey(game) ? gameClicks[game] : 0;
        }

        public void AddTimeSpent(GameType game, TimeSpan timeSpent)
        {
            if (gameTimeSpent.ContainsKey(game))
            {
                gameTimeSpent[game] += timeSpent;
            }
        }

        public TimeSpan GetTimeSpent(GameType game)
        {
            return gameTimeSpent.ContainsKey(game) ? gameTimeSpent[game] : TimeSpan.Zero;
        }

        public void SetScore(GameType game, int score)
        {
            if (gameScore.ContainsKey(game))
            {
                gameScore[game] = score;
            }
        }

        public int GetScore(GameType game)
        {
            return gameScore.ContainsKey(game) ? gameScore[game] : 0;
        }
    }




    public class HealthData
    {
        public List<int> HeartRates { get; set; }
        public List<int> BloodPressures { get; set; }
        
        protected int _heartRate;
        protected int _bloodPressure;

        public HealthData()
        {
            HeartRates = new List<int>();
            BloodPressures = new List<int>();
        }
        public int heartRate
        {
            get => _heartRate; 
            set => _heartRate = value;
        }
        public int bloodPressure
        {
            get => _bloodPressure;
            set => _bloodPressure = value;
        }
        public void AddHeartRate()
        {
            _heartRate = new Random().Next(60, 100);
            HeartRates.Add(_heartRate);
        }

        public void AddBloodPressure()
        {
            _bloodPressure = new Random().Next(110, 140);
            BloodPressures.Add(_bloodPressure);
        }

        public void InitializeChart(Chart chart, string title)
        {
            chart.Titles.Add(title);
            chart.ChartAreas.Add(new ChartArea());

            var series = new Series
            {
                ChartType = SeriesChartType.Line
            };

            chart.Series.Add(series);
        }

        public void UpdateChart(Chart chart, List<int> data)
        {
            chart.Series[0].Points.Clear();
            for (int i = 0; i < data.Count; i++)
            {
                chart.Series[0].Points.AddXY(i, data[i]);
            }
        }
    }
    
}


