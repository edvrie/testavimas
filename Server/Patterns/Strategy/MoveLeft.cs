using SignalRChat.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjektinisProgramuProjektavimas.Patterns.Strategy
{
    public class MoveLeft : Move
    {
        public override string Perform()
        {
            state = "MoveLeft";
            return "MoveLeft";
        }

        public override Move Undo()
        {
           return new MoveRight();
        }
    }
}
