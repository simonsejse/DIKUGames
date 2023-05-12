using Breakout.Entities.BlockBehaviors;

namespace Breakout.Entities.BlockTypes;

public class PowerUpBlockType : IBlockType
{
    public IBlockTypeBehavior GetBlockTypeBehavior() => new PowerUpBlockTypeBehaviour();

    public void CollisionHandler(BlockEntity block)
    {
        // not a part of the assignment (9G)
    }
}