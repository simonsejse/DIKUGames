using System;
using DIKUArcade.Entities;
using DIKUArcade.Math;

namespace Galaga.MovementStrategy;

public class ZigZagDown : IMovementStrategy
{
    private const float P = 0.045f, A = 0.05f;
    public void MoveEnemy(Enemy enemy)
    {
        float yNext = enemy.Shape.Position.Y - enemy.Speed;
        float xNext = (float)(enemy.Xo + A * Math.Sin((2 * Math.PI * (enemy.Yo - yNext))/P));
        enemy.Shape.Position = new Vec2F(xNext, yNext);
    }

    public void MoveEnemies(EntityContainer<Enemy> enemies)
    {
        enemies.Iterate(MoveEnemy);
    }
}