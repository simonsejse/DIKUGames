

using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;

namespace Breakout.Entites;

/// <summary>
/// A class that represents the player entity.
/// </summary>
public class PlayerEntity : Entity
{
    private float _moveLeft;
    private float _moveRight;
    private const float MovementSpeed = 0.025f;
    
    public PlayerEntity(Shape shape, IBaseImage image) : base(shape, image)
    {

    }


    public void Move()
    {
        if (Shape.Position.X < 0){
            SetMoveLeft(false);
        }
        if (Shape.Position.X > 1.0f - 0.2f){
            SetMoveRight(false);
        }
        Shape.Move();
    }
    
    private void UpdateDirection()
    {
        var x = _moveLeft + _moveRight;
        Shape.AsDynamicShape().Direction = new Vec2F(x, 0);
    }

    public void SetMoveLeft(bool val)
    {
        _moveLeft = val ? _moveLeft - MovementSpeed : 0f;
        UpdateDirection();
    }

    public void SetMoveRight(bool val)
    {
        _moveRight = val ? _moveRight + MovementSpeed : 0f;
        UpdateDirection();
    }

}
