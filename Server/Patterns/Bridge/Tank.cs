using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjektinisProgramuProjektavimas.Patterns.Bridge
{
    public class Tank : RobotClasses
    {
        public override void SetStats()
        {
            robot.SetDamage(10);
            robot.SetHealth(100);
            robot.SetSpeed(10);
            robot.SetArmor(40);
        }
    }
}
