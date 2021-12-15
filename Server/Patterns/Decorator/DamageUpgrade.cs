using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjektinisProgramuProjektavimas.Patterns.Decorator
{
    public class DamageUpgrade : RobotDecorator
    {
        public DamageUpgrade(IRobot robot) : base(robot) {  }

        public override void ApplyDamage()
        {
            Wrapee.ApplyDamage();
        }
    }
}
