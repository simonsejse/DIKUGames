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
    public EntityContainer<GameModifierEntity> PowerUpEntities { get; } = new();
    public EntityContainer<GameModifierEntity> HazardEntities { get; } = new();
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
        HazardEntities.RenderEntities();
    }

    /// <summary>
    /// Moves the player, balls, power-ups and hazards, and performs collision checks and updates.
    /// </summary>

    public void Move()
    {
        PlayerEntity.Move();
        
        BallEntities.Iterate(ball =>
        {
            CollisionProcessor.CheckBlockCollisions(BlockEntities, ball, PlayerEntity, _state);
            CollisionProcessor.CheckBallPlayerCollision(ball, PlayerEntity);
            CollisionProcessor.CheckBallCollisions(ball,BallEntities);
            ball.Move();
            if (ball.OutOfBounds())
            {
                ball.MarkForDeletion();
            }
            
        });
        
        BallEntities.Iterate(ball =>
        {
            if (ball.IsMarkedForDeletion())
            {
                ball.DeleteEntity();
            }
        });
        
        PowerUpEntities.Iterate(powerUp =>
        {
            bool checkPowerUpPlayerCollision = CollisionProcessor.CheckGameModifierEntityPlayerCollision(powerUp, PlayerEntity);
            powerUp.Move();
            if (checkPowerUpPlayerCollision)
            {
                powerUp.ActivatePowerUp();
                _state.UpdateText();
                powerUp.DeleteEntity();
            }
            else
            if (powerUp.Shape.Position.Y < 0)
            {
                powerUp.DeleteEntity();
            }
        });
        
        HazardEntities.Iterate(hazard =>
        {
            bool checkHazardPlayerCollision = CollisionProcessor.CheckGameModifierEntityPlayerCollision(hazard, PlayerEntity);
            hazard.Move();
            if (checkHazardPlayerCollision)
            {
                hazard.ActivateHazard();
                _state.UpdateText();
                hazard.DeleteEntity();
            }
            else
            if (hazard.Shape.Position.Y < 0)
            {
                hazard.DeleteEntity();
            }
        });
    }

    /// <summary>
    /// Adds a ball entity to the ball entity container.
    /// </summary>
    /// <param name="ballEntity">The ball entity to be added.</param>
    public void AddBallEntity(BallEntity ballEntity)
    {
        BallEntities.AddEntity(ballEntity);
    }

}