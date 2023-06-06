using Breakout.Containers;
using Breakout.Entities;
using DIKUArcade.Math;

namespace Breakout.GameModifiers.PowerUps.Activators;

/// <summary>
/// Represents an activator for the Split Ball power-up.
/// </summary>
public class SplitBallGameModifierActivator : IGameModifierActivator {
    private readonly EntityManager _entityManager;

    /// <summary>
    /// Initializes a new instance of the SplitBallPowerUpActivator class.
    /// </summary>
    /// <param name="entityManager">The EntityManager instance.</param>
    public SplitBallGameModifierActivator(EntityManager entityManager) {
        _entityManager = entityManager;
    }
    
    /// <summary>
    /// Activates the Split Ball power-up by splitting each ball into three new balls,
    /// each traveling in a new direction.
    /// </summary>
    public void Activate() {
        List<BallEntity> newBalls = new();
        //Each ball on the screen splits into three new balls which each travels in a new direction.
        _entityManager.BallEntities.Iterate(ball => {
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
    
    /// <summary>
    /// Generates a random angle in radians.
    /// </summary>
    /// <returns>A random angle in radians.</returns>
    private readonly Random random = new();
    private float GenerateRandomAngle() {
        return (float)(random.NextDouble() * 360f) / 360f;
    }
}