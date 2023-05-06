using DIKUArcade.Math;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;

namespace Breakout.Entities.BlockTypes;

public interface IBlockType
{
    void CollisionHandler(BlockEntity block);
}