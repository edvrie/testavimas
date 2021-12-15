using NUnit.Framework;
using ObjektinisProgramuProjektavimas.Patterns.Adapter;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Adapter
{
    [TestFixture()]
    public class AdapterTests
    {
        public Stopwatch _control;
        public GameTimer timer;
        public TimerAdapter timeAdapter;
        [SetUp]
        public void TestInit()
        {
            _control = new Stopwatch();
            timer = new GameTimer();
            timeAdapter = new TimerAdapter(timer);
        }
        [Test()]
        public void StartTimerTest()
        {
            _control.Start();
            timer.StartTimer();

            Assert.LessOrEqual(_control.ElapsedMilliseconds, timer.GlobalTimer.ElapsedMilliseconds);
        }

        [Test()]
        public void GetTimePlayer1Test()
        {
            timer.StartTimer();
            Thread.Sleep(1000);
            Assert.That(timer.GlobalTimer.ElapsedMilliseconds >= 1000);
            var tmp = timer.GetTimePlayer1();
            Assert.IsInstanceOf<long>(tmp);
        }

        [Test()]
        public void GetTimePlayer2Test()
        {
            timer.StartTimer();
            Thread.Sleep(1000);
            Assert.That(timer.GlobalTimer.ElapsedMilliseconds >= 1000);
            var tmp = timer.GetTimePlayer2();
            Assert.IsInstanceOf<long>(tmp);
        }

        [Test()]
        public void Player1TimeResetTest()
        {
            Assert.DoesNotThrow(timer.Player1TimeReset);
        }

        [Test()]
        public void Player2TimeResetTest()
        {
            Assert.DoesNotThrow(timer.Player2TimeReset);
        }

        [Test()]
        public void StartTimerTest1()
        {
            Assert.DoesNotThrow(() => timeAdapter.StartTimer());
            Assert.That(timer.GlobalTimer.ElapsedMilliseconds >= 0);
        }

        [Test()]
        public void ResetPlayerTimerTest()
        {
            Assert.DoesNotThrow(() => timeAdapter.ResetPlayerTimer(1));
            Assert.DoesNotThrow(() => timeAdapter.ResetPlayerTimer(2));
        }

        [Test()]
        public void GetPlayerTimeTest()
        {
            Assert.DoesNotThrow(() => timeAdapter.GetPlayerTime(1));
            Assert.DoesNotThrow(() => timeAdapter.GetPlayerTime(2));
        }
    }
}