using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;
using DIKUArcade.Physics;

namespace Breakout.Entities;

public class BallEntity : Entity
{
    #region Properties and fields
    // Field for ball's movement speed and direction
    private float _speed;
    private Vec2F _direction;
    // Maximum speed for ball entities
    private const float MaxSpeed = 0.3f;
    
    #endregion
    
    #region Constructor
    // Constructor that intializes player's shape and image by using the base class constructor
    public BallEntity(Shape shape, IBaseImage image, Vec2F direction, float speed) : base(shape, image)
    {
        _direction = direction;
        _speed = 0.01f;
    }
    #endregion
    #region Methods
    
    public void Move()
    {
        // Limit speed of the ball
        if (_direction.Length() > MaxSpeed)
        {
            _direction = Vec2F.Normalize(_direction) * MaxSpeed;
        }
        
        // Sets the ball direction + moves it
        Shape.AsDynamicShape().Direction = _direction;
        Shape.Move();
        
        // Collision with game window
        if (Shape.Position.Y + Shape.Extent.Y > 1)
        {
            _direction.Y *= -1.0f; // Flip Y-direction
        }
        if (Shape.Position.X - Shape.Extent.X < 0 || Shape.Position.X + Shape.Extent.X > 1)
        {
            _direction.X *= -1.0f; // Flip X-direction
        }
    }

   // R.1
    public bool OutOfBounds()
    {
        return Shape.Position.Y + Shape.Extent.Y < 0;
    }

    public bool CollideWithObject(Shape shape)
    {
        var data = CollisionDetection.Aabb(this.Shape.AsDynamicShape(), shape);
        if (data.Collision)
        {
            if (data.CollisionDir == CollisionDirection.CollisionDirLeft ||
                data.CollisionDir == CollisionDirection.CollisionDirRight)
            {
                Shape.Extent.X *= -1.0f;
            } else if (data.CollisionDir == CollisionDirection.CollisionDirUp ||
                       data.CollisionDir == CollisionDirection.CollisionDirDown)
            {
                this.Shape.Extent.Y *= -1.0f;
            }

            return true;
        }

        return false;
    }

    // R.5
    public void Launch()
    {
        _direction = Vec2F.Normalize(_direction);
    }

    #endregion
}