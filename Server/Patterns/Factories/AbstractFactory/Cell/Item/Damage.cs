using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjektinisProgramuProjektavimas.Patterns.Factories
{
    public class Damage : Item
    {
        private int DamageBoost { get; set; }

        public Damage(int damage, int x, int y)
        {
            DamageBoost = damage;
            PositionX = x;
            PositionY = y;
            TextureID = 5;
        }

        public int GetDamageIncrease()
        {
            return DamageBoost;
        }
    }
}
