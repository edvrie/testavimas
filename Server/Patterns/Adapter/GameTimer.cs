using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ObjektinisProgramuProjektavimas.Patterns.Adapter
{
    public class GameTimer
    {
        public Stopwatch GlobalTimer;
        private long P1Previous = 0;
        private long P2Previous = 0;

        public GameTimer()
        {
            GlobalTimer = new Stopwatch();
            StartTimer();
        }

        public void StartTimer()
        {
            GlobalTimer.Start();
        }
        public long GetTimePlayer1()
        {
            long elapsedTime = GlobalTimer.ElapsedMilliseconds - P1Previous;
            return elapsedTime;
        }
        public void Player1TimeReset()
        {
            P1Previous = GlobalTimer.ElapsedMilliseconds;
        }

        public long GetTimePlayer2()
        {
            long elapsedTime = GlobalTimer.ElapsedMilliseconds - P2Previous;
            return elapsedTime;
        }

        public void Player2TimeReset()
        {
            P2Previous = GlobalTimer.ElapsedMilliseconds;
        }
    }
}
