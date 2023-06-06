using Breakout.Controller;
using Breakout.Handler;
using Breakout.Utility;
using DIKUArcade.Input;
using DIKUArcade.State;

namespace Breakout.States;

/// <summary>
/// Represents the main menu state where the game's main menu is displayed.
/// </summary>
public class MainMenuState : DefaultMenu, IGameState {
    private static MainMenuState? _instance;
    private readonly IKeyboardPressHandler _keyboardEventHandler;

    /// <summary>
    /// Initializes a new instance of the <see cref="MainMenuState"/> class.
    /// </summary>
    private MainMenuState() : base(MenuUtil.MainMenuItems, MenuUtil.MainMenuBackground) {
        _keyboardEventHandler = new MainMenuStateKeyboardController(this);
    }
    
    /// <summary>
    /// Gets the singleton instance of the <see cref="MainMenuState"/>.
    /// </summary>
    /// <returns>The singleton instance of the <see cref="MainMenuState"/>.</returns>
    public static MainMenuState GetInstance() {
        return _instance ??= new MainMenuState();
    }

    /// <summary>
    /// Resets the state, allowing a new instance of the <see cref="MainMenuState"/> to be created.
    /// </summary>
    public void ResetState() {
        _instance = null;
    }


    /// <summary>
    /// Updates the main menu state.
    /// </summary>
    public void UpdateState() {
    }

    /// <summary>
    /// Renders the main menu state, including the main menu items.
    /// </summary>
    public void RenderState() {
        base.RenderMenuItems();
    }

    /// <summary>
    /// Handles the key events for the main menu state.
    /// </summary>
    /// <param name="action">The keyboard action (keypress, keyrelease, etc.).</param>
    /// <param name="key">The keyboard key that was pressed or releas
    public void HandleKeyEvent(KeyboardAction action, KeyboardKey key) {
        if (action is not KeyboardAction.KeyPress) return;
        
        _keyboardEventHandler.HandleKeyPress(key);
    }
}