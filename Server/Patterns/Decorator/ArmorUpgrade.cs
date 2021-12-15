using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjektinisProgramuProjektavimas.Patterns.Decorator
{
    public class ArmorUpgrade : RobotDecorator
    {
        public ArmorUpgrade(IRobot robot) : base(robot) { }

        public override void ApplyArmor()
        {
            Wrapee.ApplyArmor();
        }
    }
}
