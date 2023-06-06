using Breakout.Commands;
using DIKUArcade.Input;

namespace Breakout.Handler;

/// <summary>
/// Default concrete implementation of the IKeyboardEventHandler interface,
/// that combines both key press and key release.
/// </summary>
public class DefaultKeyEventHandler : IKeyboardEventHandler
{
    /// <summary>
    /// Initializes a new instance of the DefaultKeyEventHandler class with the provided dictionaries
    /// of keyboard key sets and their associated commands for key press and key release events.
    /// </summary>
    /// <param name="pressKeyboardActions">The dictionary of keyboard key sets and their associated 
    /// commands for key press events.</param>
    /// <param name="releaseKeyboardActions">The dictionary of keyboard key sets and their 
    /// associated commands for key release events.</param>
    public DefaultKeyEventHandler(
        Dictionary<HashSet<KeyboardKey>, IKeyboardCommand> pressKeyboardActions, 
        Dictionary<HashSet<KeyboardKey>, IKeyboardCommand> releaseKeyboardActions) {
            PressKeyboardActions = pressKeyboardActions;
            ReleaseKeyboardActions = releaseKeyboardActions;
    }

    private Dictionary<HashSet<KeyboardKey>, IKeyboardCommand> PressKeyboardActions { get; }
    private Dictionary<HashSet<KeyboardKey>, IKeyboardCommand> ReleaseKeyboardActions { get; }
    
    /// <summary>
    /// Handles the key press event by executing the associated command, if any.
    /// </summary>
    /// <param name="key">The pressed keyboard key.</param>
    public void HandleKeyPress(KeyboardKey key) {
        var command = PressKeyboardActions.FirstOrDefault(
            keyPairValue => keyPairValue.Key.Contains(key)).Value;
        command?.Execute();
    }

    /// <summary>
    /// Handles the key release event by executing the associated command, if any.
    /// </summary>
    /// <param name="key">The released keyboard key.</param>
    public void HandleKeyRelease(KeyboardKey key) {
        var command = ReleaseKeyboardActions.FirstOrDefault(
            keyPairValue => keyPairValue.Key.Contains(key)).Value;
        command?.Execute();
    }
}