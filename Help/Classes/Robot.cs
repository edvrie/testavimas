using System;
using System.Collections.Generic;
using System.Text;

namespace Help.Classes
{
    class Robot
    {
        public int X { get; set; }
        public int Y { get; set; }

        public int Class { get; set; }

        public int Health { get; set; }

        public Robot(int x, int y,int clas,int health)
        {
            X = x;
            Y = y;
            Class = clas;
            Health = health;
        }

    }
}
