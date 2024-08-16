
using static System.Windows.Forms.AxHost;

namespace ElderGame
{
    partial class Game3Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        System.Drawing.Drawing2D.GraphicsPath graphicsPathCircle;
        Region region;
        Snake snake;
        SnakeState Curstate;
        int score;
        int prv_score;
        Point WidthHeight;
        GameController gameController;
        /// <summary>
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
            panel_home = new Panel();
            labelScore = new Label();
            labelGame = new Label();
            timerMovement = new System.Windows.Forms.Timer(components);
            timerFruit = new System.Windows.Forms.Timer(components);
            panel_home.SuspendLayout();
            SuspendLayout();
            // 
            // panel_home
            // 
            panel_home.BackColor = SystemColors.ActiveCaptionText;
            panel_home.Controls.Add(labelScore);
            panel_home.Controls.Add(labelGame);
            panel_home.Location = new Point(0, 1);
            panel_home.Name = "panel_home";
            panel_home.Size = new Size(800, 550);
            panel_home.TabIndex = 0;
//            panel_home.Paint += panel_home_Paint;
            // 
            // labelScore
            // 
            labelScore.AutoSize = true;
            labelScore.BackColor = Color.DimGray;
            labelScore.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 136);
            labelScore.ForeColor = SystemColors.ButtonHighlight;
            labelScore.Location = new Point(352, 107);
            labelScore.Name = "labelScore";
            labelScore.Size = new Size(24, 25);
            labelScore.TabIndex = 11;
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
            labelGame.TabIndex = 1;
            labelGame.Text = "Game Start";
            // 
            // timerMovement
            // 
            timerMovement.Interval = 200;
            timerMovement.Tick += timerMovement_Tick;
            // 
            // timerFruit
            // 
            timerFruit.Interval = 20000;
            timerFruit.Tick += timerFruit_Tick;
            // 
            // Game3Form
            // 
            AccessibleRole = AccessibleRole.None;
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel_home);
            Name = "Game3Form";
            Text = "Game3Form";
            WindowState = FormWindowState.Maximized;
//            FormClosing += Game3Form_FormClosing;
            Load += Game3Form_Load;
            KeyDown += Game3Form_KeyDown;
            panel_home.ResumeLayout(false);
            panel_home.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel_home;
        private System.Windows.Forms.Timer timerMovement;
        private System.Windows.Forms.Timer timerFruit;
        private Label labelGame;
        private Label labelScore;
    }
}