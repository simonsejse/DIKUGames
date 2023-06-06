using Breakout.Entities.BlockBehaviors;

namespace Breakout.Entities.BlockTypes;

public interface IBlockType
{
    IBlockTypeBehavior GetBlockTypeBehavior();
    /// <summary>
    /// Handles the collision of a block with another entity (the ball).
    /// </summary>
    /// <param name="block">The block entity affected by the collision.</param>
    void HandleCollision(BlockEntity block);
}
