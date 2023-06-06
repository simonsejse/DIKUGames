using DIKUArcade.Entities;

namespace Breakout.Factories;

/// <summary>
/// Represents an entity factory.
/// </summary>
/// <typeparam name="T">The type of entity created by the factory.</typeparam>
public interface IEntityFactory<out T> where T : Entity
{
    T Create();
}