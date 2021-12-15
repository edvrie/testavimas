using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjektinisProgramuProjektavimas.Patterns.Adapter
{
    public interface ITimer
    {
        public void StartTimer();

        public long GetPlayerTime(int Player);

        public void ResetPlayerTimer(int Player);
    }
}
