using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjektinisProgramuProjektavimas.Patterns.Factories
{
    public class Grass : Terrain
    {
        public bool HasItem { get; set; }

        public Grass(int x, int y)
        {
            PositionX = x;
            PositionY = y;
            HasItem = false;
            IsWalkable = true;
            TextureID = 0;
        }

        public void AddItem()
        {
            HasItem = true;
        }
    }
}
