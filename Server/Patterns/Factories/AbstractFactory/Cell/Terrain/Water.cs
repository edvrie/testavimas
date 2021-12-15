using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjektinisProgramuProjektavimas.Patterns.Factories
{
    public class Water : Terrain
    {
		private int SlowAmmount { get; set; }

		public Water(int x, int y)
		{
			PositionX = x;
			PositionY = y;
			SlowAmmount = 2;
			IsWalkable = true;
			TextureID = 3;
		}

		public int GetSlowAmmount()
        {
			return SlowAmmount;
        }
	}
}
