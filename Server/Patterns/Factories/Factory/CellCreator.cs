using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjektinisProgramuProjektavimas.Patterns.Factories
{
    public class CellCreator : Creator
    {
        public override Cell FactoryMethod(int type, int x, int y)
        {
            ItemFactory IFactory = new ItemFactory();
            TerrainFactory TFactory = new TerrainFactory();

            if (type < 0)
                return IFactory.CreateItem(type, 5, x, y);

            return TFactory.CreateTerrain(type, x, y);
        }
    }
}
