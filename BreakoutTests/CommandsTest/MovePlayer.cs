using Breakout.Commands.GameRunning;
using Breakout.Entities;
using DIKUArcade.GUI;

namespace BreakoutTests.CommandsTest;

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
        var playerEntity = PlayerEntity.Create();
        const bool shouldMove = true;
        var command = new MovePlayerLeftCommand(playerEntity, shouldMove);
            
        command.Execute();
            
        Assert.That(playerEntity.GetMoveLeft(), Is.EqualTo(shouldMove));
    }

    [Test]
    public void MoveLeftFalseTest()
    {
        var playerEntity = PlayerEntity.Create();
        const bool shouldMove = false;
        var command = new MovePlayerLeftCommand(playerEntity, shouldMove);
            
        command.Execute();
            
        Assert.That(playerEntity.GetMoveLeft(), Is.EqualTo(shouldMove));
    }
        
    [Test]
    public void MoveRightTrueTest()
    {
        var playerEntity = PlayerEntity.Create();
        const bool shouldMove = true;
        var command = new MovePlayerLeftCommand(playerEntity, shouldMove);
            
        command.Execute();
            
        Assert.That(playerEntity.GetMoveLeft(), Is.EqualTo(shouldMove));
    }

    [Test]
    public void MoveRightFalseTest()
    {
        var playerEntity = PlayerEntity.Create();
        const bool shouldMove = false;
        var command = new MovePlayerRightCommand(playerEntity, shouldMove);
            
        command.Execute();
            
        Assert.That(playerEntity.GetMoveRight(), Is.EqualTo(shouldMove));
    }
}