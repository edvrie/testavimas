using ObjektinisProgramuProjektavimas.Patterns.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjektinisProgramuProjektavimas.Patterns.Factories
{
    public abstract class Item : Cell, IComponent
    { 
        public IComponent getItem()
        {
            return this;
        }
    }
}
