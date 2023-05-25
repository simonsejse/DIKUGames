using Breakout.Commands;
using Breakout.Commands.MainMenu;
using Breakout.Commands.Paused;
using Breakout.Factories;
using Breakout.Handler;
using DIKUArcade.Input;

namespace Breakout.Controller;

public class PauseStateKeyboardController : DefaultKeyboardPressHandler
{
    public PauseStateKeyboardController(DefaultMenu menu) : base(new Dictionary<HashSet<KeyboardKey>, IKeyboardCommand>
    {
        { SetFactory.Create(KeyboardKey.Up, KeyboardKey.W), new ShiftMenuUpCommand(menu) },
        { SetFactory.Create(KeyboardKey.Down, KeyboardKey.S), new ShiftMenuDownCommand(menu) },
        { SetFactory.Create(KeyboardKey.Enter), new PauseEnterCommand(menu, new GameEventFactory())},
    }) { }
}