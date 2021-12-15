using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjektinisProgramuProjektavimas.Patterns.Factories
{
    public class Speed : Item 
    {
        private int SpeedBoost { get; set; }

        public Speed(int speed, int x, int y)
        {
            SpeedBoost = speed;
            PositionX = x;
            PositionY = y;
            TextureID = 7;
        }

        public int GetSpeedIncrease()
        {
            return SpeedBoost;
        }
    }
}
