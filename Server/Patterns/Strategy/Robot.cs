using Microsoft.AspNetCore.SignalR;
using ObjektinisProgramuProjektavimas.Patterns.Bridge;
using ObjektinisProgramuProjektavimas.Patterns.Decorator;
using ObjektinisProgramuProjektavimas.Patterns.Observer;
using SignalRChat.Hubs;
using System.Diagnostics.CodeAnalysis;

namespace ObjektinisProgramuProjektavimas.Patterns.Strategy
{
    public class Robot : RobotAbsc, IRobot, IObserver
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Class { get; set; }

        public Shoot shoot = new Shoot();
        public UseAbility useAbility = new UseAbility();
        public string Id;

        public int Health { get; set; }
        public int Damage { get; set; }
        public int Armor { get; set; }
        public int Speed { get; set; }
        public Robot(string connId,int x,int y,int clas)
		    {
            Id = connId;
            X = x;
            Y = y;
            Class = clas;
        }

        public void Move(Move move, gameHub hub)
        {
            this.NotifyServer(move.Perform(), hub);
        }

        public void ApplyDamage()
        {
            Damage += 1;
        }

        public void ApplyArmor()
        {
            Armor += 1;
        }

        public void ApplyHealth()
        {
            Health += 20;
        }

        public void ApplySpeed()
        {
            Speed += 1;
        }

        public override void SetHealth(int amount)
        {
            Health = amount;
        }

        public override void SetArmor(int amount)
        {
            Armor = amount;
        }

        public override void SetDamage(int amount)
        {
            Damage = amount;
        }

        public override void SetSpeed(int amount)
        {
            Speed = amount;
        }

        public void HealthIncrease(int amount)
        {
            Health += amount;
        }

        public void DamageIncrease(int amount)
        {
            Damage += amount;
        }

        public void ArmorIncrease(int amount)
        {
            Armor += amount;
        }

        public void SpeedIncrease(int amount)
        {
            Speed += amount;
        }
        
        [ExcludeFromCodeCoverage]
        public void PerformAction(gameHub hub, Action action)
		{
            this.NotifyServer(action.Perform(), hub);
        }

        public Subject server;

        public void setServer(Subject server, gameHub hub)
        {
            this.server = server;
        }

        public void NotifyServer(string eventMsg, gameHub hub)
        {
            server.ReceiveFromClient(eventMsg, hub);
        }

        [ExcludeFromCodeCoverage]
        public async void Update(string eventMsg, gameHub hub)
        {
            await hub.ShowPatternResult("OBSERVERUPDATE " + Id + " " + eventMsg);
        }
    }
}
