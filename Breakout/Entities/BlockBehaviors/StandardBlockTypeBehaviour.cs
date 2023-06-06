using Breakout.Entities.BlockTypes;

namespace Breakout.Entities.BlockBehaviors;

public class StandardBlockTypeBehaviour : IBlockTypeBehavior
{
    /// <summary>
    /// Modifies the health of a standard block, where the health remains unchanged.
    /// </summary>
    /// <param name="health">The current health of the block.</param>
    /// <returns>The unmodified health of the block.</returns>
    public int ModifyHealth(int health) => health;
}