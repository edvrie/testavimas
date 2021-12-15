using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjektinisProgramuProjektavimas.Patterns.Bridge
{
    public abstract class RobotAbsc
    {
        public abstract void SetHealth(int value);
        public abstract void SetArmor(int value);
        public abstract void SetDamage(int value);
        public abstract void SetSpeed(int value);
    }
}
