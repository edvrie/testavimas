using NUnit.Framework;
using System;
using ObjektinisProgramuProjektavimas.Patterns.Factories;
using Microsoft.VisualBasic;

namespace FactoriesTests
{
    [TestFixture]
    class UnitFactoriesTests
    {
        [TestCase(-4)]
        [TestCase(-3)]
        [TestCase(-2)]
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void FactoryMethod_CreatingCell_ReturnsCell(int cellType)
        {
            //ARRANGE
            int x = 5;
            int y = 6;
            CellCreator cellCreator = new CellCreator();
            Cell expected = null;

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
            }


            // ACT
            var actual = cellCreator.FactoryMethod(cellType, x, y);

            //ASSERT
            if (expected != null)
                Assert.AreEqual(expected.GetType(), actual.GetType());
        }

        [TestCase(-15)]
        [TestCase(100)]
        public void FactoryMethod_CreatingCell_ReturnsNull(int cellType)
        {
            //ARRANGE
            int x = 5;
            int y = 6;
            CellCreator cellCreator = new CellCreator();

            // ACT
            var actual = cellCreator.FactoryMethod(cellType, x, y);

            //ASSERT
            Assert.IsNull(actual);
        }

        [Test]
        public void GetAbstractFactory_CreatingItem_ReturnsItemFactoryObject()
        {
            //ARRANGE
            var expected = new ItemFactory();
            ItemCell itemCell = new ItemCell();

            // ACT
            var actual = itemCell.GetAbstractFactory();

            //ASSERT
            Assert.AreEqual(expected.GetType(), actual.GetType());

        }

        [Test]
        public void GetAbstractFactory_CreatingTerrain_ReturnsTerrainFactoryObject()
        {
            //ARRANGE
            var expected = new TerrainFactory();
            TerrainCell itemCell = new TerrainCell();

            // ACT
            var actual = itemCell.GetAbstractFactory();

            //ASSERT
            Assert.AreEqual(expected.GetType(), actual.GetType());

        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void CreateTerrainFactory_CreatingTerrain_ReturnsTerrainCell(int cellType)
        {
            //ARRANGE
            Terrain expected = null;
            TerrainFactory factory = new TerrainFactory();
            int x = 5;
            int y = 5;

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
            }

            //ACT
            var actual = factory.CreateTerrain(cellType, x, y);

            //ASSERT
            if (expected != null)
                Assert.AreEqual(expected.GetType(), actual.GetType());
        }

        [Test]
        public void CreateTerrainFactory_CreatingTerrain_ReturnsNull()
        {
            TerrainFactory factory = new TerrainFactory();

            var actual = factory.CreateTerrain(-10, 5, 5);

            Assert.IsNull(actual);
        }

        [Test]
        public void CreateTerrainFactory_CreatingItem_ReturnsNull()
        {
            //ARRANGE
            TerrainFactory factory = new TerrainFactory();

            //ACT
            var actual = factory.CreateItem(5, 8, 8, 8);

            //ASSERT
            Assert.IsNull(actual);
        }

        [TestCase(-1)]
        [TestCase(-2)]
        [TestCase(-3)]
        [TestCase(-4)]
        public void CreateItemFactory_CreatingItem_ReturnsItemCell(int cellType)
        {
            Item expected = null;
            ItemFactory factory = new ItemFactory();
            int boost = 5;
            int x = 5;
            int y = 5;

            switch (cellType)
            {
                case -1:
                    expected = new Armor(boost, x, y);
                    break;
                case -2:
                    expected = new Damage(boost, x, y);
                    break;
                case -3:
                    expected = new Health(boost, x, y);
                    break;
                case -4:
                    expected = new Speed(boost, x, y);
                    break;
            }

            //ACT
            var actual = factory.CreateItem(cellType, 8, x, y);

            //ASSERT
            if (expected != null)
                Assert.AreEqual(expected.GetType(), actual.GetType());
        }

        [Test]
        public void CreateItemFactory_CreatingItem_ReturnsNull()
        {
            ItemFactory factory = new ItemFactory();

            var actual = factory.CreateItem(10, 8, 5, 5);

            Assert.IsNull(actual);
        }

        [Test]
        public void CreateItemFactory_CreatingTerrain_ReturnsNull()
        {
            ItemFactory factory = new ItemFactory();

            var actual = factory.CreateTerrain(5, 5, 5);

            Assert.IsNull(actual);
        }

        [Test]
        public void GetArmorIncrease_GettingArmorIncrease_ReturnsIncrease()
        {
            var expected = 8;
            Armor armor = new Armor(expected, 5, 5);

            var actual = armor.GetArmorIncrease();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetDamageIncrease_GettingDamageIncrease_ReturnsIncreatse()
        {
            var expected = 8;
            Damage damage = new Damage(expected, 5, 5);

            var actual = damage.GetDamageIncrease();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetHealthIncrease_GettingHealthIncrease_ReturnsIncreatse()
        {
            var expected = 8;
            Health health = new Health(expected, 5, 5);

            var actual = health.GetHealthIncrease();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetSpeedIncrease_GettingSpeedIncrease_ReturnsIncreatse()
        {
            var expected = 8;
            Speed speed = new Speed(expected, 5, 5);

            var actual = speed.GetSpeedIncrease();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void BoxDestroy_DestroyingBox_ChangesParrameters()
        {
            var expected_destroyed_status = true;
            var expected_textureID = 5;

            Box actual = new Box(5, 5);
            actual.Destroy();

            Assert.AreEqual(expected_destroyed_status, actual.IsDestroyed);
            Assert.AreEqual(expected_textureID, actual.TextureID);
        }

        [Test]
        public void BoxAddItem_AddItem_ChangesParrameters()
        {
            var expected_hasItem = true;

            Box actual = new Box(5, 5);
            actual.AddItem();

            Assert.AreEqual(expected_hasItem, actual.HasItem);
        }

        [Test]
        public void GrassAddItem_AddItem_ChangesParrameters()
        {
            var expected_hasItem = true;

            Grass actual = new Grass(5, 5);
            actual.AddItem();

            Assert.AreEqual(expected_hasItem, actual.HasItem);
        }

        [Test]
        public void WaterGetSlowAmmount_GetSlowAmmount_ReturnsSlowAmmount()
        {
            var expected_slow = 2;

            Water water = new Water(5, 5);
            var actual = water.GetSlowAmmount();

            Assert.AreEqual(expected_slow, actual);
        }
    }
}
