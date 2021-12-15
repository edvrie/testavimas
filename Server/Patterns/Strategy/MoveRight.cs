using SignalRChat.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjektinisProgramuProjektavimas.Patterns.Strategy
{
    public class MoveRight : Move
    {
        public override string Perform()
        {
            state = "MoveRight";
            return "MoveRight";
        }

        public override Move Undo()
        {
            return new MoveLeft();
        }
    }
}
