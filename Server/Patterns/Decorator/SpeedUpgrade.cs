using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjektinisProgramuProjektavimas.Patterns.Decorator
{
    public class SpeedUpgrade : RobotDecorator
    {
        public SpeedUpgrade(IRobot robot) : base(robot) { }

        public override void ApplySpeed()
        {
            Wrapee.ApplySpeed();
        }
    }
}
