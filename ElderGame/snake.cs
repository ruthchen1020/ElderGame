using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Security.Cryptography.X509Certificates;
using System.Data;
using static System.Formats.Asn1.AsnWriter;
using ElderGame;

namespace ElderGame
{
    public enum Direction
    {
        Right,
        Left,
        Up,
        Down
    }
    public enum SnakeState
    {
        GameStart,
        GameSet,
        GameOver,
        GamePlaying,
        GetPoint,
    }
    public class Fruit
    {
        public PictureBox pictureFruit = new PictureBox();
        Random random = new Random();
        public void CreatFruit(Region region, Panel panel)
        {
            pictureFruit.Width = 15;
            pictureFruit.Height = 15;
            pictureFruit.BackColor = Color.Red;
            pictureFruit.Region = region;
            pictureFruit.Location = new Point(random.Next((int)panel.Width/20)*20, random.Next((int)panel.Height/20) * 20);
            //game start
            panel.Controls.Add(pictureFruit);
        }
    }
    interface CreatHead
    {
        void CreatHead();
    }
    public class SnakeBodyPart //super class
    {
        public Point CenterPoint = new Point();
        public PictureBox picture = new PictureBox();
        public Panel panel;
        public Point Motion(Point NewPoint)
        {
            Point LastPoint = picture.Location;
            picture.Location = NewPoint;
            return LastPoint;
        }
        public void Creat()
        {
            picture.Width = 15;
            picture.Height = 15;
            picture.BackColor = Color.White;
            picture.Location = CenterPoint;
            panel.Controls.Add(picture);
        }
    }
    public class SnakeHead : SnakeBodyPart ,CreatHead
    {
        private Region region;
        public SnakeHead(Point _CenerPoint, Region _region, Panel _panel)
        {
            this.CenterPoint = _CenerPoint;
            this.panel = _panel;
            this.region = _region;
        }
        public void CreatHead()
        {
            picture.Region = region;
        }
    }
    public class SnakeBody : SnakeBodyPart
    {
        public SnakeBody(Point _CenerPoint, Panel _panel)
        {
            this.CenterPoint = _CenerPoint;
            this.panel = _panel;
        }
    }
    public class Snake 
    {
        Region region;
        Panel panel_home;
        Fruit fruit = new Fruit();
        SnakeHead snakeHead;
        List<SnakeBody> SnakeBodyList = new List<SnakeBody>();
        Random random = new Random();
        Direction direction = new Direction();
        bool FirstFruit = true;
        public Snake(Region _region, Panel _panel_home)
        {
            this.region = _region;
            this.panel_home = _panel_home;
        }
        public void SnakeBody_Create()
        {
            SnakeBodyList.Clear();
            fruit.CreatFruit(region, panel_home);
            direction = Direction.Right;
            snakeHead = new SnakeHead((new Point(200, 100)), region, panel_home);
            snakeHead.Creat();
            snakeHead.CreatHead();
            for (int i =1; i < 5; i++)
            {
                SnakeBody CurSnakeBody = new SnakeBody((new Point(200 - i * 20, 100)), panel_home);
                SnakeBodyList.Add(CurSnakeBody);
                CurSnakeBody.Creat();
            }
        }       
        public void MovementDirection(int movement)
        {
            switch (movement)
            {
                case 65:
                    direction = Direction.Left;
                    break;
                case 87:
                    direction = Direction.Up;
                    break;
                case 68:
                    direction = Direction.Right;
                    break;
                case 83:
                    direction = Direction.Down;
                    break;
            }
        }
        public SnakeState MovementTick()
        {  
            Point NewPoint = new Point();
            switch (direction)
            {
                case Direction.Left:
                    NewPoint = new Point(snakeHead.picture.Location.X - 20, snakeHead.picture.Location.Y);
                    break;
                case Direction.Up:
                    NewPoint = new Point(snakeHead.picture.Location.X, snakeHead.picture.Location.Y - 20);                
                    break;
                case Direction.Right:
                    NewPoint = new Point(snakeHead.picture.Location.X + 20, snakeHead.picture.Location.Y);
                    break;
                case Direction.Down:
                    NewPoint = new Point(snakeHead.picture.Location.X, snakeHead.picture.Location.Y + 20);
                    break;
            }
            NewPoint = snakeHead.Motion(NewPoint);
            // 如果碰到邊界回傳結束
            if(NewPoint.X > panel_home.Size.Width || NewPoint.X < 0 ||
               NewPoint.Y > panel_home.Size.Height || NewPoint.Y<0)
            {
                return SnakeState.GameOver;
            }
            foreach (SnakeBody i in SnakeBodyList)
            {
                NewPoint = i.Motion(NewPoint); 
                if(snakeHead.picture.Location == NewPoint) // 判斷頭碰到身體
                {
                    return SnakeState.GameOver;
                }
            }
            // 如果吃到回傳加分
            if (snakeHead.picture.Location == fruit.pictureFruit.Location)
            {
                fruit.pictureFruit.Location = new Point(random.Next(40) * 20, random.Next(20) * 20);
                SnakeBody CurSnakeBody = new SnakeBody(NewPoint, panel_home);
                SnakeBodyList.Add(CurSnakeBody);
                CurSnakeBody.Creat();
                return SnakeState.GetPoint;
            }
            return SnakeState.GamePlaying;            
        }
        public void FruitTick()
        {
            fruit.pictureFruit.Location = new Point(random.Next(40) * 20, random.Next(20) * 20);  
        }
    }
}
