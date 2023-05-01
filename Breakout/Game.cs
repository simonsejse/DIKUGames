using Breakout.Events;
using Breakout.Handler;
using Breakout.States;
using DIKUArcade;
using DIKUArcade.Events;
using DIKUArcade.GUI;
using DIKUArcade.Input;

namespace Breakout;

/// <summary>
/// Represents a game object that inherits from the DIKUGame class.
/// </summary>
public class Game : DIKUGame
{
    private readonly StateMachine _stateMachine;
    
    /// <summary>
    /// Initializes a new instance of the Game class with the specified WindowArgs.
    /// </summary>
    /// <param name="windowArgs">The arguments used to create the game's window.</param>
    public Game(WindowArgs windowArgs) : base(windowArgs)
    {
        BreakoutBus.GetBus().InitializeEventBus(new List<GameEventType> { GameEventType.InputEvent, GameEventType.GameStateEvent});
        _stateMachine = new StateMachine();
        window.SetKeyEventHandler(HandleKeyEvent);
    }
    
    /// <summary>
    /// Updates the game's state by calling the active state's UpdateState method.
    /// </summary>
    public override void Update()
    {
        _stateMachine.ActiveState.UpdateState();
    }

    /// <summary>
    /// Renders the game's state by calling the active state's RenderState method.
    /// </summary>
    public override void Render()
    {
        _stateMachine.ActiveState.RenderState();
    }
    
    /// <summary>
    /// Handles keyboard events by calling the active state's HandleKeyEvent method.
    /// </summary>
    /// <param name="action">The action that occurred (press or release).</param>
    /// <param name="key">The key that was pressed or released.</param>
    private void HandleKeyEvent(KeyboardAction action, KeyboardKey key)
    {
        _stateMachine.ActiveState.HandleKeyEvent(action, key);
    }
    
}