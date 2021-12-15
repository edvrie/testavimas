using Microsoft.AspNetCore.SignalR;
using ObjektinisProgramuProjektavimas.Patterns.Strategy;
using SignalRChat.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjektinisProgramuProjektavimas.Patterns.Adapter
{
    public class TimerAdapter: ITimer
    {
        private readonly GameTimer _adaptee;

        public TimerAdapter(GameTimer adaptee)
        {
            _adaptee = adaptee;
        }

        public void StartTimer()
        {
            _adaptee.StartTimer();
        }

        public void ResetPlayerTimer(int Player)
        {
            if (Player == 1)
            {
                _adaptee.Player1TimeReset();
            }
            else
            {
                _adaptee.Player2TimeReset();
            }

        }

        public long GetPlayerTime(int Player)
        {
            if (Player == 1)
            {
                return _adaptee.GetTimePlayer1();
            }
            else
            {
                return _adaptee.GetTimePlayer2();
            }
        }
    }
}
