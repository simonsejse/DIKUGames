namespace Breakout.Entities.BlockTypes;

public interface IBlockType
{
    void CollisionHandler(BlockEntity block);
}