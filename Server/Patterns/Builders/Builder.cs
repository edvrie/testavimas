using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ObjektinisProgramuProjektavimas.Patterns.Factories;

namespace ObjektinisProgramuProjektavimas.Patterns.Builders
{
    public abstract class Builder
    {
        public abstract Cell BuildObject(int type, int x, int y);
    }
}
