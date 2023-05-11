using Breakout.Commands;
using Breakout.Commands.GameRunning;
using Breakout.Commands.MainMenu;
using Breakout.Entities;
using Breakout.Factories;
using Breakout.Handler;
using DIKUArcade.Events;
using DIKUArcade.Events.Generic;
using DIKUArcade.Input;

namespace Breakout.Controller;


/// <summary>
/// Default concrete implementation for the abstract interface <see cref="IKeyboardEventHandler"/>.
/// </summary>
public class RunningStateKeyboardController : IKeyboardEventHandler
{
    public Dictionary<HashSet<KeyboardKey>, IKeyboardCommand> PressKeyboardActions { get; }
    public Dictionary<HashSet<KeyboardKey>, IKeyboardCommand> ReleaseKeyboardActions { get; }
    
    public RunningStateKeyboardController(PlayerEntity playerEntity)
    {
        var movePlayerRightCommand = new MovePlayerRightCommand(playerEntity, true);
        var movePlayerLeftCommand = new MovePlayerLeftCommand(playerEntity, true);
        PressKeyboardActions = new Dictionary<HashSet<KeyboardKey>, IKeyboardCommand>
        {
            { SetFactory.Create(KeyboardKey.Right, KeyboardKey.D), movePlayerRightCommand },
            { SetFactory.Create(KeyboardKey.Left, KeyboardKey.A), movePlayerLeftCommand },
            { SetFactory.Create(KeyboardKey.Escape), new PauseGameCommand(new GameEventFactory()) }
        };
        
        var playerLeftCommand = new MovePlayerLeftCommand(playerEntity, false);
        var playerRightCommand = new MovePlayerRightCommand(playerEntity, false);
        ReleaseKeyboardActions = new Dictionary<HashSet<KeyboardKey>, IKeyboardCommand>
        {
            { SetFactory.Create(KeyboardKey.Left, KeyboardKey.A), playerLeftCommand },
            { SetFactory.Create(KeyboardKey.Right, KeyboardKey.D), playerRightCommand }
        };
    }
    
}


