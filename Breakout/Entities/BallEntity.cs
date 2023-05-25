using Breakout.Entities;
using Breakout.States;
using Breakout.Utility;
using DIKUArcade.Math;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Physics;


namespace Breakout.Entities;

public class BallEntity : Entity
{
    public bool IsBallStuck { get; set; }
    private float _speed;
    private Vec2F _direction;
    private const float MaxSpeed = 0.25f;

    // Constructor that intializes player's shape and image by using the base class constructor
    public BallEntity(Shape shape, IBaseImage image, Vec2F direction, float speed, bool isBallStuck) : base(shape, image)
    {
        _direction = direction;
        _speed = speed;
        this.IsBallStuck = isBallStuck;
    }
    
    public void Move()
    {
        if (IsBallStuck)
            return;
        
        // Limit speed of the ball
        if (_direction.Length() > MaxSpeed)
        {
            _direction = Vec2F.Normalize(_direction) * _speed;
        }
        
    
        Shape.AsDynamicShape().Direction = _direction;
        Shape.Move();
        
        if (Shape.Position.Y + Shape.Extent.Y > 1)
        {
            _direction.Y *= -1.0f; 
        }
        if (Shape.Position.X - Shape.Extent.X < -0.03f || Shape.Position.X + Shape.Extent.X > 1)
        {
            _direction.X *= -1.0f; 
        }
    }

   // R.1
    public bool OutOfBounds()
    {
        return Shape.Position.Y + Shape.Extent.Y < 0;
    }
    
    public void BounceOffBlock(CollisionDirection collisionDir)
    {
        switch (collisionDir)
        {
            case CollisionDirection.CollisionDirUp:
                _direction.Y *= -1;
                break;
            case CollisionDirection.CollisionDirDown:
                _direction.Y *= -1;
                break;
            case CollisionDirection.CollisionDirLeft:
                _direction.X *= -1;
                break;
            case CollisionDirection.CollisionDirRight:
                _direction.X *= -1;
                break;
        }
    }
    
    public void ChangeDirection(float deltaX, float deltaY)
    {
        _direction.X = deltaX;
        _direction.Y = deltaY;
    }

    public void SetDirection(Vec2F direction)
    {
        _direction = direction;
    }

    public Vec2F GetDirection()
    {
        return _direction;
    }



    // R.5
    public void Launch()
    {
        _direction = Vec2F.Normalize(_direction);
    }

    /// <summary>
    /// A factory method for instantiating a default BallEntity
    /// </summary>
    /// <param name="pos">The position of the ball.</param>
    /// <param name="extent">The extent of the ball.</param>
    /// <param name="speed">The speed of the ball.</param>
    /// <param name="direction">The direction of the ball.</param>
    /// <param name="isBallStuck"></param>
    /// <returns>A BallEntity instance</returns>
    public static BallEntity Create(Vec2F pos, Vec2F extent, float speed, Vec2F direction, bool isBallStuck)
    {
        return new BallEntity(
            new DynamicShape(pos, extent),
            new Image(Path.Combine("Assets", "Images", "Ball.png")), direction, speed, isBallStuck);
    }
    
}