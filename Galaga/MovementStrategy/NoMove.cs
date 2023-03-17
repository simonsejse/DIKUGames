using DIKUArcade.Entities;

namespace Galaga.MovementStrategy;

public class NoMove : IMovementStrategy
{
    public void MoveEnemy(Enemy enemy)
    {
        //This is breach of the Interface Segregation Principle (ISP)
        //Nothing
    }

    public void MoveEnemies(EntityContainer<Enemy> enemies)
    {
        //Nothing
    }
}