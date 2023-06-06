namespace Breakout.Entities.BlockBehaviors;

public interface IBlockTypeBehavior {
    /// <summary>
    /// Modifies the health of the block based on its type.
    /// </summary>
    /// <param name="health">The current health of the block.</param>
    /// <returns>The modified health of the block.</returns>
    int ModifyHealth(int health);
}
