using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjektinisProgramuProjektavimas.Patterns.Factories
{
    public class Armor : Item
    {
        private int ArmorBoost { get; set; }

        public Armor(int armor, int x, int y)
        {
            ArmorBoost = armor;
            PositionX = x;
            PositionY = y;
            TextureID = 6;
        }

        public int GetArmorIncrease()
        {
            return ArmorBoost;
        }
    }
}
