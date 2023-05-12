using Breakout.Entities.BlockBehaviors;

namespace Breakout.Entities.BlockTypes;

public interface IBlockType
{
    IBlockTypeBehavior GetBlockTypeBehavior();
    void CollisionHandler(BlockEntity block);
}
