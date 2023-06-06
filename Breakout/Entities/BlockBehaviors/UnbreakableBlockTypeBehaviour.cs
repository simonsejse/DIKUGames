using Breakout.Entities.BlockTypes;

namespace Breakout.Entities.BlockBehaviors;

public class UnbreakableBlockTypeBehaviour : IBlockTypeBehavior {
    /// <summary>
    /// Modifies the health of an unbreakable block by negating it meaning no change has been made and therefore cannot be broken.
    /// </summary>
    /// <param name="health">The current health of the block.</param>
    /// <returns>The modified health of the block (negated).</returns>
    public int ModifyHealth(int health) => health * -1;
}