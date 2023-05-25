using Breakout.Commands;
using Breakout.Commands.GameRunning;
using Breakout.Entities;
using Breakout.Factories;
using Breakout.Handler;
using DIKUArcade.Input;

namespace Breakout.Controller;


/// <summary>
/// Default concrete implementation for the abstract interface <see cref="IKeyboardEventHandler"/>.
/// </summary>
public class RunningStateKeyboardController : DefaultKeyEventHandler
{
    public RunningStateKeyboardController(PlayerEntity playerEntity) : base(
        new Dictionary<HashSet<KeyboardKey>, IKeyboardCommand>
        {
            { SetFactory.Create(KeyboardKey.Right, KeyboardKey.D), new MovePlayerRightCommand(playerEntity, true) },
            { SetFactory.Create(KeyboardKey.Left, KeyboardKey.A), new MovePlayerLeftCommand(playerEntity, true) },
            { SetFactory.Create(KeyboardKey.Escape), new PauseGameCommand(new GameEventFactory()) }
        }, new Dictionary<HashSet<KeyboardKey>, IKeyboardCommand>
        {
            { SetFactory.Create(KeyboardKey.Left, KeyboardKey.A), new MovePlayerLeftCommand(playerEntity, false) },
            { SetFactory.Create(KeyboardKey.Right, KeyboardKey.D), new MovePlayerRightCommand(playerEntity, false) }
        }) { }
}


