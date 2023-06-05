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

        public async void Activate()
        {
            List<BallEntity> newBalls = new List<BallEntity>();

            _entityManager.BallEntities.Iterate(ball =>
            {
                var ballEntity1 = ball.HardBall();
                ballEntity1.HardBallMode = true; 
                newBalls.Add(ballEntity1);
                ball.MarkForDeletion();
            });

            newBalls.ForEach(newBall =>
            {
                _entityManager.BallEntities.AddEntity(newBall);
            });

            await Task.Delay(5000);

            Deactivate();
        }
        
        private void Deactivate()
        {
            List<BallEntity> reversedBalls = new List<BallEntity>();

            _entityManager.BallEntities.Iterate(ball =>
            {
                //BallEntity reversedBall = ball.ReverseHardBall();
                ball.HardBallMode = false;
                //reversedBalls.Add(reversedBall);
            });

            /*reversedBalls.ForEach(reversedBall =>
            {
                _entityManager.BallEntities.AddEntity(reversedBall);
            });*/
        }


    }
}