using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjektinisProgramuProjektavimas.Patterns.Bridge
{
    public class Human : RobotAbsc
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Class { get; set; }

        public string Id;

        public int Health { get; set; }
        public int Damage { get; set; }
        public int Armor { get; set; }
        public int Speed { get; set; }
        public Human(string connId, int x, int y, int clas)
        {
            Id = connId;
            X = x;
            Y = y;
            Class = clas;
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
    }
}
