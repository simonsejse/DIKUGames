using Breakout.Entities.BlockTypes;
using Breakout.Utility;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;

namespace Breakout.Entities;

public class PowerUpEntity : Entity
{
    private PowerUpEntity(Shape shape, IBaseImage image) : base(shape, image)
    {
        Shape.AsDynamicShape().Direction = new Vec2F(0f, -0.005f);
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
    public static PowerUpEntity Create(Vec2F pos, string image)
    {
        return new PowerUpEntity(
            new DynamicShape(pos, PositionUtil.PowerUpExtent),
            new Image(Path.Combine("Assets", "Images", $"{image}.png"))
        );
    }

    public void Move()
    {
        Shape.Move();
    }
}