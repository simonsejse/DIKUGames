using DIKUArcade.Events;
using DIKUArcade.Events.Generic;
using DIKUArcade.GUI;
using DIKUArcade.State;
using Galaga;
using Galaga.GalagaStates;

namespace GalagaTests;

[TestFixture]
public class StateMachineTesting
{
    private StateMachine _stateMachine = null!;
    
    [OneTimeSetUp]
    public void InitiateStateMachine() {
        Window.CreateOpenGLContext();

        //(1) Initialize a GalagaBus with proper GameEventTypes
        GameEventBus<GameEventType> gameEventBus = GalagaBus.GetBus();
        gameEventBus.InitializeEventBus(new List<GameEventType> { GameEventType.InputEvent,GameEventType.GameStateEvent });

        //(2) Instantiate the StateMachine
        _stateMachine = new StateMachine();
        
        //(3) Subscribe the GalagaBus to proper GameEventTypes and GameEventProcessors
        gameEventBus.Subscribe(GameEventType.GameStateEvent, _stateMachine);
        gameEventBus.Subscribe(GameEventType.InputEvent, _stateMachine);
    }
    
    [Test]
    public void TestInitialState() {
        Assert.That(_stateMachine.ActiveState, Is.InstanceOf<MainMenu>());
    }

    [TestCase("GameRunning", typeof(GameRunning))]
    [TestCase("GamePaused", typeof(GamePaused))]
    [TestCase("MainMenu", typeof(MainMenu))]
    public void TestEventGameStates(string newState, Type state)
    {
        GalagaBus.GetBus().RegisterEvent(
            new GameEvent<GameEventType>
            {
                EventType = GameEventType.GameStateEvent,
                Message = "CHANGE_STATE",
                StringArg1 = newState,
            }
        );
        GalagaBus.GetBus().ProcessEventsSequentially();
        
        Assert.That(_stateMachine.ActiveState, Is.InstanceOf(state));
    }
    
    
    [TestCase("GamePaused", typeof(MainMenu))]
    [TestCase("GameRunning", typeof(GamePaused))]
    [TestCase("MainMenu", typeof(GameRunning))]
    public void TestNegationEventGameStates(string newState, Type state)
    {
        GalagaBus.GetBus().RegisterEvent(
            new GameEvent<GameEventType>
            {
                EventType = GameEventType.GameStateEvent,
                Message = "CHANGE_STATE",
                StringArg1 = newState,
            }
        );
        GalagaBus.GetBus().ProcessEventsSequentially();
        
        Assert.That(_stateMachine.ActiveState, Is.Not.InstanceOf(state));
    }
}