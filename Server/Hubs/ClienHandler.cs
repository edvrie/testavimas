using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace ObjektinisProgramuProjektavimas.Hubs
{
    [ExcludeFromCodeCoverage]
    public class Client : Hub
    {
        public string Id { get; set; }
    }
}
