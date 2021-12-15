using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ObjektinisProgramuProjektavimas.Patterns.Prototype;

namespace ObjektinisProgramuProjektavimas.Patterns.Factories
{
    [Serializable()]
    public abstract class Cell : IPrototype<Cell>
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int TextureID { get; set; }
    }
}
