using Breakout.Commands;
using Breakout.Commands.GameLost;
using Breakout.Commands.MainMenu;
using Breakout.Factories;
using Breakout.Handler;
using DIKUArcade.Input;

namespace Breakout.Controller;

public class LostGameKeyboardController : DefaultKeyboardPressHandler
{
    public LostGameKeyboardController(DefaultMenu menu) : base(new Dictionary<HashSet<KeyboardKey>, IKeyboardCommand>
    {
        { SetFactory.Create(KeyboardKey.Up, KeyboardKey.W), new ShiftMenuUpCommand(menu) },
        { SetFactory.Create(KeyboardKey.Down, KeyboardKey.S), new ShiftMenuDownCommand(menu) },
        { SetFactory.Create(KeyboardKey.Enter), new GameOverEnterCommand(menu, new GameEventFactory()) },
    }) { }
}