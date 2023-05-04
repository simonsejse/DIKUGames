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
    private readonly PlayerEntity _playerEntity;
    private readonly IGameEventFactory<GameEventType> gameEventFactory;

    public RunningStateKeyboardController(PlayerEntity playerEntity)
    {
        _playerEntity = playerEntity;
        gameEventFactory = new GameEventFactory();
    }
    
    public void HandleKeyPress(KeyboardKey key)
    {
        switch (key)
        {
            case KeyboardKey.Escape:
                GameEvent<GameEventType> close = gameEventFactory.CreateGameEventForAllProcessors(GameEventType.WindowEvent,"CLOSE_WINDOW");
                BreakoutBus.GetBus().RegisterEvent(close);
                break;
            case KeyboardKey.A:
            case KeyboardKey.Left:
                _playerEntity.SetMoveLeft(true);
                break;
            case KeyboardKey.D:
            case KeyboardKey.Right:
                _playerEntity.SetMoveRight(true);
                break;
        }
    }

    public void HandleKeyRelease(KeyboardKey key)
    {
        switch (key)
        {
            case KeyboardKey.A:
            case KeyboardKey.Left:
                _playerEntity.SetMoveLeft(false);
                break;
            case KeyboardKey.D:
            case KeyboardKey.Right:
                _playerEntity.SetMoveRight(false);
                break;
        }
    }
}


