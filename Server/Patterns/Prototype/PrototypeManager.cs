using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ObjektinisProgramuProjektavimas.Patterns.Factories;

namespace ObjektinisProgramuProjektavimas.Patterns.Prototype
{
    [Serializable()]
    public class PrototypeManager : IPrototype<Cell>
    {
        public Dictionary<string, Cell> cellPrototypes
            = new Dictionary<string, Cell>
            {
                {
                    "Grass",
                    new Grass(-1, -1)
                },
                {
                    "Box",
                    new Box(-1, -1)
                },
                { 
                    "Water",
                    new Water(-1, -1)
                },
                {
                    "Wall",
                    new Wall(-1, -1)
                }

            };
    }
}
