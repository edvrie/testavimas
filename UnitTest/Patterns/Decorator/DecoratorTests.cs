using NUnit.Framework;
using ObjektinisProgramuProjektavimas.Patterns.Decorator;
using ObjektinisProgramuProjektavimas.Patterns.Strategy;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    [TestFixture()]
    public class DecoratorTests
    {
        Mock<Robot> initRobot;
        IRobot robot;
        [SetUp]
        public void TestInit()
        {
            initRobot = new Mock<Robot>("Test", 1, 1, 1);
            robot = initRobot.Object;
        }
        [Test()]
        public void ApplyArmorTest()
        {
            RobotDecorator rob = new ArmorUpgrade(initRobot.Object);
            Assert.NotNull(rob.Wrapee);
            rob.ApplyArmor();
            Assert.That(initRobot.Object.Armor == 1);
            robot.ApplyArmor();
            Assert.That(initRobot.Object.Armor == 2);
        }

        [Test()]
        public void ApplyDamageTest()
        {
            RobotDecorator rob = new DamageUpgrade(initRobot.Object);
            Assert.NotNull(rob.Wrapee);
            rob.ApplyDamage();
            Assert.That(initRobot.Object.Damage == 1);
            robot.ApplyDamage();
            Assert.That(initRobot.Object.Damage == 2);
        }

        [Test()]
        public void ApplyHealthTest()
        {
            RobotDecorator rob = new HealthUpgrade(initRobot.Object);
            Assert.NotNull(rob.Wrapee);
            rob.ApplyHealth();
            Assert.That(initRobot.Object.Health == 20);
            robot.ApplyHealth();
            Assert.That(initRobot.Object.Health == 40);
        }

        [Test()]
        public void ApplySpeedTest()
        {
            RobotDecorator rob = new SpeedUpgrade(initRobot.Object);
            Assert.NotNull(rob.Wrapee);
            rob.ApplySpeed();
            Assert.That(initRobot.Object.Speed == 1);
            robot.ApplySpeed();
            Assert.That(initRobot.Object.Speed == 2);
        }

        [Test]
        public void RobotDecoratorInitTest()
        {
            RobotDecorator tester = new SpeedUpgrade(initRobot.Object);
            RobotDecorator tester2 = new ArmorUpgrade(initRobot.Object);
            RobotDecorator tester3 = new HealthUpgrade(initRobot.Object);
            RobotDecorator tester4 = new DamageUpgrade(initRobot.Object);
            Assert.DoesNotThrow(() => tester.ApplyArmor());
            Assert.DoesNotThrow(() => tester.ApplyDamage());
            Assert.DoesNotThrow(() => tester.ApplyHealth());
            Assert.DoesNotThrow(() => tester.ApplySpeed());
            Assert.DoesNotThrow(() => tester2.ApplyArmor());
            Assert.DoesNotThrow(() => tester2.ApplyDamage());
            Assert.DoesNotThrow(() => tester2.ApplyHealth());
            Assert.DoesNotThrow(() => tester2.ApplySpeed());
            Assert.DoesNotThrow(() => tester3.ApplyArmor());
            Assert.DoesNotThrow(() => tester3.ApplyDamage());
            Assert.DoesNotThrow(() => tester3.ApplyHealth());
            Assert.DoesNotThrow(() => tester3.ApplySpeed());
            Assert.DoesNotThrow(() => tester4.ApplyArmor());
            Assert.DoesNotThrow(() => tester4.ApplyDamage());
            Assert.DoesNotThrow(() => tester4.ApplyHealth());
            Assert.DoesNotThrow(() => tester4.ApplySpeed());
        }
    }
}