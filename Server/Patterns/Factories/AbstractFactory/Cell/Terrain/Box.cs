using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjektinisProgramuProjektavimas.Patterns.Factories
{
    public class Box : Terrain
    {
		public bool HasItem { get; set; }
		public bool IsDestroyed { get; set; }
		public Box(int x, int y)
		{
			PositionX = x;
			PositionY = y;
			HasItem = false;
			IsDestroyed = false;
			IsWalkable = true;
			TextureID = 2;
		}

		public void Destroy()
		{
			IsDestroyed = true;
			TextureID = 5;
		}

		public void AddItem()
		{
			HasItem = true;
		}
	}
}
