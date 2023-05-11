using Breakout.Events;
using DIKUArcade.Events;
using DIKUArcade.Events.Generic;
using DIKUArcade.State;

namespace Breakout.States;

/// <summary>
/// This class represents a state machine for managing different game states in a Breakout game,
/// e.g., GameRunning state, MainMenu or Lost etc.
/// </summary>
public class StateMachine : IGameEventProcessor<GameEventType>
{

    private static readonly Dictionary<GameState, IGameState> States = new()
        {
            { GameState.Menu, MainMenuState.GetInstance() },
            { GameState.Running, GameRunningState.GetInstance() },
            { GameState.Paused, PauseState.GetInstance() }
        };

    
    /// <summary>
    /// The transformer used to convert from and to string representations to GameState enums, respectively.
    /// </summary>
    private readonly StateTransformer _stateTransformer = new();
    
    /// <summary>
    /// The currently active game state.
    /// </summary>
    public IGameState ActiveState { get; private set; }

    //public ILevelStrategy LevelStrategy { get; set; }
    /// <summary>
    /// Initializes a new instance of the StateMachine class.
    /// </summary>
    public StateMachine()
    {
        BreakoutBus.GetBus().Subscribe(GameEventType.GameStateEvent, this);
        ActiveState = MainMenuState.GetInstance();
    }

    /// <summary>
    /// Switches to the specified game state.
    /// </summary>
    /// <param name="stateType">The type of game state to switch to.</param>
    private void SwitchState(GameState stateType)
    {
        if (!States.ContainsKey(stateType))
            throw new ArgumentException("State does not exist!", nameof(stateType));
        ActiveState = States[stateType];
    }
        
    ///TODO: Add XML something like used to process events for switching between states
    public void ProcessEvent(GameEvent<GameEventType> gameEvent)
    {
        if (gameEvent.EventType is not GameEventType.GameStateEvent) return;
        
        if (!gameEvent.Message.StartsWith("CHANGE_STATE")) return;
        
        string gameEventStringArg1 = gameEvent.StringArg1;
        SwitchState(_stateTransformer.TransformStringToState(gameEventStringArg1));

        if (gameEvent.Message.Equals("CHANGE_STATE_RESET"))
            ActiveState.ResetState();
    }
}


