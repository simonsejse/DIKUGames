using Breakout.Entities;

namespace Breakout.PowerUps.Activators;

public class HealthPowerUpActivator : IPowerUpActivator
{
    private readonly PlayerEntity _playerEntity;

    public HealthPowerUpActivator(PlayerEntity playerEntity)
    {
        _playerEntity = playerEntity;
    }
    
    public void Activate()
    {
        _playerEntity.AddLife();
    }
}