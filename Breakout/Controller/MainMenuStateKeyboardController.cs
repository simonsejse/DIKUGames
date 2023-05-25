using Breakout.Commands;
using Breakout.Commands.MainMenu;
using Breakout.Factories;
using Breakout.Handler;
using DIKUArcade.Input;

namespace Breakout.Controller;

public class MainMenuStateKeyboardController : DefaultKeyboardPressHandler
{
    public MainMenuStateKeyboardController(DefaultMenu state) : base(new Dictionary<HashSet<KeyboardKey>, IKeyboardCommand>
    {
        { SetFactory.Create(KeyboardKey.Escape), new CloseMenuCommand() },
        { SetFactory.Create(KeyboardKey.Up, KeyboardKey.W), new ShiftMenuUpCommand(state) },
        { SetFactory.Create(KeyboardKey.Down, KeyboardKey.S), new ShiftMenuDownCommand(state) },
        { SetFactory.Create(KeyboardKey.Enter), new MainMenuEnterCommand(state, new GameEventFactory()) },
    }) { }
}