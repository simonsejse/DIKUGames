using Breakout.Entities;
using Breakout.Entites;
using DIKUArcade.Entities;

namespace Breakout.Containers;

public class EntityContainers
{
    private readonly EntityRenderer _entityRenderer;
    public EntityContainer<BlockEntity> BlockEntities { get; set; }
    public EntityContainer<BallEntity> BallEntities { get; }
    
    public EntityContainers()
    {
        _entityRenderer = new EntityRenderer();
        BlockEntities = new EntityContainer<BlockEntity>();
        BallEntities = new EntityContainer<BallEntity>();
    }

    public void RenderEntities()
    {
        _entityRenderer.RenderEntities(BlockEntities);
        _entityRenderer.RenderEntities(BallEntities);
    }
    public void AddBallEntity(BallEntity ballEntity)
    {
        BallEntities.AddEntity(ballEntity);
    }
    
}