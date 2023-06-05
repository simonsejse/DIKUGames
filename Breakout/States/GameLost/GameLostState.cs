using Breakout.Controller;
using Breakout.Handler;
using Breakout.Utility;
using DIKUArcade.Input;
using DIKUArcade.State;

namespace Breakout.States.GameLost;

/// <summary>
/// Represents the game state when the player has lost the game.
/// </summary>
public class GameLostState : DefaultMenu, IGameState
{
    private static GameLostState? _instance;

    private readonly IKeyboardPressHandler _keyboardPressHandler;
    /// <summary>
    /// Gets the singleton instance of the <see cref="GameLostState"/>.
    /// </summary>
    /// <returns>The singleton instance of the <see cref="GameLostState"/>.</returns>
    public static GameLostState GetInstance()
    {
        return _instance ??= new GameLostState();
    }
    
    private GameLostState() : base(MenuUtil.LostMenuItems, MenuUtil.LostBackground)
    {
        _keyboardPressHandler = new LostGameKeyboardController(this);
    }
    
    /// <summary>
    /// Resets the state of the game lost state.
    /// </summary>
    public void ResetState()
    {
        _instance = null;
    }

    /// <summary>
    /// Updates the state of the game lost state.
    /// </summary>
    public void UpdateState()
    {
        
    }

    /// <summary>
    /// Renders the state of the game lost state.
    /// </summary>
    public void RenderState()
    {
        base.RenderMenuItems();
    }

    // <summary>
    /// Handles the key event for the game lost state.
    /// </summary>
    /// <param name="action">The keyboard action.</param>
    /// <param name="key">The keyboard key.</param>
    public void HandleKeyEvent(KeyboardAction action, KeyboardKey key)
    {
        if (action == KeyboardAction.KeyRelease) return;
        _keyboardPressHandler.HandleKeyPress(key);   
    }
}