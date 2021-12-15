using NUnit.Framework;
using System.Collections.Generic;
using ObjektinisProgramuProjektavimas.Patterns.Prototype;
using ObjektinisProgramuProjektavimas.Patterns.Factories;

namespace PrototypeTest
{
    class UnitPrototypeTests
    {
        [Test]
        public void PrototypeClone_CloningCellObject_ReturnsClonedVersion()
        {
            PrototypeManager manager = new PrototypeManager();
            var expected = new Grass(-1, -1);

            var actual = (Grass)manager.cellPrototypes["Grass"].Clone();

            Assert.AreEqual(expected.GetType(), actual.GetType());
            Assert.AreEqual(expected.PositionX, actual.PositionX);
            Assert.AreEqual(expected.PositionY, actual.PositionY);
            Assert.AreEqual(expected.TextureID, actual.TextureID);
        }
    }
}
