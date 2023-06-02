using Breakout.Commands;
using Breakout.Commands.LevelSelection;
using Breakout.Commands.MainMenu;
using Breakout.Factories;
using Breakout.Handler;
using Breakout.States;
using DIKUArcade.Input;

namespace Breakout.Controller;

public class LevelSelectionStateKeyboardController : DefaultKeyboardPressHandler
{
    public LevelSelectionStateKeyboardController(DefaultMenu menu) : base(new Dictionary<HashSet<KeyboardKey>, IKeyboardCommand>
    {
        //{ SetFactory.Create(KeyboardKey.Escape), new CloseMenuCommand() },
        { SetFactory.Create(KeyboardKey.Up, KeyboardKey.W), new ShiftMenuUpCommand(menu) },
        { SetFactory.Create(KeyboardKey.Down, KeyboardKey.S), new ShiftMenuDownCommand(menu) },
        { SetFactory.Create(KeyboardKey.Enter), new LevelSelectionEnterCommand(menu, new GameEventFactory()) },
    }) { }
    
}