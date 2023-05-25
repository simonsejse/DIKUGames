using Breakout.Commands;
using DIKUArcade.Input;

namespace Breakout.Handler;

/// <summary>
/// Default concrete implementation of the IKeyboardEventHandler interface,
/// that combines both key press and key release.
/// </summary>
public class DefaultKeyEventHandler : IKeyboardEventHandler
{
    public DefaultKeyEventHandler(Dictionary<HashSet<KeyboardKey>, IKeyboardCommand> pressKeyboardActions, Dictionary<HashSet<KeyboardKey>, IKeyboardCommand> releaseKeyboardActions)
    {
        PressKeyboardActions = pressKeyboardActions;
        ReleaseKeyboardActions = releaseKeyboardActions;
    }

    private Dictionary<HashSet<KeyboardKey>, IKeyboardCommand> PressKeyboardActions { get; }
    private Dictionary<HashSet<KeyboardKey>, IKeyboardCommand> ReleaseKeyboardActions { get; }
    
    public void HandleKeyPress(KeyboardKey key)
    {
        var command = PressKeyboardActions.FirstOrDefault(keyPairValue => keyPairValue.Key.Contains(key)).Value;
        command?.Execute();
    }

    public void HandleKeyRelease(KeyboardKey key)
    {
        var command = ReleaseKeyboardActions.FirstOrDefault(keyPairValue => keyPairValue.Key.Contains(key)).Value;
        command?.Execute();
    }
}