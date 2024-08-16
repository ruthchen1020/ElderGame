using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Security.Cryptography.X509Certificates;
using System.Data;
using static System.Formats.Asn1.AsnWriter;

using System.IO;
using System.Windows.Forms;
using System.Reflection;

namespace ElderGame
{ 
    public enum Directionc
    {
        Middle,
        Right,
        Left
    }
    public enum CarState
    {
        GameStart,
        GameSet,
        GameOver,
        GamePlaying,
        GetPoint,
    }
    public class TempCar
    {
        Random random = new Random();
        Panel panel;
        FileInfo[] fileInfo;
        public PictureBox pictureBox = new PictureBox();
        public int Speed = 0;
        public TempCar(Panel _panel, FileInfo[] _fileInfo)
        {
            this.panel = _panel;    
            this.fileInfo = _fileInfo;
        }
        public void RandomCar()
        {
            pictureBox.Image = Image.FromFile(fileInfo[random.Next(1, (int)fileInfo.Length)].FullName);
            pictureBox.Location = new Point(random.Next(panel.Size.Width * 1 / 4, panel.Size.Width * 3 / 4 - pictureBox.Width), -pictureBox.Height - 20);
            Speed = random.Next(3, 10);
        }
        public void CreatTempCar()
        {
            pictureBox.Size = new Size(panel.Size.Width / 15, 200);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            panel.Controls.Add(pictureBox);
        }
        public CarState Update(PictureBox mycar)
        {
            pictureBox.Location = new Point(pictureBox.Location.X, pictureBox.Location.Y + Speed);
            if (mycar.Bounds.IntersectsWith(pictureBox.Bounds))
            {
                return CarState.GameOver;
            }
            else if (pictureBox.Top > panel.Height)
            {
                RandomCar();
                return CarState.GetPoint;
            }
            else 
            {
                return CarState.GamePlaying;
            }
        }
    }
    public class PictureLine //super class
    {
        public Point location;
        public Point shape;
        public PictureBox Line = new PictureBox();
        public Panel panel;
        public PictureLine(Point _location, Point _shape, Panel _panel)
        {
            this.location = _location;
            this.shape = _shape;
            this.panel = _panel;
        }      
        public void CreatLine()
        {
            Line.Location = location;
            Line.BackColor = Color.White;
            Line.Size = (Size)shape;
            //game start
            panel.Controls.Add(Line);
        }
    } 
   public class CarRace
    {
        public Random random = new Random();
        public CarState state = new CarState();
        public Panel panel;
        public List<PictureLine> BoundaryLine = new List<PictureLine>();
        public List<PictureLine> DashLine = new List<PictureLine>();
        public List<TempCar> CarTemp = new List<TempCar>();
        public FileInfo[] fileInfo = new FileInfo[1];
        public CarRace(Panel _panel) 
        {
            this.panel= _panel;
        }
        public void CreatBoundary()
        {
            for(int i =1;  i < 4; i+=2) //為了要湊1/4 3/4故意設i=1
            {
                PictureLine pictureLine = new PictureLine(new Point(panel.Size.Width*i / 4, 0),new Point(20, panel.Size.Height), panel);                                                
                pictureLine.CreatLine();
                BoundaryLine.Add(pictureLine);
            }
        }
        public void CreatDashLine()
        {
            Point DashLineSize = new Point(20, panel.Size.Height/6);
            for (int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 6; j+=2)
                {
                    Point DashLineLocation = new Point(panel.Size.Width * (i + 3) / 8, panel.Size.Height*j/6);
                    PictureLine pictureLine = new PictureLine(DashLineLocation, DashLineSize, panel);
                    pictureLine.CreatLine();
                    DashLine.Add(pictureLine);
                }
            }
        }
        public void ReadCarPic()
        {
            DirectoryInfo ProjectDir = new DirectoryInfo(System.Windows.Forms.Application.StartupPath);
            string InitialDirectory = ProjectDir.Parent.Parent.Parent.Parent.FullName;
            InitialDirectory += "\\picture_resource"; 
            DirectoryInfo pro = new DirectoryInfo(InitialDirectory);
            fileInfo = pro.GetFiles("*.png");
            for(int i = 0; i<3; i++)
            {
                TempCar tempCar = new TempCar(panel, fileInfo);
                tempCar.CreatTempCar();
                tempCar.RandomCar();
                CarTemp.Add(tempCar);
            }
        }
        public CarState MovingBack(PictureBox mycar)
        {
            foreach(PictureLine CurLine in DashLine)
            {
                CurLine.Line.Location = new Point(CurLine.Line.Location.X, CurLine.Line.Location.Y + 20);
                if(CurLine.Line.Top > panel.Size.Height)
                {
                    CurLine.Line.Location = new Point(CurLine.Line.Location.X, -panel.Size.Height / 6);
                }
            }
            foreach (TempCar car in CarTemp)
            {
                state = car.Update(mycar);
                if (state == CarState.GameOver)
                {
                    return CarState.GameOver;
                }
                else if (state == CarState.GetPoint)
                    return CarState.GetPoint;
            }
            foreach(PictureLine boundary in BoundaryLine)
            {
                if (mycar.Bounds.IntersectsWith(boundary.Line.Bounds))
                {
                    state = CarState.GameOver;
                }
            }
            return state;
        }
    }
}
