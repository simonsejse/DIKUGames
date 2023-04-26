using Breakout.Entites;
using Breakout.Events;
using Breakout.Handler;
using Breakout.States;
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
    
    public RunningStateKeyboardController(PlayerEntity playerEntity)
    {
        _playerEntity = playerEntity;
    }
    
    public void HandleKeyPress(KeyboardKey key)
    {
        switch (key)
        {
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