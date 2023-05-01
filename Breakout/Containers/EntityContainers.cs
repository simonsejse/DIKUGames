using Breakout.Entities;
using DIKUArcade.Entities;

namespace Breakout.Containers;

public class EntityContainers
{
    private readonly EntityRenderer _entityRenderer;
    public EntityContainer<BlockEntity> BlockEntities { get; set; }
    
    public EntityContainers()
    {
        _entityRenderer = new EntityRenderer();
        BlockEntities = new EntityContainer<BlockEntity>();
    }

    public void RenderEntities()
    {
        _entityRenderer.RenderEntities(BlockEntities);
    }
}