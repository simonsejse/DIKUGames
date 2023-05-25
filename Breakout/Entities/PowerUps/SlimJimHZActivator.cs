using Breakout.PowerUps;

namespace Breakout.Entities.PowerUps;

public class SlimJimHZActivator : IPowerUpActivator
{
    private readonly PlayerEntity _playerEntity;

    public SlimJimHZActivator(PlayerEntity playerEntity)
    {
        _playerEntity = playerEntity;
    }
    
    public void ActivatePowerUp()
    {
        _playerEntity.AddSlimJimHZ();
    }
}