using Breakout.Entities;
using Breakout.Entities.BlockTypes;
using DIKUArcade.Entities;

namespace Breakout.Containers;

public class EntityContainers
{
    public EntityContainer<BlockEntity> BlockEntities { get; set; }
    public EntityContainer<BallEntity> BallEntities { get; }
    
    public EntityContainers()
    {
        BlockEntities = new EntityContainer<BlockEntity>();
        BallEntities = new EntityContainer<BallEntity>();
    }

    public void RenderEntities()
    {
        BlockEntities.RenderEntities();
        BallEntities.RenderEntities();
    }
    
    public void AddBallEntity(BallEntity ballEntity)
    {
        BallEntities.AddEntity(ballEntity);
    }
    
}