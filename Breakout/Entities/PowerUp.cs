using Breakout.Entities.BlockTypes;
using Breakout.Utility;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;

namespace Breakout.Entities;

public class PowerUp : Entity
{
    public PowerUp(Shape shape, IBaseImage image) : base(shape, image)
    {
    }
    
    /// <summary>
    /// A factory method for instantiating a default BlockEntity
    /// </summary>
    /// <returns>A BlockEntity instance</returns>
    /// <param name="pos">The position of the block.</param>
    /// <param name="image">The image of the block.</param>
    /// <param name="image2">The second image of the block.</param>
    /// <param name="blockType">The type of the block.</param>
    /// <returns></returns>
    public static PowerUp Create(Vec2F pos, string image)
    {
        return new PowerUp(
            new StationaryShape(pos, ConstantsUtil.BlockExtent),
            new Image(Path.Combine("Assets", "Images", $"{image}.png"))
        );
    }

    public void Move()
    {
        //todo: gå nedad
    }
}