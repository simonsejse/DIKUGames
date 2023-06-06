using Breakout.Containers;
using Breakout.Entities;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;
using System.Timers;

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
            _entityManager.BallEntities.Iterate(newBalls.Add);

            newBalls.ForEach(ball =>
            {
                ball.Image = ball.HardBallImage;
                ball.HardBallMode = true;
            });
            

            Task.Delay(5000).ContinueWith(_ =>
            {
                newBalls.ForEach(ball =>
                {
                    ball.Image = ball.DefaultBallImage;
                    ball.HardBallMode = false;
                });
            });
        }

    }
}