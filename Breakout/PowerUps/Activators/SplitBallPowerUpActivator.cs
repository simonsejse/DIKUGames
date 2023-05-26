using Breakout.Containers;
using Breakout.Entities;

namespace Breakout.PowerUps.Activators;

public class SplitBallPowerUpActivator : IPowerUpActivator
{
    private readonly EntityManager _entityManager;

    public SplitBallPowerUpActivator(EntityManager entityManager)
    {
        _entityManager = entityManager;
    }
    
    public void Activate()
    {
        List<BallEntity> newBalls = new();
        //Each ball on the screen splits into three new balls which each travels in a new direction.
        _entityManager.BallEntities.Iterate(ball =>
        {
            //Create three new balls

            var ballEntity1 = ball.Clone();
            var ballEntity2 = ball.Clone();
            
            ballEntity1.Launch();
            ballEntity2.Launch();
            
            newBalls.Add(ballEntity1);
        });
        newBalls.ForEach(_entityManager.BallEntities.AddEntity);
    }
    
    private readonly Random random = new Random();
    private float GenerateRandomAngle()
    {
        return (float)(random.NextDouble() * 360f) / 360f;
    }
}