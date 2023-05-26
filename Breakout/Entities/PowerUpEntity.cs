using Breakout.Entities.PowerUps;
using Breakout.Events;
using Breakout.PowerUps;
using Breakout.Utility;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;

namespace Breakout.Entities;

public class PowerUpEntity : Entity
{
    private readonly IPowerUpActivator _powerUpActivator;
    
    private PowerUpEntity(Shape shape, IBaseImage image, IPowerUpActivator powerUpActivator) : base(shape, image)
    {
        _powerUpActivator = powerUpActivator;
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
    /// <param name="powerUpActivator"></param>
    /// <returns></returns>
    public static PowerUpEntity Create(Vec2F pos, IBaseImage image, IPowerUpActivator powerUpActivator)
    {
        return new PowerUpEntity(
            new DynamicShape(pos, PositionUtil.PowerUpExtent),
            image,
            powerUpActivator
        );
    }

    public void Move()
    {
        Shape.Move();
    }

    public void ActivatePowerUp()
    {
        
        
        _powerUpActivator.Activate();
        //TODO: the powerupactivator can return an enum like "HealthUp" or "WidePaddle" or "FastBall" or "SlowBall" and then we can use activate
        //BreakoutBus.GetBus().RegisterEvent(null);
    }
}
