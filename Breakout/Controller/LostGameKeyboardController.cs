using Breakout.Commands;
using Breakout.Commands.GameLost;
using Breakout.Factories;
using Breakout.Handler;
using DIKUArcade.Input;

namespace Breakout.Controller;

public class LostGameKeyboardController : DefaultKeyboardPressHandler
{
    public LostGameKeyboardController() : base(new Dictionary<HashSet<KeyboardKey>, IKeyboardCommand>
    {
        { SetFactory.Create(KeyboardKey.Enter), new ReturnToMainMenuCommand(new GameEventFactory()) }
    }) { }
}