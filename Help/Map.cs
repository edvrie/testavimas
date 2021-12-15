using System;
using System.Collections.Generic;
using System.Text;

namespace Help
{
	class Map
	{
		public string map_name { get; set; }
		public int[,] objects { get; set; }

		public int LengthMap { get; set; }
		public string MapToString()
		{
			string temp_string = "";
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					temp_string = temp_string + " " + objects[i, j];
				}
			}
			return temp_string;
		}



        public Map(string map_name, string mapString)
        {
            this.map_name = map_name;
            this.objects = StringTo2D(mapString);
        }

        public Map()
        {
        }

        public int[,] StringTo2D(string text)
        {
			text = text.Trim();
			string[] i = text.Split(' ');

			int Length = i.Length;
			int ArrayLength =Convert.ToInt32(Math.Sqrt(Length));

			LengthMap = ArrayLength;

			int[,] Map = new int[ArrayLength, ArrayLength];

			for(int x=0;x<ArrayLength;x++)
            {
				for(int y=0;y<ArrayLength;y++)
                {
					Map[x,y] = Convert.ToInt32(i[x * ArrayLength + y]);
                }
            }

			return Map;
        }
	}
}
