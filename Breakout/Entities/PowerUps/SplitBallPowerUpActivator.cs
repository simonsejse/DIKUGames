using Breakout.Containers;
using Breakout.PowerUps;
using DIKUArcade.Entities;

namespace Breakout.Entities.PowerUps;

public class SplitBallPowerUpActivator : IPowerUpActivator
{
    private readonly EntityManager _entityManager;

    public SplitBallPowerUpActivator(EntityManager entityManager)
    {
        _entityManager = entityManager;
    }
    
    public void ActivatePowerUp()
    {
        _entityManager.AddSplitBallPU();
    }
}