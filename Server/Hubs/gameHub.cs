using Microsoft.AspNetCore.SignalR;
using ObjektinisProgramuProjektavimas.Hubs;
using ObjektinisProgramuProjektavimas.Patterns.Bridge;
using ObjektinisProgramuProjektavimas.Patterns.Command;
using ObjektinisProgramuProjektavimas.Patterns.Decorator;
using ObjektinisProgramuProjektavimas.Patterns.Facade;
using ObjektinisProgramuProjektavimas.Patterns.Observer;
using ObjektinisProgramuProjektavimas.Patterns.Singleton;
using ObjektinisProgramuProjektavimas.Patterns.Strategy;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRChat.Hubs
{
    [ExcludeFromCodeCoverage]
    public class gameHub : Hub
    {
		public Facade facade = new Facade();

        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        public gameHub GetHub()
		{
            return this;
		}

        public async Task SendMessage(string user, string message)
        {
            await facade.SendMessage(user, message, this);
        }

        public async Task SendClassEventAction(string userId, int selectedClass)
        {
            await facade.SendClassEventAction(userId, selectedClass, this);
        }

        public async Task SendKeyboardEventAction(string userId, string keyPress)
        {
            await facade.SendKeyboardEventAction(userId, keyPress, this);
        }


        public async Task ShowPatternResult(string text)
        {
            await facade.ShowPatternResult(text, this);
        }
    }
}