using DIKUArcade.Entities;

namespace Breakout.Factories;

public interface IEntityFactory<out T> where T : Entity
{
    T Create();
}