using ObjektinisProgramuProjektavimas.Patterns.Strategy;
using SignalRChat.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjektinisProgramuProjektavimas.Patterns.Proxy
{
    interface IProxy
    {
        public void Run(gameHub hub, Move move);

        public void Undo(gameHub hub);
    }
}
