using Breakout.Entities.BlockTypes;

namespace Breakout.Entities.BlockBehaviors;

public class StandardBlockTypeBehaviour : IBlockTypeBehavior
{
    public int ModifyHealth(int health) => health;
}