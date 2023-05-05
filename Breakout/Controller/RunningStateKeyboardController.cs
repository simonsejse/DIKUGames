using Breakout.Commands;
using Breakout.Commands.GameRunning;
using Breakout.Commands.MainMenu;
using Breakout.Entites;
using Breakout.Events;
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
    private readonly IGameEventFactory<GameEventType> _gameEventFactory;
    public IReadOnlyDictionary<HashSet<KeyboardKey>, IKeyboardCommand> PressKeyboardActions { get; }
    public IReadOnlyDictionary<HashSet<KeyboardKey>, IKeyboardCommand> ReleaseKeyboardActions { get; }
    
    public RunningStateKeyboardController(PlayerEntity playerEntity)
    {
        _gameEventFactory = new GameEventFactory();
        PressKeyboardActions = new Dictionary<HashSet<KeyboardKey>, IKeyboardCommand>
        {
            { SetFactory.Create(KeyboardKey.Escape), new CloseMenuCommand() },
            { SetFactory.Create(KeyboardKey.Left, KeyboardKey.A), new MovePlayerLeftCommand(playerEntity, true) },
            { SetFactory.Create(KeyboardKey.Right, KeyboardKey.D), new MovePlayerRightCommand(playerEntity, true) }
        };
        ReleaseKeyboardActions = new Dictionary<HashSet<KeyboardKey>, IKeyboardCommand>
        {
            { SetFactory.Create(KeyboardKey.Escape), new CloseMenuCommand() },
            { SetFactory.Create(KeyboardKey.Left, KeyboardKey.A), new MovePlayerLeftCommand(playerEntity, false) },
            { SetFactory.Create(KeyboardKey.Right, KeyboardKey.D), new MovePlayerRightCommand(playerEntity, false) }
        };
    }

    public void HandleKeyPress(KeyboardKey keyboardKey)
    {
        var command = PressKeyboardActions.FirstOrDefault(keyPairValue => keyPairValue.Key.Contains(keyboardKey)).Value;
        command?.Execute();
    }

    public void HandleKeyRelease(KeyboardKey keyboardKey)
    {
        var command = ReleaseKeyboardActions.FirstOrDefault(keyPairValue => keyPairValue.Key.Contains(keyboardKey)).Value;
        command?.Execute();
    }
}


