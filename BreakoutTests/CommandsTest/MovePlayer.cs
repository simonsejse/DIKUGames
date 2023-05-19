using Breakout.Commands.GameRunning;
using Breakout.Entities;
using DIKUArcade.GUI;

namespace BreakoutTests.CommandsTest
{
    [TestFixture]
    public class MovePlayerLeftCommandTests
    {
        [SetUp]
        public void Setup()
        {
            Window.CreateOpenGLContext();
        }
        [Test]
        public void MoveLeftTrueTest()
        {
            PlayerEntity playerEntity = PlayerEntity.Create();
            var shouldMove = true;
            var command = new MovePlayerLeftCommand(playerEntity, shouldMove);
            
            command.Execute();
            
            Assert.AreEqual(shouldMove, playerEntity.GetMoveLeft());
        }

        [Test]
        public void MoveLeftFalseTest()
        {
            PlayerEntity playerEntity = PlayerEntity.Create();
            var shouldMove = false;
            var command = new MovePlayerLeftCommand(playerEntity, shouldMove);
            
            command.Execute();
            
            Assert.AreEqual(shouldMove, playerEntity.GetMoveLeft());
        }
        
        [Test]
        public void MoveRightTrueTest()
        {
            PlayerEntity playerEntity = PlayerEntity.Create();
            var shouldMove = true;
            var command = new MovePlayerLeftCommand(playerEntity, shouldMove);
            
            command.Execute();
            
            Assert.AreEqual(shouldMove, playerEntity.GetMoveLeft());
        }

        [Test]
        public void MoveRightFalseTest()
        {
            PlayerEntity playerEntity = PlayerEntity.Create();
            var shouldMove = false;
            var command = new MovePlayerRightCommand(playerEntity, shouldMove);
            
            command.Execute();
            
            Assert.AreEqual(shouldMove, playerEntity.GetMoveRight());
        }
    }
}