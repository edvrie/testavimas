using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ObjektinisProgramuProjektavimas.Patterns.Factories;
using ObjektinisProgramuProjektavimas.Patterns.Prototype;

namespace ObjektinisProgramuProjektavimas.Patterns.Builders
{
    public class TerrainBuilder : Builder
    {
        private CellCreator creator = new CellCreator();
        public Cell AddTerrainGrass(int type, int x, int y)
        {
            return creator.FactoryMethod(type, x, y);
        }

        public Cell AddTerrainWater(int type, int x, int y)
        {
            return creator.FactoryMethod(type, x, y);
        }

        public Cell AddTerrainBox(int type, int x, int y)
        {
            return creator.FactoryMethod(type, x, y);
        } 

        public Cell AddTerrainWall(int type, int x, int y)
        {
            return creator.FactoryMethod(type, x, y);
        }

        public override Cell BuildObject(int type, int x, int y)
        { 
            switch (type)
            {
                case 0:
                    return AddTerrainGrass(type, x, y);
                case 1:
                    return AddTerrainWall(type, x, y);
                case 2:
                    return AddTerrainBox(type, x, y);
                case 3:
                    return AddTerrainWater(type, x, y);
                default:
                    return null;
            }
        }
    }
}
