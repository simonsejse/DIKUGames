using Breakout.Events;
using Breakout.States.GameLost;
using Breakout.States.GameRunning;
using Breakout.States.GameWon;
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

    private static readonly Dictionary<GameState, Func<IGameState>> States = new()
    {
        { GameState.Menu, MainMenuState.GetInstance },
        { GameState.Running, GameRunningState.GetInstance },
        { GameState.Paused, GamePauseState.GetInstance },
        { GameState.Lost, GameLostState.GetInstance },
        { GameState.Won, GameWonState.GetInstance },
        { GameState.LevelSelection, LevelSelectionState.GetInstance }
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
    private void SwitchState(GameState stateType, int levelIndex = 0)
    {
        if (!States.ContainsKey(stateType))
            throw new ArgumentException("State does not exist!", nameof(stateType));
        
        if (stateType == GameState.LevelSelection)
        {
            LevelSelectionState levelSelectionState = (LevelSelectionState)States[stateType]();
            levelSelectionState.SetLevelIndex(levelIndex);
            ActiveState = levelSelectionState;
        }
        else
        {
            ActiveState = States[stateType]();
        }
    }
        
    public void ProcessEvent(GameEvent<GameEventType> gameEvent)
    {
        if (gameEvent.EventType != GameEventType.GameStateEvent) return;

        string message = gameEvent.Message;
        string arg1 = gameEvent.StringArg1;

        switch (message)
        {
            case "CHANGE_STATE":
                SwitchState(_stateTransformer.TransformStringToState(arg1));
                Console.WriteLine("Ay");
                break;
            case "NEW_GAME":
                ResetAllStates();
                SwitchState(_stateTransformer.TransformStringToState(arg1));
                break;
        }
    }

    private void ResetAllStates()
    {
        foreach (Func<IGameState> state in States.Values) state().ResetState();
    }
}


