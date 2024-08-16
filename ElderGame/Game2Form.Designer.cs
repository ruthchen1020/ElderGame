
using static System.Windows.Forms.AxHost;

namespace ElderGame
{
    partial class Game2Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        CarRace car_race;
        string InitialDirectory;
        Directionc direction;        /// <summary>
        CarState car_state;
        int score;
        int prv_score;
        GameController gameController;
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            panel_car = new Panel();
            labelScore = new Label();
            labelGame = new Label();
            pictureBox_MyCar = new PictureBox();
            timerMyCar = new System.Windows.Forms.Timer(components);
            timer1 = new System.Windows.Forms.Timer(components);
            timerState = new System.Windows.Forms.Timer(components);
            panel_car.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_MyCar).BeginInit();
            SuspendLayout();
            // 
            // panel_car
            // 
            panel_car.BackColor = Color.Black;
            panel_car.Controls.Add(labelScore);
            panel_car.Controls.Add(labelGame);
            panel_car.Controls.Add(pictureBox_MyCar);
            panel_car.Location = new Point(0, 1);
            panel_car.Name = "panel_car";
            panel_car.Size = new Size(800, 550);
            panel_car.TabIndex = 0;
            // 
            // labelScore
            // 
            labelScore.AutoSize = true;
            labelScore.BackColor = Color.DimGray;
            labelScore.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 136);
            labelScore.ForeColor = SystemColors.ButtonHighlight;
            labelScore.Location = new Point(388, 263);
            labelScore.Name = "labelScore";
            labelScore.Size = new Size(24, 25);
            labelScore.TabIndex = 12;
            labelScore.Text = "0";
            // 
            // labelGame
            // 
            labelGame.AutoSize = true;
            labelGame.Font = new Font("Microsoft JhengHei UI", 60F);
            labelGame.ForeColor = SystemColors.ControlLightLight;
            labelGame.Location = new Point(111, 212);
            labelGame.Name = "labelGame";
            labelGame.Size = new Size(578, 127);
            labelGame.TabIndex = 2;
            labelGame.Text = "Game Start";
            // 
            // pictureBox_MyCar
            // 
            pictureBox_MyCar.Image = Properties.Resources.silver;
            pictureBox_MyCar.Location = new Point(412, 216);
            pictureBox_MyCar.Name = "pictureBox_MyCar";
            pictureBox_MyCar.Size = new Size(74, 156);
            pictureBox_MyCar.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox_MyCar.TabIndex = 0;
            pictureBox_MyCar.TabStop = false;
            // 
            // timerMyCar
            // 
            timerMyCar.Interval = 10;
            timerMyCar.Tick += timerMyCar_Tick;
            // 
            // timer1
            // 
            timer1.Interval = 10;
            // 
            // timerState
            // 
            timerState.Interval = 1;
            // 
            // Game2Form
            // 
            AccessibleRole = AccessibleRole.None;
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel_car);
            Name = "Game2Form";
            Text = "Game2Form";
            WindowState = FormWindowState.Maximized;
            Load += Game2Form_Load;
            KeyDown += Game2Form_KeyDown;
            KeyUp += Game2Form_KeyUp;
            panel_car.ResumeLayout(false);
            panel_car.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_MyCar).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel_car;
        private PictureBox pictureBox_MyCar;
        private System.Windows.Forms.Timer timerMyCar;
        private Label labelGame;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timerState;
        private Label labelScore;
    }
}