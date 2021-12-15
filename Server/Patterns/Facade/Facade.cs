using Microsoft.AspNetCore.SignalR;
using ObjektinisProgramuProjektavimas.Hubs;
using ObjektinisProgramuProjektavimas.Patterns.Bridge;
using ObjektinisProgramuProjektavimas.Patterns.Command;
using ObjektinisProgramuProjektavimas.Patterns.Decorator;
using ObjektinisProgramuProjektavimas.Patterns.Factories;
using ObjektinisProgramuProjektavimas.Patterns.Observer;
using ObjektinisProgramuProjektavimas.Patterns.Proxy;
using ObjektinisProgramuProjektavimas.Patterns.Singleton;
using ObjektinisProgramuProjektavimas.Patterns.Strategy;
using ObjektinisProgramuProjektavimas.Patterns.Template;
using SignalRChat.Hubs;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace ObjektinisProgramuProjektavimas.Patterns.Facade
{
    [ExcludeFromCodeCoverage]
    public class Facade
    {
        public Singleton.Singleton Map;
        public static List<Robot> Robot = new List<Robot>();
        public Subject server = new Server();

        public Timer GlobalTimer;

        public Facade()
        {
            this.Map = Singleton.Singleton.GetInstance();
        }

        public async Task SendMessage(string user, string message, gameHub hub)
        {
            await hub.Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task SendClassEventAction(string userId, int selectedClass, gameHub hub)
        {
            string MapName = Map.GetMap().map_name;
            int MapLength = Map.GetMap().size;


            if (Robot.Count() == 0)
            {
                Robot.Add(new Robot(hub.Context.ConnectionId, 0, 0, selectedClass));
                Robot.Add(new Robot(null, MapLength - 1, MapLength - 1, 0));

                foreach (Robot robo in Robot)
                {
                    robo.Health = 100;
                }
            }
            else
            {
                Robot[1].Id = hub.Context.ConnectionId;
                Robot[1].Class = selectedClass;
            }

            await hub.Clients.All.SendAsync("ReceiveMessage", hub.Context.ConnectionId, selectedClass.ToString());

            string Robot1 = Robot[0].X + " " + Robot[0].Y + " " + Robot[0].Class + " " + Robot[0].Health;
            string Robot2 = Robot[1].X + " " + Robot[1].Y + " " + Robot[1].Class + " " + Robot[1].Health;
            await hub.Clients.All.SendAsync("ReceiveMap", MapName, Map.GetMap().MapToString(), Robot1, Robot2);
        }

        public async Task SendKeyboardEventAction(string userId, string keyPress, gameHub hub)
        {
            int WhichRobot = 0;

            foreach(Robot robot in Robot)
            {
                if (robot.Id != null)
                {
                    WhichRobot++;
                    if (robot.Id == userId)
                    {
                        break;
                    }
                }
            }

            long Values = Map.Timer.GetPlayerTime(WhichRobot);

            if (Values > 20)
            {
                //await Clients.All.SendAsync("ReceiveMessage", userId, keyPress);
                Robot RobotById = Robot.Find((robot) => robot.Id == userId);
                if (RobotById == null) return;

                RobotAbsc robot = new Robot("test", 1, 1, 1);
                RobotClasses cllass = new Mage();
                cllass.Robot = robot;
                cllass.SetStats();

                IProxy robotController = new MoveProxy(RobotById);
                server.Attach(RobotById, hub);
                switch (keyPress)
                {
                    case "w":
                        robotController.Run(hub, new MoveUp());
                        break;
                    case "s":
                        robotController.Run(hub, new MoveDown());
                        break;
                    case "a":
                        robotController.Run(hub, new MoveLeft());
                        break;
                    case "d":
                        robotController.Run(hub, new MoveRight());
                        break;
                    case "1":
                        RobotById.PerformAction(hub, new Ability1());
                        //RobotById.SetUsedAbility(hub, new Ability1());
                        //RobotById.UseAbility(hub);
                        break;
                    case "2":
                        RobotById.PerformAction(hub, new Ability2());
                        //RobotById.SetUsedAbility(hub, new Ability2());
                        //RobotById.UseAbility(hub);
                        break;
                    case "5":
                        robotController.Undo(hub);
                        break;
                    case "_":
                        RobotById.PerformAction(hub, new Shoot());
                        //RobotById.SetShoot(hub, new Shoot());
                        //RobotById.Shoot(hub);
                        break;
                }

                Map.Timer.ResetPlayerTimer(WhichRobot);

            }

            GenerateObject objekctas = new GenerateItem();
            objekctas.finalObject(Map, Robot);
        }


        public async Task ShowPatternResult(string text, gameHub hub)
        {
            string[] UpdateData = text.Split(" ");
            string ID = UpdateData[1];
            string Action = UpdateData[2];

            int i = 0;
            foreach (Robot robot in Robot)
            {
                if (robot.Id == ID)
                {
                    break;
                }
                i++;
            }

            MoveRobot(Action, i);
            CheckTile(i,hub);

            //Check Health Bars
            Robot[0].Health = Robot[0].Health - 10;

            string Robot1 = Robot[0].X + " " + Robot[0].Y + " " + Robot[0].Class + " " + Robot[0].Health;
            string Robot2 = Robot[1].X + " " + Robot[1].Y + " " + Robot[1].Class + " " + Robot[1].Health;
            await hub.Clients.All.SendAsync("ReceiveMap", Map.GetMap().map_name, Map.GetMap().MapToString(), Robot1, Robot2);
            //await Clients.All.SendAsync("ReceiveMessage", "Server" + "("+Context.ConnectionId+")", text);
        }

        public async void CheckTile(int ID, gameHub hub)
        {
            int[] Items = { -1, -2, -3, -4 };

            int GetTileValue = Map.GetMap().objects[Robot[ID].Y, Robot[ID].X];


            if(Items.Contains(GetTileValue))
            {
                Map.EditTile(Robot[ID].Y, Robot[ID].X);

                IRobot TestRobot = Robot[ID];
                switch (GetTileValue)
                {
                    case -1:
                        TestRobot.ApplyHealth();
                        break;
                    case -2:
                        TestRobot.ApplyDamage();
                        break;
                    case -3:
                        TestRobot.ApplyArmor();
                        break;
                    case -4:
                        TestRobot.ApplySpeed();
                        break;
                }
            }
        }

        public async void MoveRobot(string Action,int ID)
        {

            if (Action == "MoveDown")
            {
                Robot[ID].Y = Robot[ID].Y + 1;
            }
            if (Action == "MoveLeft")
            {
                Robot[ID].X = Robot[ID].X - 1;
            }
            if (Action == "MoveRight")
            {
                Robot[ID].X = Robot[ID].X + 1;
            }
            if (Action == "MoveUp")
            {
                Robot[ID].Y = Robot[ID].Y - 1;
            }
        }
    }

}
