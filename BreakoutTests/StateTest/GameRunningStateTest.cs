using Breakout.States.GameRunning;
using Window = DIKUArcade.GUI.Window;

namespace BreakoutTests.StateTest;

[TestFixture]
public class GameRunningStateTest
{
    private GameRunningState gameRunningState;

    [SetUp]
    public void Setup()
    {
        Window.CreateOpenGLContext();
        gameRunningState = GameRunningState.GetInstance();
    }

    public void ResetStateTest()
    {
        gameRunningState.ResetState();
        Assert.That(gameRunningState, Is.Null);
        var runningState = GameRunningState.GetInstance();
        
    }

}