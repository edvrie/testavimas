using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Help.Classes;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using System.Runtime.InteropServices;

namespace Help
{
    public partial class Form1 : Form
    {
        private HubConnection connection;
        private bool CreateForm = false;
        private Map Map;
        List<Image> ClientImages = new List<Image>();
        private bool MapCanBeDrawn = false;
        List<Robot> Robots;

        public Form1()
        {
            InitializeComponent();
            HideRobotInfo();
            SetElementsInfo();

            this.DoubleBuffered = true;

            connection = new HubConnectionBuilder()
             .WithUrl("https://localhost:44330/testHub")
             .Build();

            connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await connection.StartAsync();
            };

            // Client Window size
            MinimumSize = new Size(900,1080);
            MaximumSize = new Size(900, 1080);

            // Loads all images into memory
            string[] NameArray = {"Grass","Wall","Box","Water","ArmorBoost",            // 0 1 2 3 4
                                  "DamageBoost","Health","SpeedBoost",          // 5 6 7
                                  "P1RobotFighter","P1RobotMage","P1RobotTank",     // 8 9 10
                                  "P2RobotFighter", "P2RobotMage", "P2RobotTank"};  // 11 12 13
            foreach(string Name in NameArray)
            {
                ClientImages.Add(Image.FromFile("../../../Icons/" + Name + ".png"));
            }
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            connection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                this.Invoke((Action)(() =>
                {
                    var newMessage = $"{user}: {message}";
                    //messagesList.Items.Add(newMessage);
                }));
            });

            connection.On<string, string, string,string>("ReceiveMap", (map_name, map_string, robot1,robot2) =>
            {
                this.Invoke((Action)(() =>
                {
                    Map = new Map(map_name, map_string);

                    Robots = new List<Robot>();

                    string[] Robot1 = robot1.Split(" ");
                    string[] Robot2 = robot2.Split(" ");

                    int[] ParsedRobot1 = Array.ConvertAll(Robot1, s => int.Parse(s));
                    int[] ParsedRobot2 = Array.ConvertAll(Robot2, s => int.Parse(s));

                    Robots.Add(new Robot(ParsedRobot1[0], ParsedRobot1[1], ParsedRobot1[2], ParsedRobot1[3]));
                    Robots.Add(new Robot(ParsedRobot2[0], ParsedRobot2[1], ParsedRobot2[2], ParsedRobot2[3]));

                    var newMessage = $"{map_name}: {map_string}";
                    messagesList.Items.Add(newMessage);

                    CreateForm = true;

                    FixRobotData();
                    SetProgressBar();
                    Invalidate();
                }));
            });

            try
            {
                await connection.StartAsync();
                messagesList.Items.Add("Connection started");
            }
            catch (Exception ex)
            {
                messagesList.Items.Add(ex.Message);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void Form1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (MapCanBeDrawn == true)
            try
            {
                string KeyPressed = e.KeyChar.ToString().ToLower();
                char Keypressed = KeyPressed[0];


                char[] array = { 'w', 'a', 's', 'd', ' ','1','2','3','4','5'};

                if (array.Contains(Keypressed))
                {
                    if(Keypressed == ' ')
                    {
                        Keypressed = '_';
                    }
                    await connection.InvokeAsync("SendKeyboardEventAction", connection.ConnectionId, Keypressed);
                }
            }
            catch (Exception ex)
            {
                messagesList.Items.Add(ex.Message);
            }

        }

        public void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            if (CreateForm == true)
            {
                CreateMap(g,Map.LengthMap, Map.LengthMap, 100);
                FillMap(g, Map.LengthMap, Map.LengthMap, 100);
                DrawCenter(g);
                DrawRobots(g, Map.LengthMap, Map.LengthMap, 100);
            }
        }

        private void CreateMap(Graphics g,int Rows,int Columns,int BlockSize)
        {
            int w = this.ClientSize.Width;
            int h = this.ClientSize.Height;

            for (int x = 0; x < Columns; x++)
            {
                for (int y = 0; y < Rows; y++)
                {
                    double Xcord = w / 2 - (Convert.ToDouble(Columns) / 2 * BlockSize) + x * BlockSize;
                    double Ycord = h / 2 - (Convert.ToDouble(Rows) / 2 * BlockSize) + y * BlockSize;
                    g.DrawImage(ClientImages[0], Convert.ToInt32(Xcord), Convert.ToInt32(Ycord));
                }
            }
        }

        private void FillMap(Graphics g, int Rows, int Columns, int BlockSize)
        {
            int w = this.ClientSize.Width;
            int h = this.ClientSize.Height;

            for (int x = 0; x < Columns; x++)
            {
                for (int y = 0; y < Rows; y++)
                {
                    double Xcord = w / 2 - (Convert.ToDouble(Columns) / 2 * BlockSize) + x * BlockSize;
                    double Ycord = h / 2 - (Convert.ToDouble(Rows) / 2 * BlockSize) + y * BlockSize;

                    if(Map.objects[y,x] < ClientImages.Count())
                        g.DrawImage(ClientImages[Map.objects[y, x]], Convert.ToInt32(Xcord), Convert.ToInt32(Ycord));
                    else
                        messagesList.Items.Add("Item index outside of array");
                }
            }
        }

        private void DrawRobots(Graphics g, int Rows, int Columns, int BlockSize)
        {
            int w = this.ClientSize.Width;
            int h = this.ClientSize.Height;

            int i = 0;
            foreach(Robot robot in Robots)
            {
                int x = robot.X;
                int y = robot.Y;
                int Class = robot.Class;

                double Xcord = w / 2 - (Convert.ToDouble(Columns) / 2 * BlockSize) + x * BlockSize;
                double Ycord = h / 2 - (Convert.ToDouble(Rows) / 2 * BlockSize) + y * BlockSize;

                if (i == 0 && Class != 0)
                {
                    g.DrawImage(ClientImages[Class+7], Convert.ToInt32(Xcord), Convert.ToInt32(Ycord));
                }
                else if(Class != 0)
                {
                    g.DrawImage(ClientImages[Class + 10], Convert.ToInt32(Xcord), Convert.ToInt32(Ycord));
                }

                i++;
            }
        }

        private void DrawCenter(Graphics g)
        {
            int w = this.ClientSize.Width;
            int h = this.ClientSize.Height;
            g.DrawEllipse(Pens.Blue, w / 2 - 50, h / 2 - 50, 100, 100);
            g.DrawLine(Pens.Blue, w / 2, h / 2, w / 2 + 50, h / 2);
            g.DrawLine(Pens.Blue, w / 2, h / 2, w / 2 - 50, h / 2);
            g.DrawLine(Pens.Blue, w / 2, h / 2, w / 2, h / 2 + 50);
            g.DrawLine(Pens.Blue, w / 2, h / 2, w / 2, h / 2 - 50);
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            MapCanBeDrawn = true;
            HideClassButtons();
            ShowRobotInfo();
            await connection.InvokeAsync("SendClassEventAction", connection.ConnectionId, 1);
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            MapCanBeDrawn = true;
            HideClassButtons();
            ShowRobotInfo();
            await connection.InvokeAsync("SendClassEventAction", connection.ConnectionId, 2);
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            MapCanBeDrawn = true;
            HideClassButtons();
            ShowRobotInfo();
            await connection.InvokeAsync("SendClassEventAction", connection.ConnectionId, 3);
        }

        private void HideClassButtons()
        {
            button1.Hide();
            button2.Hide();
            button3.Hide();
        }
        private void HideRobotInfo()
        {
            progressBar1.Hide();
            progressBar2.Hide();
            textBox1.Hide();
            textBox2.Hide();
        }

        private void ShowRobotInfo()
        {
            progressBar1.Show();
            progressBar2.Show();
            textBox1.Show();
            textBox2.Show();
        }

        private void SetProgressBar()
        {
            //1-Green, 2-Red,3-Yellow

            if (Robots[0].Health >= 75)
                progressBar1.SetState(1);
            else if (Robots[0].Health < 75 && Robots[0].Health >= 25)
                progressBar1.SetState(3);
            else
                progressBar1.SetState(2);

            progressBar1.Value = Robots[0].Health;
            progressBar1.Increment(0);

            if (Robots[1].Health >= 75)
                progressBar2.SetState(1);
            else if (Robots[1].Health < 75 && Robots[1].Health >= 25)
                progressBar2.SetState(3);
            else
                progressBar2.SetState(2);

            progressBar2.Value = Robots[1].Health;
            progressBar2.Increment(0);

        }

        private void SetElementsInfo()
        {
            progressBar1.Maximum = 100;
            progressBar1.Minimum = 0;

            progressBar2.Maximum = 100;
            progressBar2.Minimum = 0;
        }

        private void FixRobotData()
        {
            foreach (Robot robo in Robots)
            {
                if (robo.Health > 100)
                    robo.Health = 100;
                if (robo.Health < 0)
                    robo.Health = 0;
            }
        }
    }

    public static class ModifyProgressBarColor
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr w, IntPtr l);
        public static void SetState(this ProgressBar pBar, int state)
        {
            SendMessage(pBar.Handle, 1040, (IntPtr)state, IntPtr.Zero);
        }
    }
}
