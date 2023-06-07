using Breakout.Events;
using Breakout.Factories;
using Breakout.States;
using Breakout.States.GameRunning;
using DIKUArcade.Events;
using DIKUArcade.Events.Generic;
using DIKUArcade.GUI;

namespace BreakoutTests.StateTest;


[TestFixture]
public class StateMachineTesting
{
    private StateMachine _stateMachine = null!;
    private GameEventFactory _gameEventFactory;

    [OneTimeSetUp]
    public void InitiateStateMachine()
    {
        Window.CreateOpenGLContext();

        GameEventBus<GameEventType> gameEventBus = BreakoutBus.GetBus();
        gameEventBus.InitializeEventBus(new List<GameEventType>
            { GameEventType.InputEvent, GameEventType.GameStateEvent });

        _stateMachine = new StateMachine();
        _gameEventFactory = new GameEventFactory();

        gameEventBus.Subscribe(GameEventType.GameStateEvent, _stateMachine);
        gameEventBus.Subscribe(GameEventType.InputEvent, _stateMachine);
    }

    [Test]
    public void TestInitialState()
    {
        Assert.That(_stateMachine.ActiveState, Is.InstanceOf<MainMenuState>());
    }

    [TestCase("Running", typeof(GameRunningState))]
    [TestCase("Paused", typeof(GamePauseState))]
    [TestCase("Menu", typeof(MainMenuState))]
    public void TestEventGameStates(string newState, Type state)
    {
        GameEvent<GameEventType> gameEvent = _gameEventFactory.CreateGameEvent(GameEventType.GameStateEvent, "CHANGE_STATE", newState);
       
        BreakoutBus.GetBus().RegisterEvent(gameEvent);

        BreakoutBus.GetBus().ProcessEventsSequentially();

        Assert.That(_stateMachine.ActiveState, Is.InstanceOf(state));
    }


    [TestCase("Paused", typeof(MainMenuState))]
    [TestCase("Running", typeof(GamePauseState))]
    [TestCase("Menu", typeof(GameRunningState))]
    public void TestNegationEventGameStates(string newState, Type state)
    {
        GameEvent<GameEventType> gameEvent = _gameEventFactory.CreateGameEvent(GameEventType.GameStateEvent, "CHANGE_STATE", newState);
        
        BreakoutBus.GetBus().RegisterEvent(gameEvent);
        BreakoutBus.GetBus().ProcessEventsSequentially();

        Assert.That(_stateMachine.ActiveState, Is.Not.InstanceOf(state));
    }
}