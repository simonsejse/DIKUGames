using Breakout.Entities.BlockBehaviors;

namespace Breakout.Entities.BlockTypes;

/// <summary>
/// This is the standard block type
/// </summary>
public class StandardBlockType : IBlockType 
{
    #region Methods

    public IBlockTypeBehavior GetBlockTypeBehavior() => new StandardBlockTypeBehaviour();

    /// <summary>
    /// A method of handling collision between the block and the ball entity
    /// </summary>
    /// <param name="block">The blockentity</param>
    public void CollisionHandler(BlockEntity block) 
    {
        block.TakeDamage();
    }
    #endregion
}