﻿using Breakout.Events;
using Breakout.Hazard;
using Breakout.PowerUps;
using Breakout.Utility;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;

namespace Breakout.Entities;

public class GameModifierEntity : Entity
{
    private readonly IPowerUpActivator _powerUpActivator;
    private readonly IHazardActivator _hazardActivator;
    
    private GameModifierEntity(Shape shape, IBaseImage image, IPowerUpActivator powerUpActivator, IHazardActivator hazardActivator) : base(shape, image)
    {
        _powerUpActivator = powerUpActivator;
        _hazardActivator = hazardActivator;
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
    public static GameModifierEntity Create(Vec2F pos, IBaseImage image, IPowerUpActivator powerUpActivator, IHazardActivator hazardActivator)
    {
        return new GameModifierEntity(
            new DynamicShape(pos, PositionUtil.PowerUpExtent),
            image,
            powerUpActivator,
            hazardActivator
        );
    }
    

    public void Move()
    {
        Shape.Move();
    }

    public void ActivatePowerUp()
    {
        _powerUpActivator.Activate();
    }
    
    public void ActivateHazard()
    {
        _hazardActivator.Activate();
    }
}