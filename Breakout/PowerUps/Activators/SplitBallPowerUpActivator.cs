using Breakout.Containers;
using Breakout.Entities;
using DIKUArcade.Entities;
using DIKUArcade.Math;

namespace Breakout.PowerUps;

public class SplitBallPowerUpActivator : IPowerUpActivator
{
    private readonly EntityManager _entityManager;

    public SplitBallPowerUpActivator(EntityManager entityManager)
    {
        _entityManager = entityManager;
    }
    
    public void Activate()
    {
        //Each ball on the screen splits into three new balls which each travels in a new direction.
        _entityManager.BallEntities.Iterate(ball =>
        {
            BallEntity newBall1 = new BallEntity(
                new DynamicShape(ball.Shape.Position.Copy(), ball.Shape.Extent.Copy()), ball.Image, new Vec2F(GenerateRandomAngle(), GenerateRandomAngle()), 0.03f, false);
            BallEntity newBall2 = new BallEntity(
                new DynamicShape(ball.Shape.Position.Copy(), ball.Shape.Extent.Copy()), ball.Image, new Vec2F(GenerateRandomAngle(), GenerateRandomAngle()), 0.03f, false);
            BallEntity newBall3 = new BallEntity(
                new DynamicShape(ball.Shape.Position.Copy(), ball.Shape.Extent.Copy()), ball.Image, new Vec2F(GenerateRandomAngle(), GenerateRandomAngle()), 0.03f, false);
            
            //All balls should travel in a new direction

            _entityManager.BallEntities.AddEntity(newBall1);
            _entityManager.BallEntities.AddEntity(newBall2);
            _entityManager.BallEntities.AddEntity(newBall3);
        });
    }
    
    private readonly Random random = new Random();
    private float GenerateRandomAngle()
    {
        return (float)(random.NextDouble() * 360f) / 360f;
    }
}