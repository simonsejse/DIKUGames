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
    /// <summary>
    /// The transformer used to convert from and to string representations to GameState enums, respectively.
    /// </summary>
    private readonly StateTransformer _stateTransformer = new();
    
    /// <summary>
    /// The currently active game state.
    /// </summary>
    public IGameState ActiveState { get; private set; }

    /// <summary>
    /// Initializes a new instance of the StateMachine class.
    /// </summary>
    public StateMachine()
    {
        BreakoutBus.GetBus().Subscribe(GameEventType.GameStateEvent, this);
        BreakoutBus.GetBus().Subscribe(GameEventType.InputEvent, this);
        ActiveState = GameRunningState.GetInstance();
    }

    /// <summary>
    /// Switches to the specified game state.
    /// </summary>
    /// <param name="stateType">The type of game state to switch to.</param>
    private void SwitchState(GameState stateType)
    {
        ActiveState = stateType switch
        {
            GameState.Menu => MainMenuState.GetInstance(),
            GameState.Running => GameRunningState.GetInstance(),
            //GameState.Paused => .GetInstance(),
            //GameState.Lost => .GetInstance(),
            _ => throw new ArgumentOutOfRangeException(nameof(stateType), stateType, null)
        };
    }
        
    ///TODO: Add XML something like used to process events for switching between states
    public void ProcessEvent(GameEvent<GameEventType> gameEvent)
    {
        
    }
}

