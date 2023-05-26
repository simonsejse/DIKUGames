using System.Dynamic;
using Breakout.Entities;
using Breakout.PowerUps;
using Breakout.PowerUps.Activators;
using Breakout.States.GameRunning;
using DIKUArcade.Entities;
using DIKUArcade.Events;
using DIKUArcade.Events.Generic;

namespace Breakout;

//TODO: Other alternative power up implementation, not currently used
public class PowerUpHandler : IGameEventProcessor<GameEventType>
{
    private readonly PlayerEntity _playerEntity;
    private readonly EntityContainer<BallEntity> _ballEntity;
    
    
    private readonly Dictionary<PowerUpType, IPowerUpActivator> _powerUpActivators;
    
    public PowerUpHandler(PlayerEntity playerEntity, EntityContainer<BallEntity> ballEntity)
    {
        _playerEntity = playerEntity;
        _ballEntity = ballEntity;
        _powerUpActivators = new Dictionary<PowerUpType, IPowerUpActivator>
        {
            { PowerUpType.ExtraLifePowerUp, new HealthPowerUpActivator(_playerEntity)}
        };
    }

    public void ProcessEvent(GameEvent<GameEventType> gameEvent)
    {
        if (gameEvent.EventType is not GameEventType.StatusEvent) return;
        _powerUpActivators.First(kv => kv.Key.ToString().Equals(gameEvent.StringArg1)).Value.Activate();
    }
}