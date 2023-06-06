using Breakout.Containers;
using Breakout.Entities;

namespace Breakout.GameModifiers.PowerUps.Activators;

/// <summary>
/// Represents an activator for the Hard Ball power-up game modifier.
/// </summary>
public class HardBallPowerUpActivator : IGameModifierActivator
{
    private readonly EntityManager _entityManager;
    
    /// <summary>
    /// Initializes a new instance of the <see cref="HardBallPowerUpActivator"/> class with the specified entity manager.
    /// </summary>
    /// <param name="entityManager">The entity manager to access the ball entities.</param>
    public HardBallPowerUpActivator(EntityManager entityManager)
    {
        _entityManager = entityManager;
    }

    /// <summary>
    /// Activates the Hard Ball power-up modifier.
    /// </summary>
    public void Activate()
    {
        List<BallEntity> balls = new();
        _entityManager.BallEntities.Iterate(balls.Add);

        balls.ForEach(ball =>
        {
            ball.Image = ball.HardBallImage;
            ball.HardBallMode = true;
        });
        

        Task.Delay(5000).ContinueWith(_ =>
        {
            balls.ForEach(ball =>
            {
                ball.Image = ball.DefaultBallImage;
                ball.HardBallMode = false;
            });
        });
    }

}
