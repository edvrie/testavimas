using ObjektinisProgramuProjektavimas.Patterns.Decorator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjektinisProgramuProjektavimas.Patterns.Bridge
{
    public abstract class RobotClasses
    {

        protected RobotAbsc robot;

        public RobotAbsc Robot
        {
            get { return robot; }
            set { robot = value; }
        }

        abstract public void SetStats();
    }
}
