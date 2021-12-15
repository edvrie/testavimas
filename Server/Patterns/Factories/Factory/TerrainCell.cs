using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjektinisProgramuProjektavimas.Patterns.Factories
{
    public class TerrainCell : CellFactory
    {
        public override AbstractFactory GetAbstractFactory()
        {
            return new TerrainFactory();
        }
    }
}
