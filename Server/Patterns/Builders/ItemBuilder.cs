using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ObjektinisProgramuProjektavimas.Patterns.Factories;
using ObjektinisProgramuProjektavimas.Patterns.Prototype;

namespace ObjektinisProgramuProjektavimas.Patterns.Builders
{
    public class ItemBuilder : Builder
    {
        private CellCreator creator = new CellCreator();
        public Cell AddHealthItem(int type, int x, int y)
        {
            return creator.FactoryMethod(type, x, y);
        }

        public Cell AddDamageItem(int type, int x, int y)
        {
            return creator.FactoryMethod(type, x, y);
        }

        public Cell AddArmorItem(int type, int x, int y)
        {
            return creator.FactoryMethod(type, x, y);
        }

        public Cell AddSpeedItem(int type, int x, int y)
        {
            return creator.FactoryMethod(type, x, y);
        }

        public override Cell BuildObject(int type, int x, int y)
        {
            switch (type)
            {
                case -1:
                    return AddHealthItem(type, x, y);
                case -2:
                    return AddDamageItem(type, x, y);
                case -3:
                    return AddArmorItem(type, x, y);
                case -4:
                    return AddSpeedItem(type, x, y);
                default:
                    return null;
            }
        }
    }
}
