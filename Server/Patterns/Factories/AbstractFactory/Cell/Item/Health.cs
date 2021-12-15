using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjektinisProgramuProjektavimas.Patterns.Factories
{
    public class Health : Item
    {
        private int HealthBoost { get; set; }

        public Health(int health, int x, int y)
        {
            HealthBoost = health;
            PositionX = x;
            PositionY = y;
            TextureID = 4;
        }

        public int GetHealthIncrease()
        {
            return HealthBoost;
        }
    }
}
