using DIKUArcade.Entities;

namespace Breakout.Entities;

public class EntityRenderer
{
    public void RenderEntities<T>(EntityContainer<T> entityContainer) where T : Entity
    {
        entityContainer.RenderEntities();
    }
}