using DIKUArcade.Input;

namespace Breakout.Handler;

/// <summary>
/// The top-level abstract interface that combines both press and release handlers,
/// that will be implemented by concrete classes that will provide actual implementations
/// for both key release and key press events.
/// </summary>
public interface IKeyboardEventHandler : IKeyboardPressHandler, IKeyboardReleaseHandler { }

/// <summary>
/// The abstract interface for handling key press events, that will be
/// implemented by concrete classes that provide actual implementation
/// for only key press events.
/// </summary>
public interface IKeyboardPressHandler
{
    void HandleKeyPress(KeyboardKey key);
}

/// <summary>
/// The abstract interface for handling key release events, that will be
/// implemented by concrete classes that provide actual implementation
/// for only key release events.
/// </summary>
public interface IKeyboardReleaseHandler
{
    void HandleKeyRelease(KeyboardKey key);
}