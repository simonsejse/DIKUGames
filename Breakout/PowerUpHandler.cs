using System.Dynamic;
using Breakout.Entities;
using Breakout.Entities.PowerUps;
using DIKUArcade.Entities;
using DIKUArcade.Events;
using DIKUArcade.Events.Generic;

namespace Breakout;

public class PowerUpHandler : IGameEventProcessor<GameEventType>
{
    private readonly PlayerEntity _playerEntity;
    private readonly EntityContainer<BallEntity> _ballEntity;

    public PowerUpHandler(PlayerEntity playerEntity, EntityContainer<BallEntity> ballEntity)
    {
        _playerEntity = playerEntity;
        _ballEntity = ballEntity;
    }

    public void ProcessEvent(GameEvent<GameEventType> gameEvent)
    {
        switch (gameEvent.ObjectArg1)
        {
            case ExtraLifePowerUp:
                _playerEntity.AddLife();
                break;
        }
    }
}