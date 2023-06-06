using Breakout.Containers;
using Breakout.Entities;

namespace Breakout.GameModifiers.PowerUps.Activators;
public class HardBallPowerUpActivator : IGameModifierActivator
{
    private readonly EntityManager _entityManager;

    public HardBallPowerUpActivator(EntityManager entityManager)
    {
        _entityManager = entityManager;
    }

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
