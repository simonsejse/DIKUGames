using Breakout.Entities;
using Breakout.Entities.PowerUps;
using DIKUArcade.Events;
using DIKUArcade.Events.Generic;

namespace Breakout;

public class PowerUpHandler : IGameEventProcessor<GameEventType>
{
    private readonly PlayerEntity _playerEntity;

    public PowerUpHandler(PlayerEntity playerEntity)
    {
        _playerEntity = playerEntity;
    }

    public void ProcessEvent(GameEvent<GameEventType> gameEvent)
    {
        switch (gameEvent.ObjectArg1)
        {
            case ExtraLifePowerUp:
                // _playerEntity.AddLife();
                break;
        }
    }
}