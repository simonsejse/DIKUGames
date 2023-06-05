using System.Dynamic;
using Breakout.Entities;
using Breakout.PowerUps;
using Breakout.PowerUps.Activators;
using Breakout.States.GameRunning;
using DIKUArcade.Entities;
using DIKUArcade.Events;
using DIKUArcade.Events.Generic;

namespace Breakout;

/// <summary>
/// Handles power-up events and activates corresponding power-up activators.
/// </summary>
public class PowerUpHandler : IGameEventProcessor<GameEventType>
{
    private readonly PlayerEntity _playerEntity;
    private readonly EntityContainer<BallEntity> _ballEntity;
    
    
    private readonly Dictionary<PowerUpType, IPowerUpActivator> _powerUpActivators;
    
    /// <summary>
    /// Initializes a new instance of the PowerUpHandler class.
    /// </summary>
    /// <param name="playerEntity">The player entity.</param>
    /// <param name="ballEntity">The ball entity container.</param>
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