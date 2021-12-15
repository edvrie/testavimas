using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ObjektinisProgramuProjektavimas.Patterns.Factories;
using ObjektinisProgramuProjektavimas.Patterns.Builders;


namespace ObjektinisProgramuProjektavimas.Patterns.Singleton
{

    public class Map
    {
        public string map_name { get; set; }
        public int size { get; set; }
        public int[,] objects { get; set; }

        public List<Cell> cellList { get; set; }

        private readonly Random _random = new Random();

        public Map()
        {
            int number = RandomNumber(1, 3);
            this.map_name = "map"+ number;
            ReadFile(number);
            GenerateMap();
        }

        public int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }

        private void ReadFile(int number)
        {
            string json = System.IO.File.ReadAllText("Patterns/Singleton/Maps/map"+ number + ".json");
            var map = JsonConvert.DeserializeObject<List<JsonMap>>(json);
            this.objects = map[0].objects;
            this.size = map[0].size;
        }

        public string MapToString()
        {
            string temp_string = "";

            foreach (var cell in cellList)
            {
                temp_string += cell.TextureID + " ";
            }
           
            return temp_string;
        }

        private void GenerateMap()
        {
            Director director = new Director();
            TerrainBuilder terrainBuilder = new TerrainBuilder();
            ItemBuilder itemBuilder = new ItemBuilder();

            director.Construct(terrainBuilder, itemBuilder, objects, size);

            cellList = director.GetResults();
        }
    }
}
