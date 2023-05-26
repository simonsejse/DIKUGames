using Breakout.Entities.BlockBehaviors;

namespace Breakout.Entities.BlockTypes;

public class PowerUpBlockType : IBlockType
{
    public IBlockTypeBehavior GetBlockTypeBehavior() => new StandardBlockTypeBehaviour();

    public void HandleCollision(BlockEntity block)
    { 
        block.TakeDamage();
        block.DropPowerUp();
    }
}