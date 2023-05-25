using Breakout.Entities;
using Breakout.States.GameRunning;
using DIKUArcade.Entities;
using DIKUArcade.Math;

namespace Breakout.Containers;

public class EntityManager
{
    private readonly GameRunningState _state;
    public EntityContainer<BlockEntity> BlockEntities { get; set; }
    public EntityContainer<BallEntity> BallEntities { get; }
    public EntityContainer<PowerUpEntity> PowerUpEntities { get; } = new();
    public PlayerEntity PlayerEntity { get; }

    public EntityManager(GameRunningState state)
    {
        _state = state;
        PlayerEntity = PlayerEntity.Create();
        BlockEntities = new EntityContainer<BlockEntity>();
        BallEntities = new EntityContainer<BallEntity>();
    }

    public void RenderEntities()
    {
        BlockEntities.RenderEntities();
        BallEntities.RenderEntities();
        PlayerEntity.RenderEntity();
        PowerUpEntities.RenderEntities();
    }

    public void Move()
    {
        PlayerEntity.Move();
        BallEntities.Iterate(ball =>
        {
            CollisionProcessor.CheckBlockCollisions(BlockEntities, ball, PlayerEntity, _state);
            CollisionProcessor.CheckBallPlayerCollision(ball, PlayerEntity);
            ball.Move();
            if (ball.OutOfBounds())
            {
                ball.DeleteEntity(); //Iterate lets us mutate the container while iterating
            }
        });
        PowerUpEntities.Iterate(powerUp =>
        {
            bool checkPowerUpPlayerCollision = CollisionProcessor.CheckPowerUpPlayerCollision(powerUp, PlayerEntity);
            powerUp.Move();
            if (checkPowerUpPlayerCollision)
            {
                powerUp.ActivatePowerUp();
                powerUp.DeleteEntity();
            }
            else
            if (powerUp.Shape.Position.Y < 0)
            {
                powerUp.DeleteEntity();
            }
        });
    }

    public void AddBallEntity(BallEntity ballEntity)
    {
        BallEntities.AddEntity(ballEntity);
    }
    
    public void AddBigBallPU()
    {
        BallEntities.Iterate(ball =>
        {
            float newWidth = ball.Shape.Extent.X * 1.5f;
            float newHeight = ball.Shape.Extent.Y * 1.5f;
            ball.Shape.Extent = new Vec2F(newWidth, newHeight);
        });
    }
    
    public void AddSplitBallPU()
    {
        List<BallEntity> newBalls = new List<BallEntity>();
        
        BallEntities.Iterate(ball =>
        {
            BallEntity newBall1 = new BallEntity(
                new DynamicShape(ball.Shape.Position.Copy(), ball.Shape.Extent.Copy()), ball.Image, ball.GetDirection(), 0.03f, false);
            BallEntity newBall2 = new BallEntity(
                new DynamicShape(ball.Shape.Position.Copy(), ball.Shape.Extent.Copy()), ball.Image, ball.GetDirection(), 0.03f, false);
            
            newBall1.Shape.Position += new Vec2F(0.1f, 0f);
            newBall2.Shape.Position -= new Vec2F(0.1f, 0f);
            
            newBalls.Add(newBall1);
            newBalls.Add(newBall2);
        });
        
        foreach (var newBall in newBalls)
        {
            BallEntities.AddEntity(newBall);
        }
    }

}