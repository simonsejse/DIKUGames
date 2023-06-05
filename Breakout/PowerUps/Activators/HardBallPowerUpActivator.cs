using Breakout.Containers;
using Breakout.Entities;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;

namespace Breakout.PowerUps.Activators
{
    public class HardBallPowerUpActivator : IPowerUpActivator
    {
        private readonly EntityManager _entityManager;

        public HardBallPowerUpActivator(EntityManager entityManager)
        {
            _entityManager = entityManager;
        }

    public void Activate()
    {
        List<BallEntity> newBalls = new List<BallEntity>();

        _entityManager.BallEntities.Iterate(ball =>
        {
            var ballEntity1 = ball.HardBall();
            ballEntity1.HardBallMode = true; // Set the flag to true for the new ball
            newBalls.Add(ballEntity1);
            ball.MarkForDeletion();
        });

        newBalls.ForEach(newBall =>
        {
            _entityManager.BallEntities.AddEntity(newBall);
        });
    }




    }
}