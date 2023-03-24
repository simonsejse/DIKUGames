using DIKUArcade.Entities;

namespace Galaga.MovementStrategy;

public interface IMovementStrategy
{
    void MoveEnemy (Enemy enemy);
    void MoveEnemies (EntityContainer<Enemy> enemies);
}