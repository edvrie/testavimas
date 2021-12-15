using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjektinisProgramuProjektavimas.Patterns.Factories
{
    public abstract class Terrain : Cell
    {
        public bool IsWalkable { get; set; }
    }
}
