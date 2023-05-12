using Breakout.Entities;
using DIKUArcade.Entities;

namespace Breakout.Containers;

public class EntityManager
{
    public EntityContainer<BlockEntity> BlockEntities { get; set; }
    public EntityContainer<BallEntity> BallEntities { get; }
    public PlayerEntity PlayerEntity { get; }

    public EntityManager()
    {
        PlayerEntity = PlayerEntity.Create();
        BlockEntities = new EntityContainer<BlockEntity>();
        BallEntities = new EntityContainer<BallEntity>();
    }

    public void RenderEntities()
    {
        BlockEntities.RenderEntities();
        BallEntities.RenderEntities();
        PlayerEntity.RenderEntity();
    }

    public void Move()
    {
        PlayerEntity.Move();
        BallEntities.Iterate(ball =>
        {
            ball.CheckBlockCollisions(BlockEntities, PlayerEntity);
            CollisionManager.CheckBallPlayerCollision(ball, PlayerEntity);
            ball.Move();
        });
    }

    public void AddBallEntity(BallEntity ballEntity)
    {
        BallEntities.AddEntity(ballEntity);
    }
    
    public void AddBlockEntity(BlockEntity blockEntity)
    {
        BlockEntities.AddEntity(blockEntity);
    }
    
}