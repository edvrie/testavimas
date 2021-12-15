using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjektinisProgramuProjektavimas.Patterns.Bridge
{
    public class Fighter : RobotClasses 
    {
        public override void SetStats()
        {
            robot.SetDamage(15);
            robot.SetHealth(70);
            robot.SetSpeed(20);
            robot.SetArmor(20);
        }
    }
}
