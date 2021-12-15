using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjektinisProgramuProjektavimas.Patterns.Singleton
{
    public class JsonMap
    {
		public string map_name { get; set; }
		public int size { get; set; }
		public int[,] objects { get; set; }
	}
}
