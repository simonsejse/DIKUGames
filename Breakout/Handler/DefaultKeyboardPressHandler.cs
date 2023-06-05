using Breakout.Commands;
using DIKUArcade.Input;

namespace Breakout.Handler;

/// <summary>
/// Default implementation of the IKeyboardPressHandler interface that handles keyboard key presses
/// and executes the associated commands.
/// </summary>
public class DefaultKeyboardPressHandler : IKeyboardPressHandler
{
    /// <summary>
    /// Initializes a new instance of the DefaultKeyboardPressHandler class with the provided
    /// dictionary of keyboard key sets and their associated commands.
    /// </summary>
    /// <param name="pressKeyboardActions">The dictionary of keyboard key sets and their associated commands.</param>
    public DefaultKeyboardPressHandler(Dictionary<HashSet<KeyboardKey>, IKeyboardCommand> pressKeyboardActions)
    {
        PressKeyboardActions = pressKeyboardActions;
    }
    
    /// <summary>
    /// Gets the dictionary of keyboard key sets and their associated commands.
    /// </summary>
    public Dictionary<HashSet<KeyboardKey>, IKeyboardCommand> PressKeyboardActions { get; }
    
    /// <summary>
    /// Handles the key press event by executing the associated command if it exists.
    /// </summary>
    /// <param name="key">The pressed keyboard key.</param>
    public void HandleKeyPress(KeyboardKey key)
    {
        var command = PressKeyboardActions.FirstOrDefault(keyPairValue => keyPairValue.Key.Contains(key)).Value;
        command?.Execute();
    }
}