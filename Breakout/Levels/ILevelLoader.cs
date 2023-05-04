using DIKUArcade.Entities;

namespace Breakout.Levels;

public interface ILevelLoader<T> where T : Entity
{
    public EntityContainer<T> LoadLevel(int levelNum);
}