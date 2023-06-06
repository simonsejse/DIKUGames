using Breakout.Entities.BlockBehaviors;

namespace Breakout.Entities.BlockTypes;

/// <summary>
/// This is the standard block type
/// </summary>
public class StandardBlockType : IBlockType {

    public IBlockTypeBehavior GetBlockTypeBehavior() => new StandardBlockTypeBehaviour();

    /// <summary>
    /// A method of handling collision between the block and the ball entity
    /// Also drops Hazard-game modifiers.
    /// </summary>
    /// <param name="block">The blockentity</param>
    public void HandleCollision(BlockEntity block) {
        block.TakeDamage();
        block.DropHazard();
    }
}