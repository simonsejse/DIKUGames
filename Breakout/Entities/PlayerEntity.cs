

using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;

namespace Breakout.Entites;


public class PlayerEntity : Entity
{
    private float _moveLeft = 0.0f;
    private float _moveRight = 0.0f;
    private float _movementSpeed = 0.03f;
    
    public PlayerEntity(Shape shape, IBaseImage image) : base(shape, image)
    {

    }

    private void UpdateDirection()
    {
        var x = _moveLeft + _moveRight;
        Shape.AsDynamicShape().Direction = new Vec2F(x, 0);
    }

    public void Move()
    {
        if (Shape.Position.X < 0){
            SetMoveLeft(false);
        }
        if (Shape.Position.X > 0.9){
            SetMoveRight(false);
        }
        Shape.Move();
    }

    public void SetMoveLeft(bool val)
    {
        _moveLeft = val ? _moveLeft - _movementSpeed : 0f;
        UpdateDirection();
    }

    public void SetMoveRight(bool val)
    {
        _moveRight = val ? _moveRight + _movementSpeed : 0f;
        UpdateDirection();
    }

}
