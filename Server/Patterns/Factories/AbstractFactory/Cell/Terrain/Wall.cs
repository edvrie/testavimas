using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjektinisProgramuProjektavimas.Patterns.Factories
{
    public class Wall : Terrain
    {
        public Wall(int x, int y)
        {
            PositionX = x;
            PositionY = y;
            IsWalkable = false;
            TextureID = 1;
        }
    }
}
