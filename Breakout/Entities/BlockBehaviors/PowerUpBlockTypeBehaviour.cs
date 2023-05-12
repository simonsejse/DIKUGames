using Breakout.Entities.BlockTypes;

namespace Breakout.Entities.BlockBehaviors;

public class PowerUpBlockTypeBehaviour : IBlockTypeBehavior
{
    public int ModifyHealth(int health) => health;
}