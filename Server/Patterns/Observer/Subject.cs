using ObjektinisProgramuProjektavimas.Hubs;
using SignalRChat.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;

namespace ObjektinisProgramuProjektavimas.Patterns.Observer
{
    public class Subject
    {
        public List<IObserver> robotList = new List<IObserver>();

        public void Attach(IObserver robot, gameHub hub)
        {
            robotList.Add(robot);
            robot.setServer(this, hub);
        }

        public void Detach(IObserver robot)
        {
            robotList.Remove(robot);
        }

        public void ReceiveFromClient(string eventMsg, gameHub hub)
        {
            NotifyAll(eventMsg, hub);
        }

        [ExcludeFromCodeCoverage]
        public void NotifyAll(string eventMsg, gameHub hub)
        {
            foreach(var robot in robotList)
            {
                robot.Update(eventMsg, hub);
            }
        }
    }
}
