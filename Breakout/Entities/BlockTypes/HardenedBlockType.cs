namespace Breakout.Entities.BlockTypes;

/// <summary>
/// Defines the class for the special block type hardened block from the interface IBlockTypes
/// The block should have more health than the other block types
/// </summary>
public class HardenedBlockType : IBlockType 
{
    #region Methods
    /// <summary>
    /// A method handling what happens when a collision is detected
    /// </summary>
    /// <param name="block">The blockentity</param>
    public void CollisionHandler(BlockEntity block) 
    {
        block.TakeDamage();
        if (block.Health <= (block.StartHealth / 2))
        {
            /// Changes the block image to the damaged version, if the block is half health or below
            block.Image = block.Image2;
        }
    }

    #endregion
}