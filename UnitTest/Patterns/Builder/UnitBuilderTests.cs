using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ObjektinisProgramuProjektavimas.Patterns.Builders;
using ObjektinisProgramuProjektavimas.Patterns.Factories;

namespace BuilderTest
{
    [TestFixture]
    class UnitBuilderTests
    {
        private TerrainBuilder terrainBuilder;
        private ItemBuilder itemBuilder;
        private Director director;

        [SetUp]
        public void TestInit()
        {
            terrainBuilder = new TerrainBuilder();
            itemBuilder = new ItemBuilder();
            director = new Director();
        }


        [Test]
        public void Construct_ConstructingMap_ReturnsMap()
        {
            int size = 4;
            int[,] mapArray = new int[,] { { 0, 1, 2, 3 }, { -1, -2, -3, -4 }, { -1, -2, -3, -4 }, { 0, 1, 2, 3 } };

            List<Cell> expected = new List<Cell>();
            expected.Add(new Grass(0, 0));
            expected.Add(new Wall(1, 0));
            expected.Add(new Water(2, 0));
            expected.Add(new Box(2, 0));
            expected.Add(new Armor(5, 0, 2));
            expected.Add(new Damage(5, 1, 2));
            expected.Add(new Health(5, 2, 2));
            expected.Add(new Speed(5, 3, 2));


            director.Construct(terrainBuilder, itemBuilder, mapArray, size);

            List<Cell> actual = director.GetResults();

            Assert.IsNotEmpty(actual);
            Assert.AreEqual(expected[0].GetType(), actual[0].GetType());
            Assert.AreEqual(expected[1].GetType(), actual[1].GetType());
            Assert.AreEqual(expected[2].GetType(), actual[2].GetType());
            Assert.AreEqual(expected[3].GetType(), actual[3].GetType());
            Assert.AreEqual(expected[4].GetType(), actual[4].GetType());
            Assert.AreEqual(expected[5].GetType(), actual[5].GetType());
            Assert.AreEqual(expected[6].GetType(), actual[6].GetType());
            Assert.AreEqual(expected[7].GetType(), actual[7].GetType());
        }

        [TestCase(-4)]
        [TestCase(-3)]
        [TestCase(-2)]
        [TestCase(-1)]
        [TestCase(-50)]
        public void ItemBuilderBuildObject_BuildingObject_ReturnsCell(int cellType)
        {
            Cell expected;
            int x = 0;
            int y = 2;

            switch (cellType)
            {
                case -1:
                    expected = new Armor(5, x, y);
                    break;
                case -2:
                    expected = new Damage(5, x, y);
                    break;
                case -3:
                    expected = new Health(5, x, y);
                    break;
                case -4:
                    expected = new Speed(5, x, y);
                    break;
                default:
                    expected = null;
                    break;
            }

            var actual = itemBuilder.BuildObject(cellType, x, y);

            if (expected != null)
                Assert.AreEqual(expected.GetType(), actual.GetType());
            else
                Assert.IsNull(actual);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(-50)]
        public void TerrainBuilderBuildObject_BuildingObject_ReturnsCell(int cellType)
        {
            Cell expected;
            int x = 0;
            int y = 2;

            switch (cellType)
            {
                case 0:
                    expected = new Grass(x, y);
                    break;
                case 1:
                    expected = new Wall(x, y);
                    break;
                case 2:
                    expected = new Water(x, y);
                    break;
                case 3:
                    expected = new Box(x, y);
                    break;
                default:
                    expected = null;
                    break;
            }

            var actual = terrainBuilder.BuildObject(cellType, x, y);

            if (expected != null)
                Assert.AreEqual(expected.GetType(), actual.GetType());
            else
                Assert.IsNull(actual);
        }
    }
}
