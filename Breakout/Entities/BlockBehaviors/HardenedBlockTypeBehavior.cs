using Breakout.Entities.BlockTypes;

namespace Breakout.Entities.BlockBehaviors;

public class HardenedBlockTypeBehavior : IBlockTypeBehavior
{
    public int ModifyHealth(int health) => health * 2;
}