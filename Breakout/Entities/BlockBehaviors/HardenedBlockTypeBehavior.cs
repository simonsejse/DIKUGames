

namespace Breakout.Entities.BlockBehaviors;

public class HardenedBlockTypeBehavior : IBlockTypeBehavior {
    /// <summary>
    /// Modifies the health of a hardened block by doubling it.
    /// </summary>
    /// <param name="health">The current health of the block.</param>
    /// <returns>The modified health of the block.</returns>
    public int ModifyHealth(int health) => health * 2;
}