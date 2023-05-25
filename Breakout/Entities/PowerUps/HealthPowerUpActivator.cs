using Breakout.PowerUps;

namespace Breakout.Entities.PowerUps;

public class HealthPowerUpActivator : IPowerUpActivator
{
    private readonly PlayerEntity _playerEntity;

    public HealthPowerUpActivator(PlayerEntity playerEntity)
    {
        _playerEntity = playerEntity;
    }
    
    public void ActivatePowerUp()
    {
        _playerEntity.AddLife();
    }
}