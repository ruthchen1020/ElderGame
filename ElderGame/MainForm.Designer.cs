using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Data.SqlClient;

namespace ElderGame
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        /// <summary>
        ///  Clean up any resources being used.
        //heartRateChart = new Chart { Dock = DockStyle.Top, Width = 400 };
        //bloodPressureChart = new Chart { Dock = DockStyle.Top, Width = 400 };
        //dashboardPanel.Controls.Add(heartRateChart);
        //dashboardPanel.Controls.Add(bloodPressureChart);

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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Game2Button = new Button();
            gamePanel = new Panel();
            Game3Score = new Label();
            Game2Score = new Label();
            Game1Score = new Label();
            Game3Clicks = new Label();
            Game2Clicks = new Label();
            Game3TimeSpent = new Label();
            Game1Clicks = new Label();
            Game2TimeSpent = new Label();
            Game3Button = new Button();
            Game1TimeSpent = new Label();
            Game1Button = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            menuStrip1 = new MenuStrip();
            gameToolStripMenuItem = new ToolStripMenuItem();
            dashboardToolStripMenuItem = new ToolStripMenuItem();
            mainPanel = new Panel();
            dashboardPanel = new Panel();
            pageSetupDialog1 = new PageSetupDialog();
            gamePanel.SuspendLayout();
            menuStrip1.SuspendLayout();
            mainPanel.SuspendLayout();
            SuspendLayout();
            // 
            // Game2Button
            // 
            Game2Button.Location = new Point(0, 106);
            Game2Button.Name = "Game2Button";
            Game2Button.Size = new Size(200, 100);
            Game2Button.TabIndex = 1;
            Game2Button.Text = "Game2";
            Game2Button.UseVisualStyleBackColor = true;
            Game2Button.Click += Game2Button_Click;
            // 
            // gamePanel
            // 
            gamePanel.BackColor = Color.FromArgb(255, 255, 192);
            gamePanel.BackgroundImage = Properties.Resources._52429631448_dbc91b4f99_h;
            gamePanel.Controls.Add(Game3Score);
            gamePanel.Controls.Add(Game2Score);
            gamePanel.Controls.Add(Game1Score);
            gamePanel.Controls.Add(Game3Clicks);
            gamePanel.Controls.Add(Game2Clicks);
            gamePanel.Controls.Add(Game3TimeSpent);
            gamePanel.Controls.Add(Game1Clicks);
            gamePanel.Controls.Add(Game2TimeSpent);
            gamePanel.Controls.Add(Game3Button);
            gamePanel.Controls.Add(Game2Button);
            gamePanel.Controls.Add(Game1TimeSpent);
            gamePanel.Controls.Add(Game1Button);
            gamePanel.Dock = DockStyle.Fill;
            gamePanel.Location = new Point(0, 0);
            gamePanel.Name = "gamePanel";
            gamePanel.Size = new Size(800, 573);
            gamePanel.TabIndex = 0;
            // 
            // Game3Score
            // 
            Game3Score.AutoSize = true;
            Game3Score.Location = new Point(585, 248);
            Game3Score.Name = "Game3Score";
            Game3Score.Size = new Size(51, 19);
            Game3Score.TabIndex = 9;
            Game3Score.Text = "label5";
            // 
            // Game2Score
            // 
            Game2Score.AutoSize = true;
            Game2Score.Location = new Point(579, 146);
            Game2Score.Name = "Game2Score";
            Game2Score.Size = new Size(51, 19);
            Game2Score.TabIndex = 8;
            Game2Score.Text = "label4";
            // 
            // Game1Score
            // 
            Game1Score.AutoSize = true;
            Game1Score.Location = new Point(585, 45);
            Game1Score.Name = "Game1Score";
            Game1Score.Size = new Size(51, 19);
            Game1Score.TabIndex = 7;
            Game1Score.Text = "label3";
            // 
            // Game3Clicks
            // 
            Game3Clicks.AutoSize = true;
            Game3Clicks.Location = new Point(377, 249);
            Game3Clicks.Name = "Game3Clicks";
            Game3Clicks.Size = new Size(51, 19);
            Game3Clicks.TabIndex = 6;
            Game3Clicks.Text = "label2";
            // 
            // Game2Clicks
            // 
            Game2Clicks.AutoSize = true;
            Game2Clicks.Location = new Point(378, 145);
            Game2Clicks.Name = "Game2Clicks";
            Game2Clicks.Size = new Size(51, 19);
            Game2Clicks.TabIndex = 5;
            Game2Clicks.Text = "label1";
            // 
            // Game3TimeSpent
            // 
            Game3TimeSpent.AutoSize = true;
            Game3TimeSpent.Location = new Point(249, 253);
            Game3TimeSpent.Name = "Game3TimeSpent";
            Game3TimeSpent.Size = new Size(51, 19);
            Game3TimeSpent.TabIndex = 4;
            Game3TimeSpent.Text = "label2";
            // 
            // Game1Clicks
            // 
            Game1Clicks.AutoSize = true;
            Game1Clicks.Location = new Point(366, 41);
            Game1Clicks.Name = "Game1Clicks";
            Game1Clicks.Size = new Size(51, 19);
            Game1Clicks.TabIndex = 3;
            Game1Clicks.Text = "label1";
            // 
            // Game2TimeSpent
            // 
            Game2TimeSpent.AutoSize = true;
            Game2TimeSpent.Location = new Point(249, 147);
            Game2TimeSpent.Name = "Game2TimeSpent";
            Game2TimeSpent.Size = new Size(36, 19);
            Game2TimeSpent.TabIndex = 2;
            Game2TimeSpent.Tag = "TimeSpent";
            Game2TimeSpent.Text = "123";
            // 
            // Game3Button
            // 
            Game3Button.Location = new Point(0, 212);
            Game3Button.Name = "Game3Button";
            Game3Button.Size = new Size(200, 100);
            Game3Button.TabIndex = 1;
            Game3Button.Text = "Game3";
            Game3Button.UseVisualStyleBackColor = true;
            Game3Button.Click += Game3Button_Click;
            // 
            // Game1TimeSpent
            // 
            Game1TimeSpent.AutoSize = true;
            Game1TimeSpent.Location = new Point(249, 41);
            Game1TimeSpent.Name = "Game1TimeSpent";
            Game1TimeSpent.Size = new Size(51, 19);
            Game1TimeSpent.TabIndex = 1;
            Game1TimeSpent.Tag = "TimeSpent";
            Game1TimeSpent.Text = "label1";
            // 
            // Game1Button
            // 
            Game1Button.Location = new Point(0, 0);
            Game1Button.Name = "Game1Button";
            Game1Button.Size = new Size(200, 100);
            Game1Button.TabIndex = 0;
            Game1Button.Text = "Game1";
            Game1Button.UseVisualStyleBackColor = true;
            Game1Button.Click += Game1Button_Click;
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { gameToolStripMenuItem, dashboardToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 27);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            gameToolStripMenuItem.Size = new Size(63, 23);
            gameToolStripMenuItem.Text = "game";
            gameToolStripMenuItem.Click += gameToolStripMenuItem_Click;
            // 
            // dashboardToolStripMenuItem
            // 
            dashboardToolStripMenuItem.Name = "dashboardToolStripMenuItem";
            dashboardToolStripMenuItem.Size = new Size(99, 23);
            dashboardToolStripMenuItem.Text = "dashboard";
            dashboardToolStripMenuItem.Click += dashboardToolStripMenuItem_Click;
            // 
            // mainPanel
            // 
            mainPanel.Controls.Add(gamePanel);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 27);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(800, 573);
            mainPanel.TabIndex = 2;
            // 
            // dashboardPanel
            // 

            heartRateChart = new Chart { Dock = DockStyle.Top, Width = 400 };
            bloodPressureChart = new Chart { Dock = DockStyle.Top, Width = 400 };
            dashboardPanel.BackColor = SystemColors.ActiveCaption;
            dashboardPanel.Dock = DockStyle.Fill;
            dashboardPanel.Location = new Point(0, 27);
            dashboardPanel.Name = "dashboardPanel";
            dashboardPanel.Size = new Size(800, 573);
            dashboardPanel.TabIndex = 3;
            dashboardPanel.Controls.Add(heartRateChart);
            dashboardPanel.Controls.Add(bloodPressureChart);

            // 
            // MainForm
            // 
            ClientSize = new Size(800, 600);
            Controls.Add(mainPanel);
            Controls.Add(dashboardPanel);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "MainForm";
            Load += MainForm_Load;
            gamePanel.ResumeLayout(false);
            gamePanel.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            mainPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel gamePanel;
        private Button Game2Button;
        private Button Game1Button;
        private Chart heartRateChart;
        private Chart bloodPressureChart;

        private System.Windows.Forms.Timer timer1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem gameToolStripMenuItem;
        private ToolStripMenuItem dashboardToolStripMenuItem;
        private Panel mainPanel;
        private Panel dashboardPanel;
        private PageSetupDialog pageSetupDialog1;
        private Label Game1TimeSpent;
        private Button Game3Button;
        private Label Game2TimeSpent;
        private Label Game1Clicks;
        private Label Game3TimeSpent;
        private Label Game3Score;
        private Label Game2Score;
        private Label Game1Score;
        private Label Game3Clicks;
        private Label Game2Clicks;
    }
    
}
