using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjektinisProgramuProjektavimas.Patterns.Factories
{
    public abstract class Creator
    {
        public abstract Cell FactoryMethod(int type, int x, int y);
    }
}
