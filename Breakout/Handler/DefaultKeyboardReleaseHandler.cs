using Breakout.Commands;
using DIKUArcade.Input;

namespace Breakout.Handler;

/// <summary>
/// Default implementation of the IKeyboardReleaseHandler interface that handles keyboard key releases
/// and executes the associated commands.
/// </summary>
public class DefaultKeyboardReleaseHandler : IKeyboardReleaseHandler {
    /// <summary>
    /// Initializes a new instance of the DefaultKeyboardReleaseHandler class with the provided
    /// dictionary of keyboard key sets and their associated commands for key releases.
    /// </summary>
    /// <param name="releaseKeyboardActions">The dictionary of keyboard key sets and their 
    /// associated commands for key releases.</param>
    public DefaultKeyboardReleaseHandler(
        Dictionary<HashSet<KeyboardKey>, IKeyboardCommand> releaseKeyboardActions) {
            ReleaseKeyboardActions = releaseKeyboardActions;
    }

    /// <summary>
    /// Gets the dictionary of keyboard key sets and their associated commands for key releases.
    /// </summary>
    private Dictionary<HashSet<KeyboardKey>, IKeyboardCommand> ReleaseKeyboardActions { get; }

    /// <summary>
    /// Handles the key release event by executing the associated command.
    /// </summary>
    /// <param name="key">The released keyboard key.</param>
    public void HandleKeyRelease(KeyboardKey key) {
        var command = ReleaseKeyboardActions.FirstOrDefault(
            keyPairValue => keyPairValue.Key.Contains(key)).Value;
        command?.Execute();
    }
}