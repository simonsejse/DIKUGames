using Breakout.Containers;
using Breakout.Entities;
using Breakout.Utility;
using DIKUArcade.Entities;
using DIKUArcade.Math;

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
            
            var ballEntity1 = ball.Clone();
            ballEntity1.SetDirection(new Vec2F(GenerateRandomAngle(), GenerateRandomAngle()));
            var ballEntity2 = ball.Clone();
            ballEntity2.SetDirection(new Vec2F(GenerateRandomAngle(), GenerateRandomAngle()));
            var ballEntity3 = ball.Clone();
            ballEntity3.SetDirection(new Vec2F(GenerateRandomAngle(), GenerateRandomAngle()));
            
            newBalls.Add(ballEntity1);
            newBalls.Add(ballEntity2);
            newBalls.Add(ballEntity3);
        });
        newBalls.ForEach(_entityManager.BallEntities.AddEntity);
    }
    
    private readonly Random random = new();
    private float GenerateRandomAngle()
    {
        return (float)(random.NextDouble() * 360f) / 360f;
    }
}