using ObjektinisProgramuProjektavimas.Patterns.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjektinisProgramuProjektavimas.Patterns.Template
{
    public class GenerateItem : GenerateObject
    {
        public override Coordinates genereateLocation(Singleton.Singleton Map, List<Robot> Robo)
        {
            int[,] objects = new int[Map.GetMap().size, Map.GetMap().size];

            foreach (var obj in Map.GetMap().cellList)
            {
                if (obj.TextureID != 0)
                    objects[obj.PositionY, obj.PositionX] = 1;
            }

            foreach (var rob in Robo)
            {
                objects[rob.X, rob.Y] = 1;
            }

            List<Coordinates> cord = new List<Coordinates>();

            for (int i = 0; i < Map.GetMap().size; i++)
            {
                for (int g = 0; g < Map.GetMap().size; g++)
                {
                    if (objects[i, g] == 0)
                    {
                        cord.Add(new Coordinates(i, g));
                    }
                }
            }

            Random rnd = new Random();
            int random = rnd.Next(0, cord.Count);

            if (cord.Count == 0)
                return new Coordinates(-1,-1);
            else
                return cord[random];
        }

        public override int generateItem()
        {
            Random rnd = new Random();
            int random = rnd.Next(4,8);

            return random;
        }
    }
}
