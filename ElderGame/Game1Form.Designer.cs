using System.Numerics;

namespace ElderGame
{
    partial class Game1Form
    {
        /// <summary>
        /// Required designer variable.
        bool goLeft;
        bool goRight;
        bool isGameOver;

        int prv_score = 0;
        int score = 0;
        int Gametime = 0;
        int ballx = 5;
        int bally = 5;
        int playerSpeed = 15;

        Random rnd = new Random();

        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            label_score = new Label();
            player = new PictureBox();
            ball = new PictureBox();
            button_Start = new Button();
            label_End = new Label();
            gametimer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)player).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ball).BeginInit();
            SuspendLayout();
            // 
            // label_score
            // 
            label_score.AutoSize = true;
            label_score.ForeColor = SystemColors.Control;
            label_score.Location = new Point(14, 13);
            label_score.Margin = new Padding(5, 0, 5, 0);
            label_score.Name = "label_score";
            label_score.Size = new Size(68, 19);
            label_score.TabIndex = 1;
            label_score.Text = "Score : 0";
            // 
            // player
            // 
            player.BackColor = Color.White;
            player.Location = new Point(907, 500);
            player.Margin = new Padding(0);
            player.Name = "player";
            player.Size = new Size(100, 32);
            player.TabIndex = 2;
            player.TabStop = false;
            // 
            // ball
            // 
            ball.BackColor = Color.FromArgb(255, 255, 128);
            ball.Location = new Point(916, 389);
            ball.Margin = new Padding(0);
            ball.Name = "ball";
            ball.Size = new Size(30, 30);
            ball.TabIndex = 3;
            ball.TabStop = false;
            // 
            // button_Start
            // 
            button_Start.Location = new Point(350, 209);
            button_Start.Name = "button_Start";
            button_Start.Size = new Size(223, 112);
            button_Start.TabIndex = 0;
            button_Start.Text = "Start Game!";
            button_Start.UseVisualStyleBackColor = true;
            button_Start.Click += button_Start_Click;
            // 
            // label_End
            // 
            label_End.AutoSize = true;
            label_End.ForeColor = Color.White;
            label_End.Location = new Point(330, 225);
            label_End.Name = "label_End";
            label_End.Size = new Size(238, 19);
            label_End.TabIndex = 0;
            label_End.Text = "Game Over!  Press X  Back Home";
            label_End.Visible = false;
            // 
            // gametimer
            // 
            gametimer.Interval = 20;
            gametimer.Tick += gametimer_Tick;
            // 
            // Game1Form
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1036, 604);
            Controls.Add(ball);
            Controls.Add(player);
            Controls.Add(label_score);
            Controls.Add(button_Start);
            Controls.Add(label_End);
            Name = "Game1Form";
            Text = "Game1Form";
            
            Load += Game1Form_Load;
            KeyDown += keydown_event;
            KeyUp += keyup_event;
            ((System.ComponentModel.ISupportInitialize)player).EndInit();
            ((System.ComponentModel.ISupportInitialize)ball).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_score;
        private PictureBox player;
        private PictureBox ball;
        private System.Windows.Forms.Timer gametimer;
        private Button homeButton;
        private Label label_End;
        private Button button_Start;
    }
}