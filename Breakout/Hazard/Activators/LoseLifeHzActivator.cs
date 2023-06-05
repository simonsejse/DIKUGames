using Breakout.Entities;
using Breakout.PowerUps;

namespace Breakout.Hazard.Activators;

public class LoseLifeHzActivator : IHazardActivator
{
    private readonly PlayerEntity _playerEntity;

    public LoseLifeHzActivator(PlayerEntity playerEntity)
    {
        _playerEntity = playerEntity;
    }

    public void Activate()
    {
        _playerEntity.TakeLife();
    }
}
