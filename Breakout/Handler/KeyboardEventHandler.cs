using Breakout.Commands;
using DIKUArcade.Input;

namespace Breakout.Handler;

/// <summary>
/// The top-level abstract interface that combines both press and release handlers,
/// that will be implemented by concrete classes that will provide actual implementations
/// for both key release and key press events.
/// </summary>
public interface IKeyboardEventHandler : IKeyboardPressHandler, IKeyboardReleaseHandler
{
}

/// <summary>
/// The abstract interface for handling key press events, that will be
/// implemented by concrete classes that provide actual implementation
/// for only key press events.
/// </summary>
public interface IKeyboardPressHandler
{
    Dictionary<HashSet<KeyboardKey>, IKeyboardCommand> PressKeyboardActions { get; }

    void HandleKeyPress(KeyboardKey key)
    {
        var command = PressKeyboardActions.FirstOrDefault(keyPairValue => keyPairValue.Key.Contains(key)).Value;
        command?.Execute();
    }
}

/// <summary>
/// The abstract interface for handling key release events, that will be
/// implemented by concrete classes that provide actual implementation
/// for only key release events.
/// </summary>
public interface IKeyboardReleaseHandler
{
    Dictionary<HashSet<KeyboardKey>, IKeyboardCommand> ReleaseKeyboardActions { get; }

    //TODO: public class DefaultKeyboardReleaseHandler : IKeyboardreleaseHandler
    void HandleKeyRelease(KeyboardKey key)
    {
        var command = ReleaseKeyboardActions.FirstOrDefault(keyPairValue => keyPairValue.Key.Contains(key)).Value;
        command?.Execute();
    }
}