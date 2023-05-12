using Breakout.Entities.BlockTypes;

namespace Breakout.Entities.BlockBehaviors;

public class UnbreakableBlockTypeBehaviour : IBlockTypeBehavior
{
    public int ModifyHealth(int health) => health * -1;
}