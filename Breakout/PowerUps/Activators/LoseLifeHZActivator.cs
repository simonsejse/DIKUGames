using Breakout.PowerUps;

namespace Breakout.Entities.PowerUps;

public class LoseLifeHZActivator : IPowerUpActivator
{
    private readonly PlayerEntity _playerEntity;

    public LoseLifeHZActivator(PlayerEntity playerEntity)
    {
        _playerEntity = playerEntity;
    }
    
    public void Activate()
    {
        _playerEntity.TakeLife();
    }
}