using NUnit.Framework;
using ObjektinisProgramuProjektavimas.Patterns.Observer;
using ObjektinisProgramuProjektavimas.Patterns.Strategy;
using SignalRChat.Hubs;
using System;

namespace UnitTest.JonioTestai
{
    [TestFixture]
    public class StrategyTesting
    {
        Robot robot = new Robot("string", 1, 1, 1);
        gameHub hub = new gameHub();

        [Test]
        public void Ability1_ExecutingPerform_ReturnsString()
        {
            Ability1 ability = new Ability1();
            string expected = "AbilityOneUsed";
            Assert.That(expected == ability.Perform());
        }

        [Test]
        public void Ability2_ExecutingPerform_ReturnsString()
        {
            Ability2 ability = new Ability2();
            string expected = "AbilityTwoUsed";
            Assert.That(expected == ability.Perform());
        }

        [Test]
        public void Ability3_ExecutingPerform_ReturnsString()
        {
            Ability3 ability = new Ability3();
            string expected = "AbilityThreeUsed";
            Assert.That(expected == ability.Perform());
        }

        [Test]
        public void Ability4_ExecutingPerform_ReturnsString()
        {
            Ability4 ability = new Ability4();
            string expected = "AbilityFourUsed";
            Assert.That(expected == ability.Perform());
        }

        [Test]
        public void Ability5_ExecutingPerform_ReturnsString()
        {
            Ability5 ability = new Ability5();
            string expected = "AbilityFiveUsed";
            Assert.That(expected == ability.Perform());
        }

        [Test]
        public void MoveDown_ExecutingPerform_SetsStateReturnsString()
        {
            string expectedState = "MoveDown";
            string expectedReturn = "MoveDown";
            MoveDown move = new MoveDown();
            
            string resultReturn = move.Perform();
            string resultState = move.state;

            Assert.That(expectedState == resultState && resultReturn == expectedReturn);
        }

        [Test]
        public void MoveLeft_ExecutingPerform_SetsStateReturnsString()
        {
            string expectedState = "MoveLeft";
            string expectedReturn = "MoveLeft";
            MoveLeft move = new MoveLeft();

            string resultReturn = move.Perform();
            string resultState = move.state;

            Assert.That(expectedState == resultState && resultReturn == expectedReturn);
        }

        [Test]
        public void MoveRight_ExecutingPerform_SetsStateReturnsString()
        {
            string expectedState = "MoveRight";
            string expectedReturn = "MoveRight";
            MoveRight move = new MoveRight();

            string resultReturn = move.Perform();
            string resultState = move.state;

            Assert.That(expectedState == resultState && resultReturn == expectedReturn);
        }

        [Test]
        public void MoveUp_ExecutingPerform_SetsStateReturnsString()
        {
            string expectedState = "MoveUp";
            string expectedReturn = "MoveUp";
            MoveUp move = new MoveUp();

            string resultReturn = move.Perform();
            string resultState = move.state;

            Assert.That(expectedState == resultState && resultReturn == expectedReturn);
        }

        [Test]
        public void MoveDown_ExecutingUndo_ReturnsClass()
        {
            MoveDown move = new MoveDown();
            Move undo = move.Undo();
            MoveUp expectedundo = new MoveUp();
            Assert.IsTrue(undo.GetType() == expectedundo.GetType());
        }

        [Test]
        public void MoveLeft_ExecutingUndo_ReturnsClass()
        {
            MoveLeft move = new MoveLeft();
            Move undo = move.Undo();
            MoveRight expectedundo = new MoveRight();
            Assert.IsTrue(undo.GetType() == expectedundo.GetType());
        }

        [Test]
        public void MoveRight_ExecutingUndo_ReturnsClass()
        {
            MoveRight move = new MoveRight();
            Move undo = move.Undo();
            MoveLeft expectedundo = new MoveLeft();
            Assert.IsTrue(undo.GetType() == expectedundo.GetType());
        }

        [Test]
        public void MoveUp_ExecutingUndo_ReturnsClass()
        {
            MoveUp move = new MoveUp();
            Move undo = move.Undo();
            MoveDown expectedundo = new MoveDown();
            Assert.IsTrue(undo.GetType() == expectedundo.GetType());
        }

        [Test]
        public void Shoot_ExecutingPerform_ReturnsString()
        {
            string expectedString = "Shoot";
            Shoot shoot = new Shoot();
            string resultString = shoot.Perform();
            Assert.IsTrue(expectedString == resultString);
        }

        [Test]
        public void SetServer_ExecutingSetServer_SetsServer()
        { 
            Subject server = new Server();
            robot.setServer(server, hub);
            Subject resultServer = robot.server;
            Assert.IsTrue(resultServer != null);
        }

        [Test]
        public void ApplyDamage_ExecutingApplyDamage_IncreasesDamage()
        {
            int before = robot.Damage;
            robot.ApplyDamage();
            int after = robot.Damage;
            Assert.IsTrue(before < after);
        }

        [Test]
        public void ApplyArmor_ExecutingApplyArmor_IncreasesArmor()
        {
            int before = robot.Armor;
            robot.ApplyArmor();
            int after = robot.Armor;
            Assert.IsTrue(before < after);
        }

        [Test]
        public void ApplyHealth_ExecutingApplyHealth_IncreasesHealth()
        {
            int before = robot.Health;
            robot.ApplyHealth();
            int after = robot.Health;
            Assert.IsTrue(before < after);
        }

        [Test]
        public void ApplySpeed_ExecutingApplySpeed_IncreasesSpeed()
        {
            int before = robot.Speed;
            robot.ApplySpeed();
            int after = robot.Speed;
            Assert.IsTrue(before < after);
        }

        [Test]
        public void SetHealth_ExecutingSetHealth_SetsRobotAttribute()
        {
            int amount = 30;
            robot.SetHealth(amount);
            Assert.AreEqual(amount, robot.Health);
        }

        [Test]
        public void SetArmor_ExecutingSetArmor_SetsRobotAttribute()
        {
            int amount = 30;
            robot.SetArmor(amount);
            Assert.AreEqual(amount, robot.Armor);
        }

        [Test]
        public void SetDamage_ExecutingSetDamage_SetsRobotAttribute()
        {
            int amount = 30;
            robot.SetDamage(amount);
            Assert.AreEqual(amount, robot.Damage);
        }

        [Test]
        public void SetSpeed_ExecutingSetSpeed_SetsRobotAttribute()
        {
            int amount = 30;
            robot.SetSpeed(amount);
            Assert.AreEqual(amount, robot.Speed);
        }

        [Test]
        public void HealthIncrease_ExecutingHealthIncrease_IncreasesHealthByAmount()
        {
            int before = robot.Health;
            int amount = 30;
            robot.HealthIncrease(amount);
            Assert.AreEqual(before + amount, robot.Health);
        }

        [Test]
        public void DamageIncrease_ExecutingHealthIncrease_IncreasesDamageByAmount()
        {
            int before = robot.Damage;
            int amount = 30;
            robot.DamageIncrease(amount);
            Assert.AreEqual(before + amount, robot.Damage);
        }

        [Test]
        public void ArmorIncrease_ExecutingHealthIncrease_IncreasesArmorByAmount()
        {
            int before = robot.Armor;
            int amount = 30;
            robot.ArmorIncrease(amount);
            Assert.AreEqual(before + amount, robot.Armor);
        }

        [Test]
        public void SpeedIncrease_ExecutingHealthIncrease_IncreasesSpeedByAmount()
        {
            int before = robot.Speed;
            int amount = 30;
            robot.SpeedIncrease(amount);
            Assert.AreEqual(before + amount, robot.Speed);
        }

        [Test]
        public void UseAbility_ExecutingPerform_ReturnNotImplemeted()
        {
            UseAbility useAbility = new UseAbility();
            Assert.Throws<NotImplementedException>(() => useAbility.Perform());
        }
    }
}
