namespace Breakout.Entities.BlockTypes;

/// <summary>
/// Defines the class for the special block type hardened block from the interface IBlockTypes
/// The block should have more health than the other block types
/// </summary>
public class HardenedBlockType : IBlockType 
{
    #region Methods
    /// <summary>
    /// A method of handling collision between the block and the ball entity
    /// </summary>
    /// <param name="block">The blockentity</param>
    public void CollisionHandler(BlockEntity block) 
    {
        block.TakeDamage();
        if (block.Health <= (block.StartHealth / 2))
        {
            block.Image = block.Image2;
        }
    }

    #endregion
}