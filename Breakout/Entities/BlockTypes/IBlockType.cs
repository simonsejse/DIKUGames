using Breakout.Entities.BlockBehaviors;

namespace Breakout.Entities.BlockTypes;

public interface IBlockType
{
    IBlockTypeBehavior GetBlockTypeBehavior();
    void HandleCollision(BlockEntity block);
}
