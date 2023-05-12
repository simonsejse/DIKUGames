using Breakout.Commands.GameRunning;
using Breakout.Entities;
using DIKUArcade.GUI;
using NUnit.Framework;

namespace BreakoutTests.Commands.GameRunning
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
            // Arrange
            PlayerEntity playerEntity = PlayerEntity.Create();
            var shouldMove = true;
            var command = new MovePlayerLeftCommand(playerEntity, shouldMove);

            // Act
            command.Execute();

            // Assert
            Assert.AreEqual(shouldMove, playerEntity.GetMoveLeft());
        }

        [Test]
        public void MoveLeftFalseTest()
        {
            // Arrange
            PlayerEntity playerEntity = PlayerEntity.Create();
            var shouldMove = false;
            var command = new MovePlayerLeftCommand(playerEntity, shouldMove);

            // Act
            command.Execute();

            // Assert
            Assert.AreEqual(shouldMove, playerEntity.GetMoveLeft());
        }
        
        [Test]
        public void MoveRightTrueTest()
        {
            // Arrange
            PlayerEntity playerEntity = PlayerEntity.Create();
            var shouldMove = true;
            var command = new MovePlayerLeftCommand(playerEntity, shouldMove);

            // Act
            command.Execute();

            // Assert
            Assert.AreEqual(shouldMove, playerEntity.GetMoveLeft());
        }

        [Test]
        public void MoveRightFalseTest()
        {
            // Arrange
            PlayerEntity playerEntity = PlayerEntity.Create();
            var shouldMove = false;
            var command = new MovePlayerRightCommand(playerEntity, shouldMove);

            // Act
            command.Execute();

            // Assert
            Assert.AreEqual(shouldMove, playerEntity.GetMoveRight());
        }
    }
}