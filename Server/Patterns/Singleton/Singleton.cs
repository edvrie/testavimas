using ObjektinisProgramuProjektavimas.Patterns.Adapter;
using ObjektinisProgramuProjektavimas.Patterns.Factories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace ObjektinisProgramuProjektavimas.Patterns.Singleton
{
    public class Singleton
    {
        private static Singleton instance = null;
        private static object threadLock = new object();
        public ITimer Timer;

        public int Counter = 0;

        private Map Map = null;

        private Singleton()
        {
            GameTimer timer = new GameTimer();
            Timer = new TimerAdapter(timer);
            Console.WriteLine("Singleton initialized");
            Counter++;
            Map = new Map();
        }

        public static Singleton GetInstance()
        {
            lock (threadLock)
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
            }
            Console.WriteLine("Returning instance");
            return instance;
        }

        public Map GetMap()
        {
            return Map;
        }

        public void UpdateMap(Map new_map)
        {
            if(instance!= null)
            {
                Map = new_map;
            }
        }

        public void EditTile(int y,int x,int value = 0)
        {
            Map.cellList[y* Map.objects.GetLength(1) + x].TextureID = value;

            switch (value)
            {
                case 4:
                    Map.objects[y, x] = -3;
                    break;
                case 5:
                    Map.objects[y, x] = -2;
                    break;
                case 6:
                    Map.objects[y, x] = -1;
                    break;
                case 7:
                    Map.objects[y, x] = -4;
                    break;
                default:
                    Map.objects[y, x] = value;
                    break;
            }
        }
    }
}
