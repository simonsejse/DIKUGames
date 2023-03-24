using System;
using DIKUArcade.Entities;
using DIKUArcade.Events;
using DIKUArcade.Events.Generic;
using DIKUArcade.Graphics;
using DIKUArcade.Input;
using DIKUArcade.Math;
using Galaga.entities;

namespace Galaga.GalagaStates;
public class RunningStateKeyboardAction : IKeyboardIntermediaryHandler
{
    private readonly Player _player;
    private readonly EntityContainer<PlayerShot> _playerShots;
    private readonly IBaseImage _playerShotImage;

    public RunningStateKeyboardAction(Player player, EntityContainer<PlayerShot> playerShots, IBaseImage playerShotImage)
    {
        _player = player;
        _playerShots = playerShots;
        _playerShotImage = playerShotImage;
    }
    
    public void KeyPress(KeyboardKey key)
    {
        switch (key)
            {
                //TODO: add new way of closing game
               case KeyboardKey.Escape:
                    GameEvent<GameEventType> close = new()
                    {
                        EventType = GameEventType.GameStateEvent,
                        Message = "CHANGE_STATE",
                        StringArg1 = Enum.GetName(GameStateType.GamePaused)
                    };
                    GalagaBus.GetBus().RegisterEvent(close);
                    break;
               case KeyboardKey.Space:
                    var pos = _player.GetPosition();
                    _playerShots.AddEntity(
                        new PlayerShot(new Vec2F(pos.X + _player.GetExtent().X / 2, pos.Y + _player.GetExtent().Y / 2), _playerShotImage)
                    );
                    break;
                case KeyboardKey.W:
                    GalagaBus.GetBus().RegisterEvent(new GameEvent<GameEventType>
                    {
                        From = this,
                        Message = nameof(MovementDirection.Forward),
                        To = _player, //IGameEventProcessor
                        IntArg1 = 1,
                    });
                    break;
                case KeyboardKey.A:
                    GalagaBus.GetBus().RegisterEvent(new GameEvent<GameEventType>
                    {
                        From = this,
                        Message = nameof(MovementDirection.Left),
                        To = _player, //IGameEventProcessor
                        IntArg1 = 1,
                    });
                    break;
                case KeyboardKey.S:
                    GalagaBus.GetBus().RegisterEvent(new GameEvent<GameEventType>
                    {
                        From = this,
                        Message = nameof(MovementDirection.Backward),
                        To = _player, //IGameEventProcessor
                        IntArg1 = 1,
                    });
                    break;
                case KeyboardKey.D:
                    GalagaBus.GetBus().RegisterEvent(new GameEvent<GameEventType>
                    {
                        From = this,
                        Message = nameof(MovementDirection.Right),
                        To = _player, //IGameEventProcessor
                        IntArg1 = 1,
                    });
                    break;
            }
    }

    public void KeyRelease(KeyboardKey key)
    {
        switch (key)
        {
            case KeyboardKey.W:
                GalagaBus.GetBus().RegisterEvent(new GameEvent<GameEventType>
                {
                    From = this,
                    Message = nameof(MovementDirection.Forward),
                    To = _player, //IGameEventProcessor
                    IntArg1 = 0,
                });
                break;
            case KeyboardKey.A:
                GalagaBus.GetBus().RegisterEvent(new GameEvent<GameEventType>
                {
                    From = this,
                    Message = nameof(MovementDirection.Left),
                    To = _player, //IGameEventProcessor
                    IntArg1 = 0,
                });
                break;
            case KeyboardKey.S:
                GalagaBus.GetBus().RegisterEvent(new GameEvent<GameEventType>
                {
                    From = this,
                    Message = nameof(MovementDirection.Backward),
                    To = _player, //IGameEventProcessor
                    IntArg1 = 0,
                });
                break;
            case KeyboardKey.D:
                GalagaBus.GetBus().RegisterEvent(new GameEvent<GameEventType>
                {
                    From = this,
                    Message = nameof(MovementDirection.Right),
                    To = _player, //IGameEventProcessor
                    IntArg1 = 0,
                });
                break;
            case KeyboardKey.Space:
                break;
        }
    }
}