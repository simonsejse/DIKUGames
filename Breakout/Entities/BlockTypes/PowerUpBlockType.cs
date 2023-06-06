using Breakout.Entities.BlockBehaviors;

namespace Breakout.Entities.BlockTypes;

public class PowerUpBlockType : IBlockType {
    /// <summary>
    /// Retrieves the behavior associated with the power-up block type.
    /// </summary>
    /// <returns>The behavior of the power-up block type.</returns>
    public IBlockTypeBehavior GetBlockTypeBehavior() => new StandardBlockTypeBehaviour();

    /// <summary>
    /// Handles the collision of a power-up block with the player.
    /// </summary>
    /// <param name="block">The block entity involved in the collision.</param>
    public void HandleCollision(BlockEntity block) { 
        block.TakeDamage();
        block.DropPowerUp();
    }
}