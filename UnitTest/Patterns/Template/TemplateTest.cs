using NUnit.Framework;
using ObjektinisProgramuProjektavimas.Patterns.Factories;
using ObjektinisProgramuProjektavimas.Patterns.Singleton;
using ObjektinisProgramuProjektavimas.Patterns.Strategy;
using ObjektinisProgramuProjektavimas.Patterns.Template;
using System;
using System.Collections.Generic;

namespace TemplateTest
{

    [TestFixture]
    public class TemplateTest
    {
        [Test]
        public void TemplateTest_GenerateItem_True()
        {
            Singleton Map = Singleton.GetInstance();
            string Old = Map.GetMap().MapToString();
            List<Robot> robotai = new List<Robot>();

            int MapLength = Map.GetMap().size;

            robotai.Add(new Robot(null, 0, 0, 0));
            robotai.Add(new Robot(null, MapLength - 1, MapLength - 1, 0));

            GenerateObject objekctas = new GenerateItem();
            objekctas.finalObject(Map, robotai);

            Assert.That(Map.GetMap().MapToString() != Old);
        }

        [Test]
        public void TemplateTest_GenerateStructure_True()
        {
            Singleton Map = Singleton.GetInstance();
            string Old = Map.GetMap().MapToString();
            List<Robot> robotai = new List<Robot>();

            int MapLength = Map.GetMap().size;

            robotai.Add(new Robot(null, 0, 0, 0));
            robotai.Add(new Robot(null, MapLength - 1, MapLength - 1, 0));

            GenerateObject objekctas = new GenerateStructure();
            objekctas.finalObject(Map, robotai);

            Assert.That(Map.GetMap().MapToString() != Old);
        }

        [Test]
        public void TemplateTest_Structure_GenerateItem_True()
        {
            Singleton Map = Singleton.GetInstance();
            List<Robot> robotai = new List<Robot>();

            int MapLength = Map.GetMap().size;

            robotai.Add(new Robot(null, 0, 0, 0));
            robotai.Add(new Robot(null, MapLength - 1, MapLength - 1, 0));

            GenerateObject objekctas = new GenerateStructure();

            int itemId = objekctas.generateItem();
            Assert.That(itemId >= 1 && itemId < 4);
        }

        [Test]
        public void TemplateTest_Item_GenerateItem_True()
        {
            Singleton Map = Singleton.GetInstance();
            List<Robot> robotai = new List<Robot>();

            int MapLength = Map.GetMap().size;

            robotai.Add(new Robot(null, 0, 0, 0));
            robotai.Add(new Robot(null, MapLength - 1, MapLength - 1, 0));

            GenerateObject objekctas = new GenerateItem();

            int itemId = objekctas.generateItem();
            Assert.That(itemId >= 4 && itemId < 8);
        }

        [Test]
        public void TemplateTest_Structure_GenerateLocation_True()
        {
            Singleton Map = Singleton.GetInstance();
            List<Robot> robotai = new List<Robot>();

            int MapLength = Map.GetMap().size;

            robotai.Add(new Robot(null, 0, 0, 0));
            robotai.Add(new Robot(null, MapLength - 1, MapLength - 1, 0));

            GenerateObject objekctas = new GenerateStructure();

            Coordinates coords = objekctas.genereateLocation(Map, robotai);
            Assert.That(coords.X != -1 || coords.Y != -1);
        }

        [Test]
        public void TemplateTest_Structure_GenerateLocation_False()
        {
            Singleton Map = Singleton.GetInstance();
            List<Robot> robotai = new List<Robot>();

            Map.GetMap().size = 0;
            Map.GetMap().cellList = new List<Cell>();

            GenerateObject objekctas = new GenerateStructure();

            Coordinates coords = objekctas.genereateLocation(Map, robotai);
            Assert.IsFalse(coords.X != -1 || coords.Y != -1);

            Map.UpdateMap(new Map());
        }

        [Test]
        public void TemplateTest_Item_GenerateLocation_True()
        {
            Singleton Map = Singleton.GetInstance();
            List<Robot> robotai = new List<Robot>();

            int MapLength = Map.GetMap().size;

            robotai.Add(new Robot(null, 0, 0, 0));
            robotai.Add(new Robot(null, MapLength - 1, MapLength - 1, 0));

            GenerateObject objekctas = new GenerateItem();

            Coordinates coords = objekctas.genereateLocation(Map, robotai);
            Assert.That(coords.X != -1 || coords.Y != -1);
        }

        [Test]
        public void TemplateTest_Item_GenerateLocation_False()
        {
            Singleton Map = Singleton.GetInstance();
            List<Robot> robotai = new List<Robot>();

            Map.GetMap().size = 0;
            Map.GetMap().cellList = new List<Cell>();

            GenerateObject objekctas = new GenerateItem();

            Coordinates coords = objekctas.genereateLocation(Map, robotai);
            Assert.IsFalse(coords.X != -1 || coords.Y != -1);

            Map.UpdateMap(new Map());
        }
    }
}
