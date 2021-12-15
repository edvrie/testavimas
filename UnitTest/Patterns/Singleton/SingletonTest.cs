using NUnit.Framework;
using ObjektinisProgramuProjektavimas.Patterns.Singleton;
using ObjektinisProgramuProjektavimas.Patterns.Template;

namespace SingletonTest
{

    [TestFixture]
    public class SingletonTest
    {
        [Test]
        public void Singleton_GetInstance_Once_True()
        {
            Singleton Zemelapis = Singleton.GetInstance();
            Assert.That(Zemelapis.Counter == 1);
        }

        [Test]
        public void Singleton_GetInstance_Twice_False ()
        {
            Singleton Zemelapis = Singleton.GetInstance();
            Zemelapis = Singleton.GetInstance();

            Assert.IsFalse(Zemelapis.Counter == 2);
        }

        [Test]
        [TestCase(4,-3)]
        [TestCase(5,-2)]
        [TestCase(6,-1)]
        [TestCase(7,-4)]
        [TestCase(8,8)]
        public void Singleton_EditTile_WithParameter_True(int TileId,int Expected)
        {
            Singleton Zemelapis = Singleton.GetInstance();
            Zemelapis.EditTile(0, 0, TileId);

            Assert.That(Zemelapis.GetMap().objects[0,0] == Expected);
        }

        [Test]
        public void Singleton_EditTile_WithourParameter_True()
        {
            Singleton Zemelapis = Singleton.GetInstance();
            Zemelapis.EditTile(0, 0);

            Assert.That(Zemelapis.GetMap().objects[0, 0] == 0);
        }

        [Test]
        public void Singleton_MapToString_True()
        {
            Singleton Zemelapis = Singleton.GetInstance();
            Assert.That(Zemelapis.GetMap().MapToString().Length > 0);
        }


        [Test]
        public void Singleton_RandomNumber_True()
        {
            Singleton Zemelapis = Singleton.GetInstance();
            int Number = Zemelapis.GetMap().RandomNumber(0, 10);
            Assert.That(Number >= 0 && Number < 10);
        }

        [Test]
        public void Singleton_UpdateMap_True()
        {
            Singleton Zemelapis = Singleton.GetInstance();
            Map newZemelapis = new Map();

            Zemelapis.UpdateMap(newZemelapis);

            Assert.That(Zemelapis.GetMap().map_name == newZemelapis.map_name);
        }
    }
}
