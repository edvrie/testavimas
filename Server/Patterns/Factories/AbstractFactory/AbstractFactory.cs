using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjektinisProgramuProjektavimas.Patterns.Factories
{
    abstract public class AbstractFactory
    {
        public abstract Terrain CreateTerrain(int type, int x, int y);
        public abstract Item CreateItem(int type, int setBoost, int x, int y);
    }
}
