using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjektinisProgramuProjektavimas.Patterns.Decorator
{
    public interface IRobot
    {
        void ApplyDamage();

        void ApplyArmor();

        void ApplyHealth();

        void ApplySpeed();
    }
}
