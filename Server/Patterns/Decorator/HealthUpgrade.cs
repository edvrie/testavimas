using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjektinisProgramuProjektavimas.Patterns.Decorator
{
    public class HealthUpgrade : RobotDecorator
    {
        public HealthUpgrade(IRobot robot) : base(robot) { }

        public override void ApplyHealth()
        {
            Wrapee.ApplyHealth();
        }
    }
}
