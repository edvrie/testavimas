using ObjektinisProgramuProjektavimas.Patterns.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjektinisProgramuProjektavimas.Patterns.Composite
{
    public interface IComponent
    {
        public IComponent getItem();
    }
}
