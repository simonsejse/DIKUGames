using Breakout.Commands;
using DIKUArcade.Input;

namespace Breakout.Handler;

public class DefaultKeyboardReleaseHandler : IKeyboardReleaseHandler
{
    public DefaultKeyboardReleaseHandler(Dictionary<HashSet<KeyboardKey>, IKeyboardCommand> releaseKeyboardActions)
    {
        ReleaseKeyboardActions = releaseKeyboardActions;
    }

    private Dictionary<HashSet<KeyboardKey>, IKeyboardCommand> ReleaseKeyboardActions { get; }

    public void HandleKeyRelease(KeyboardKey key)
    {
        var command = ReleaseKeyboardActions.FirstOrDefault(keyPairValue => keyPairValue.Key.Contains(key)).Value;
        command?.Execute();
    }
}