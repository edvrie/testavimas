using NUnit.Framework;
using ObjektinisProgramuProjektavimas.Patterns.Command;
using ObjektinisProgramuProjektavimas.Patterns.Observer;
using ObjektinisProgramuProjektavimas.Patterns.Strategy;
using SignalRChat.Hubs;

namespace UnitTest.JonioTestai
{
    [TestFixture]
    public class CommandTesting
    {
        static Robot robot = new Robot("string", 1, 1, 1);
        RobotMoveController controller = new RobotMoveController(robot);
        gameHub hub = new gameHub();
        Server server = new Server();

        [Test]
        public void RobotMoveController_PerformingCommand_AddsCommandToListAndPerformsCommand()
        {
            robot.setServer(server, hub);
            MoveUp command = new MoveUp();
            int initalListSize = controller.GetListCount();
            controller.Run(hub, command);
            int resultListSize = controller.GetListCount();
            Assert.IsTrue(initalListSize < resultListSize);
        }

        [Test]
        public void RobotMoveController_UndoingCommand_RemovesCommandFromListAndPerformsUndoCommand()
        {
            int initalListSize = controller.GetListCount();
            controller.Undo(hub);
            int resultListSize = controller.GetListCount();
            Assert.IsTrue(initalListSize > resultListSize);
        }
    }
}
