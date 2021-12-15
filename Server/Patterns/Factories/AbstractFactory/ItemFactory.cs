using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjektinisProgramuProjektavimas.Patterns.Factories
{
    public class ItemFactory : AbstractFactory
    {
        public override Terrain CreateTerrain(int type, int x, int y)
        {
            return null;
        }

        public override Item CreateItem(int type, int setBoost, int x, int y)
        {
            switch (type)
            {
                case -1:
                    return new Armor(setBoost, x, y);
                case -2:
                    return new Damage(setBoost, x, y);
                case -3:
                    return new Health(setBoost, x, y);
                case -4:
                    return new Speed(setBoost, x, y);
                default:
                    return null;
            }
        }
    }
}
