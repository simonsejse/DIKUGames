using Breakout.Commands;
using Breakout.Commands.MainMenu;
using Breakout.Commands.Paused;
using Breakout.Factories;
using Breakout.Handler;
using DIKUArcade.Input;

namespace Breakout.Controller;

public class PauseStateKeyboardController : IKeyboardPressHandler
{
    public Dictionary<HashSet<KeyboardKey>, IKeyboardCommand> PressKeyboardActions { get; }
 
    public PauseStateKeyboardController(IMenu menu)
    {
        var shiftMenuUpCommand = new ShiftMenuUpCommand(menu);
        var shiftMenuDownCommand = new ShiftMenuDownCommand(menu);
        var pauseEnterCommand = new PauseEnterCommand(menu, new GameEventFactory());
        PressKeyboardActions = new Dictionary<HashSet<KeyboardKey>, IKeyboardCommand>
        {
            { SetFactory.Create(KeyboardKey.Up, KeyboardKey.W), shiftMenuUpCommand },
            { SetFactory.Create(KeyboardKey.Down, KeyboardKey.S), shiftMenuDownCommand },
            { SetFactory.Create(KeyboardKey.Enter), pauseEnterCommand},
        };
    }
    
}