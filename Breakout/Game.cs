using Breakout.Events;
using Breakout.States;
using DIKUArcade;
using DIKUArcade.Events;
using DIKUArcade.Events.Generic;
using DIKUArcade.GUI;
using DIKUArcade.Input;

namespace Breakout;

/// <summary>
/// Represents a game object that inherits from the DIKUGame class.
/// </summary>
public class Game : DIKUGame, IGameEventProcessor<GameEventType> {
    /// <summary>
    /// The <see cref="StateMachine"/> represents the internal state
    /// and uses the state pattern to infer and change
    /// which state the game is currently in.
    /// </summary>
    private readonly StateMachine _stateMachine;
    
    /// <summary>
    /// Constant field that represents all game types that will be used
    /// throughout the applications life cycle.
    /// </summary>
    private static readonly IReadOnlyList<GameEventType> GameEventTypes = new List<GameEventType> {
        GameEventType.InputEvent, 
        GameEventType.GameStateEvent,
        GameEventType.WindowEvent,
        GameEventType.StatusEvent,
    };

    /// <summary>
    /// Initializes a new instance of the Game class with the specified WindowArgs.
    /// </summary>
    /// <param name="windowArgs">The arguments used to create the game's window.</param>
    public Game(WindowArgs windowArgs) : base(windowArgs) {
        BreakoutBus.GetBus().InitializeEventBus(GameEventTypes.ToList());
        BreakoutBus.GetBus().Subscribe(GameEventType.WindowEvent, this);
        _stateMachine = new StateMachine();
        window.SetKeyEventHandler(HandleKeyEvent);
    }
    
    /// <summary>
    /// Updates the game's state by calling the active state's UpdateState method.
    /// </summary>
    public override void Update() {
        _stateMachine.ActiveState.UpdateState();
        BreakoutBus.GetBus().ProcessEventsSequentially();
    }

    /// <summary>
    /// Renders the game's state by calling the active state's RenderState method.
    /// </summary>
    public override void Render() {
        _stateMachine.ActiveState.RenderState();
    }
    
    /// <summary>
    /// Handles keyboard events by calling the active state's HandleKeyEvent method.
    /// </summary>
    /// <param name="action">The action that occurred (press or release).</param>
    /// <param name="key">The key that was pressed or released.</param>
    private void HandleKeyEvent(KeyboardAction action, KeyboardKey key) {
        _stateMachine.ActiveState.HandleKeyEvent(action, key);
    }

    /// <summary>
    /// TODO: Add good comment, idk what to write lmao
    /// </summary>
    /// <param name="gameEvent"></param>
    public void ProcessEvent(GameEvent<GameEventType> gameEvent) {
        if (!"CLOSE_WINDOW".Equals(gameEvent.Message)) return;
        window.CloseWindow();
    }
}