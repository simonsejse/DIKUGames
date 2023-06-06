using Breakout.Events;
using Breakout.GameModifiers;
using Breakout.Hazard;
using Breakout.PowerUps;
using Breakout.Utility;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;

namespace Breakout.Entities;

public class GameModifierEntity : Entity
{
    private readonly IGameModifierActivator _gameModifierActivator;
    
    private GameModifierEntity(Shape shape, IBaseImage image, IGameModifierActivator gameModifierActivator) : base(shape, image)
    {
        _gameModifierActivator = gameModifierActivator;
        Shape.AsDynamicShape().Direction = new Vec2F(0f, -0.005f);
    }

    /// <summary>
    /// A factory method for instantiating a default BlockEntity
    /// </summary>
    /// <returns>A BlockEntity instance</returns>
    /// <param name="pos">The position of the block.</param>
    /// <param name="image">The image of the block.</param>
    /// <param name="gameModifierActivator"></param>
    /// <returns></returns>
    public static GameModifierEntity Create(Vec2F pos, IBaseImage image, IGameModifierActivator gameModifierActivator)
    {
        return new GameModifierEntity(
            new DynamicShape(pos, PositionUtil.PowerUpExtent),
            image,
            gameModifierActivator
        );
    }
    /// <summary>
    /// Moves the GameModifierEntity associated with this object.
    /// </summary>
    public void Move()
    {
        Shape.Move();
    }

    /// <summary>
    /// Activates the GameModifierEntity's effect.
    /// </summary>
    public void ActivateModifier()
    {
        _gameModifierActivator.Activate();
    }
}
