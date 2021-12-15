using ObjektinisProgramuProjektavimas.Patterns.Prototype;

namespace ObjektinisProgramuProjektavimas.Patterns.Factories
{
    public class TerrainFactory : AbstractFactory
    {
        PrototypeManager manager = new PrototypeManager();

        public override Terrain CreateTerrain(int type, int x, int y)
        {
            switch (type)
            {
                case 0:
                    Grass grass = (Grass)manager.cellPrototypes["Grass"].Clone();
                    grass.PositionX = x;
                    grass.PositionY = y;
                    return grass;
                case 1:
                    Wall wall = (Wall)manager.cellPrototypes["Wall"].Clone();
                    wall.PositionX = x;
                    wall.PositionY = y;
                    return wall;
                case 2:
                    Water water = (Water)manager.cellPrototypes["Water"].Clone();
                    water.PositionX = x;
                    water.PositionY = y;
                    return water;
                case 3:
                    Box box = (Box)manager.cellPrototypes["Box"].Clone();
                    box.PositionX = x;
                    box.PositionY = y;
                    return box;
                default:
                    return null;
            }
        }

        public override Item CreateItem(int type, int setBoost, int x, int y)
        {
            return null;
        }
    }
}
