using Breakout.Containers;
using Breakout.Entities;

namespace Breakout.GameModifiers.PowerUps.Activators;

/// <summary>
/// Represents an activator for the Hard Ball power-up.
/// </summary>
public class HardBallPowerUpActivator : IGameModifierActivator {
    private readonly EntityManager _entityManager;

    /// <summary>
    /// Initializes a new instance of the HardBallPowerUpActivator class.
    /// </summary>
    /// <param name="entityManager">The EntityManager instance.</param>
    public HardBallPowerUpActivator(EntityManager entityManager) {
        _entityManager = entityManager;
    }

    /// <summary>
    /// Activates the Hard Ball power-up.
    /// </summary>
    public void Activate() {
        List<BallEntity> balls = new();
        _entityManager.BallEntities.Iterate(balls.Add);

        balls.ForEach(ball => {
            ball.Image = ball.HardBallImage;
            ball.HardBallMode = true;
        });

        Task.Delay(5000).ContinueWith(_ => {
            balls.ForEach(ball =>
            {
                ball.Image = ball.DefaultBallImage;
                ball.HardBallMode = false;
            });
        });
    }
}