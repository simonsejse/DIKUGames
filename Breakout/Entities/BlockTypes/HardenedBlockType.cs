using Breakout.Entities.BlockBehaviors;

namespace Breakout.Entities.BlockTypes;

/// <summary>
/// Defines the class for the special block type hardened block from the interface IBlockTypes
/// The block should have more health than the other block types
/// </summary>
public class HardenedBlockType : IBlockType
{
    public IBlockTypeBehavior GetBlockTypeBehavior() => new HardenedBlockTypeBehavior();

    /// <summary>
    /// A method handling what happens when a collision is detected
    /// </summary>
    /// <param name="block">The blockentity</param>
    public void HandleCollision(BlockEntity block) 
    {
        block.TakeDamage();
        if (block.Health > block.StartHealth / 2) return;
        if (block.Image.Equals(block.Image2)) return;
        block.Image = block.Image2;
    }
}