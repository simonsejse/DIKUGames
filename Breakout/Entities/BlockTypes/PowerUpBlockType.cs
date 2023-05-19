using Breakout.Entities.BlockBehaviors;

namespace Breakout.Entities.BlockTypes;

public class PowerUpBlockType : IBlockType
{
    public IBlockTypeBehavior GetBlockTypeBehavior() => new PowerUpBlockTypeBehaviour();

    public void HandleCollision(BlockEntity block)
    {
        block.PowerUpType.DropPowerUp();
    }
}