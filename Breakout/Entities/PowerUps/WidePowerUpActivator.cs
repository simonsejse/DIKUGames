using Breakout.PowerUps;

namespace Breakout.Entities.PowerUps;

public class WidePowerUpActivator : IPowerUpActivator
{
    private readonly PlayerEntity _playerEntity;

    public WidePowerUpActivator(PlayerEntity playerEntity)
    {
        _playerEntity = playerEntity;
    }
    
    public void ActivatePowerUp()
    {
        _playerEntity.AddWidePU();
    }
}