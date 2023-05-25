using Breakout.Commands;
using DIKUArcade.Input;

namespace Breakout.Handler;

public class DefaultKeyboardPressHandler : IKeyboardPressHandler
{
    public DefaultKeyboardPressHandler(Dictionary<HashSet<KeyboardKey>, IKeyboardCommand> pressKeyboardActions)
    {
        PressKeyboardActions = pressKeyboardActions;
    }
    public Dictionary<HashSet<KeyboardKey>, IKeyboardCommand> PressKeyboardActions { get; }
    
    public void HandleKeyPress(KeyboardKey key)
    {
        var command = PressKeyboardActions.FirstOrDefault(keyPairValue => keyPairValue.Key.Contains(key)).Value;
        command?.Execute();
    }
}