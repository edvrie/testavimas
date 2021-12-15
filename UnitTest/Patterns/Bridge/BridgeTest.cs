using NUnit.Framework;
using ObjektinisProgramuProjektavimas.Patterns.Bridge;
using ObjektinisProgramuProjektavimas.Patterns.Strategy;

namespace BridgeTest
{

    [TestFixture]
    public class BridgeTest
    {
        int MageDamage = 20;
        int FighterDamage = 15;
        int TankDamage = 10;

        int MageArmor = 10;
        int FighterArmor = 20;
        int TankArmor = 40;

        int MageHealth = 50;
        int FighterHealth = 70;
        int TankHealth = 100;

        int MageSpeed = 10;
        int FighterSpeed = 20;
        int TankSpeed = 10;

        [Test]
        public void Robot_Mage_SetStats_True()
        {
            Robot robo = new Robot("Id-1", 0, 0, 1);
            RobotAbsc robot1 = robo;
            RobotClasses cllass = new Mage();

            cllass.Robot = robot1;
            cllass.SetStats();

            Assert.That(robo.Damage == MageDamage && robo.Armor == MageArmor && robo.Health == MageHealth && robo.Speed == MageSpeed);
        }

        [Test]
        public void Robot_ReturnRobot_True()
        {
            Robot robo = new Robot("Id-1", 0, 0, 1);
            RobotAbsc robot1 = robo;
            RobotClasses cllass = new Mage();

            cllass.Robot = robot1;
            cllass.Robot.SetDamage(20);
            Assert.That(robo.Damage == 20);
        }

        [Test]
        public void Robot_Tank_SetStats_True()
        {
            Robot robo = new Robot("Id-1", 0, 0, 1);
            RobotAbsc robot1 = robo;
            RobotClasses cllass = new Tank();

            cllass.Robot = robot1;
            cllass.SetStats();

            Assert.That(robo.Damage == TankDamage && robo.Armor == TankArmor && robo.Health == TankHealth && robo.Speed == TankSpeed);
        }


        [Test]
        public void Robot_Fighter_SetStats_True()
        {
            Robot robo = new Robot("Id-1", 0, 0, 1);
            RobotAbsc robot1 = robo;
            RobotClasses cllass = new Fighter();

            cllass.Robot = robot1;
            cllass.SetStats();

            Assert.That(robo.Damage == FighterDamage && robo.Armor == FighterArmor && robo.Health == FighterHealth && robo.Speed == FighterSpeed);
        }

        [Test]
        public void Human_Mage_SetStats_True()
        {
            Human robo = new Human("Id-1", 0, 0, 1);
            RobotAbsc robot1 = robo;
            RobotClasses cllass = new Mage();

            cllass.Robot = robot1;
            cllass.SetStats();

            Assert.That(robo.Damage == MageDamage && robo.Armor == MageArmor && robo.Health == MageHealth && robo.Speed == MageSpeed);
        }


        [Test]
        public void Human_Tank_SetStats_True()
        {
            Human robo = new Human("Id-1", 0, 0, 1);
            RobotAbsc robot1 = robo;
            RobotClasses cllass = new Tank();

            cllass.Robot = robot1;
            cllass.SetStats();

            Assert.That(robo.Damage == TankDamage && robo.Armor == TankArmor && robo.Health == TankHealth && robo.Speed == TankSpeed);
        }


        [Test]
        public void Human_Fighter_SetStats_True()
        {
            Human robo = new Human("Id-1", 0, 0, 1);
            RobotAbsc robot1 = robo;
            RobotClasses cllass = new Fighter();

            cllass.Robot = robot1;
            cllass.SetStats();

            Assert.That(robo.Damage == FighterDamage && robo.Armor == FighterArmor && robo.Health == FighterHealth && robo.Speed == FighterSpeed);
        }
    }
}
