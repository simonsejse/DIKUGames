using DIKUArcade.Entities;

namespace Breakout.Entities;


public static class EntityRenderer
{
    #region Methods
    /// <summary>
    /// Renders all entities contained within the entityContainer object
    /// </summary>
    /// <param name="entityContainer">>The EntityContainer object containing the entities to be rendered</param>
    /// <typeparam name="T">The type of Entity contained within the EntityContainer object</typeparam>
    public static void RenderEntities<T>(EntityContainer<T> entityContainer) where T : Entity
    {
        entityContainer.RenderEntities();
    }
    #endregion
}