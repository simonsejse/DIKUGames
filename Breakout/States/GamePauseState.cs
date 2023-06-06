using System.Drawing;
using Breakout.Controller;
using Breakout.Factories;
using Breakout.Handler;
using Breakout.Utility;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Input;
using DIKUArcade.Math;
using DIKUArcade.State;

namespace Breakout.States;

/// <summary>
/// Represents the game pause state where the game is paused and a pause menu is displayed.
/// </summary
public class GamePauseState : DefaultMenu, IGameState {
    private static GamePauseState? _instance;
    private readonly IKeyboardPressHandler _keyboardEventHandler;

    /// <summary>
    /// Initializes a new instance of the <see cref="GamePauseState"/> class.
    /// </summary>
    private GamePauseState() : base(MenuUtil.PausedMenuItems, MenuUtil.PausedBackground) {
        _keyboardEventHandler = new PauseStateKeyboardController(this);
    }
    
    /// <summary>
    /// Gets the singleton instance of the <see cref="GamePauseState"/>.
    /// </summary>
    /// <returns>The singleton instance of the <see cref="GamePauseState"/>.</returns>
    public static GamePauseState GetInstance() {
        return _instance ??= new GamePauseState();
    }
    
    /// <summary>
    /// Resets the state, allowing a new instance of the <see cref="GamePauseState"/> to be created.
    /// </summary>
    public void ResetState() {
        _instance = null;
    }

    /// <summary>
    /// Updates the game pause state.
    /// </summary>
    public void UpdateState() {
    }

    /// <summary>
    /// Renders the game pause state, including the pause menu.
    /// </summary>
    public void RenderState() {
        base.RenderMenuItems();
    }

    /// <summary>
    /// Handles the key events for the game pause state.
    /// </summary>
    /// <param name="action">The keyboard action (keypress, keyrelease, etc.).</param>
    /// <param name="key">The keyboard key that was pressed or released.</param>
    public void HandleKeyEvent(KeyboardAction action, KeyboardKey key) {
        if (action is not KeyboardAction.KeyPress) return;
        
        _keyboardEventHandler.HandleKeyPress(key);
    }
}