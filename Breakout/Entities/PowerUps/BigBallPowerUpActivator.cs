using Breakout.Containers;
using Breakout.PowerUps;
using DIKUArcade.Entities;

namespace Breakout.Entities.PowerUps;

public class BigBallPowerUpActivator : IPowerUpActivator
{
    private readonly EntityManager _entityManager;

    public BigBallPowerUpActivator(EntityManager entityManager)
    {
        _entityManager = entityManager;
    }
    
    public void ActivatePowerUp()
    {
        _entityManager.AddBigBallPU();
    }
}