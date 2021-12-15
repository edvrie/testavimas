using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ObjektinisProgramuProjektavimas.Patterns.Factories;

namespace ObjektinisProgramuProjektavimas.Patterns.Builders
{
    public class Director
    {
        private List<Cell> cellsList = new List<Cell>();
        public void Construct(TerrainBuilder terrainBuilder, ItemBuilder itemBuilder, int[,] mapArray, int size)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    int type = mapArray[i, j];

                    if (type < 0)
                    {
                        cellsList.Add(itemBuilder.BuildObject(type, i, j));
                    } else
                    { 
                        cellsList.Add(terrainBuilder.BuildObject(type, i, j));
                    }
                }
            } 
        }

        public List<Cell> GetResults()
        {
            return cellsList;
        }
    }
}
