using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjektinisProgramuProjektavimas.Patterns.Factories
{
    public class ItemCell : CellFactory
    { 
        override public AbstractFactory GetAbstractFactory()
        {
            return new ItemFactory();
        }
    }
}
