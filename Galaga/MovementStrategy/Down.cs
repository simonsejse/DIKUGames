using DIKUArcade.Entities;
using DIKUArcade.Math;

namespace Galaga.MovementStrategy;

public class Down : IMovementStrategy
{
    public void MoveEnemy(Enemy enemy)
    {
        enemy.Shape.Position += new Vec2F(0, -enemy.Speed);
    }

    public void MoveEnemies(EntityContainer<Enemy> enemies)
    {
        enemies.Iterate(MoveEnemy);
    }
}