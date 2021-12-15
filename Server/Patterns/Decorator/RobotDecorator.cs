using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjektinisProgramuProjektavimas.Patterns.Decorator
{
    public abstract class RobotDecorator : IRobot
    {
        public IRobot Wrapee;

        public RobotDecorator(IRobot robot)
        {
            Wrapee = robot;
        }

        public virtual void ApplyDamage() { }

        public virtual void ApplyArmor() { }

        public virtual void ApplyHealth() { }

        public virtual void ApplySpeed() { }
    }
}
