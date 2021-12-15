using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjektinisProgramuProjektavimas.Patterns.Bridge
{
    public class Mage : RobotClasses
    {
        public override void SetStats()
        {
            robot.SetDamage(20);
            robot.SetHealth(50);
            robot.SetSpeed(10);
            robot.SetArmor(10);
        }
    }
}
