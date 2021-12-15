using SignalRChat.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjektinisProgramuProjektavimas.Patterns.Observer
{
    public interface IObserver
    {
        void Update(string eventMsg, gameHub hub);

        void NotifyServer(string eventMsg, gameHub hub);

        void setServer(Subject server, gameHub hub);
    }
}
