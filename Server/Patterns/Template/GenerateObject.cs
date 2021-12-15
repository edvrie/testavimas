using ObjektinisProgramuProjektavimas.Patterns.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjektinisProgramuProjektavimas.Patterns.Template
{
    public abstract class GenerateObject
    {
        public void finalObject (Singleton.Singleton Map, List<Robot> Robo)
        {
            Coordinates coord = genereateLocation(Map,Robo);
            int item = generateItem();

            if(coord.X != -1 || coord.Y != -1)
                Map.EditTile(coord.Y, coord.X, item);
        }

        public abstract Coordinates genereateLocation(Singleton.Singleton Map, List<Robot> Robo);
        public abstract int generateItem();
    }
}
