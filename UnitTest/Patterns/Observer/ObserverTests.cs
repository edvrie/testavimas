using NUnit.Framework;
using ObjektinisProgramuProjektavimas.Patterns.Observer;
using ObjektinisProgramuProjektavimas.Patterns.Strategy;
using SignalRChat.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    [TestFixture()]
    public class ObserverTests
    {
        IObserver unit = new Robot("test", 1, 1, 1);
        Subject subject = new Subject();
        gameHub hub = new gameHub();

        [Test()]
        public void AttachTest()
        {
            subject.Attach(unit, hub);
            Assert.That(subject.robotList.Count == 1);
        }

        [Test()]
        public void DetachTest()
        {
            subject.Detach(unit);
            Assert.That(subject.robotList.Count == 0);
        }

        [Test()]
        public void ReceiveFromClientTest()
        {
            Assert.DoesNotThrow(() => subject.ReceiveFromClient("test", hub));
        }
    }
}