﻿using Breakout.Entities;
using Breakout.States;
using Breakout.Utility;
using DIKUArcade.Math;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Physics;


namespace Breakout.Entities;

/// <summary>
/// Represents a ball entity in the Breakout game.
/// </summary>
public class BallEntity : Entity
{
    /// <summary>
    /// Gets or sets a value indicating whether the ball is stuck.
    /// </summary>
    public bool IsBallStuck { get; set; }
    
    
    private float _speed;
    private Vec2F _direction;
    private const float MaxSpeed = 0.25f;

    /// <summary>
    /// Initializes a new instance of the BallEntity class.
    /// </summary>
    /// <param name="shape">The shape of the ball.</param>
    /// <param name="image">The image of the ball.</param>
    /// <param name="direction">The initial direction of the ball.</param>
    /// <param name="speed">The speed of the ball.</param>
    /// <param name="isBallStuck">A value indicating whether the ball is stuck.</param>
    public BallEntity(Shape shape, IBaseImage image, Vec2F direction, float speed, bool isBallStuck) : base(shape, image)
    {
        _direction = direction;
        _speed = speed;
        this.IsBallStuck = isBallStuck;
    }
    
    /// <summary>
    /// Moves the ball based on its current direction and speed.
    /// </summary>
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

    /// <summary>
    /// Checks if the ball is out of bounds.
    /// </summary>
    /// <returns>True if the ball is out of bounds; otherwise, false.</returns>
    public bool OutOfBounds()
    {
        return Shape.Position.Y + Shape.Extent.Y < 0;
    }
    
    /// <summary>
    /// Checks if the ball is out of bounds.
    /// </summary>
    /// <returns>True if the ball is out of bounds; otherwise, false.</returns>
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
            case CollisionDirection.CollisionDirUnchecked:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(collisionDir), collisionDir, null);
        }
    }
    
    /// <summary>
    /// Changes the direction of the ball entity.
    /// </summary>
    /// <param name="deltaX">The change in the X-direction.</param>
    /// <param name="deltaY">The change in the Y-direction.</param>
    public void ChangeDirection(float deltaX, float deltaY)
    {
        _direction.X = deltaX;
        _direction.Y = deltaY;
    }
    /// <summary>
    /// Sets the direction of the ball entity.
    /// </summary>
    /// <param name="direction">The direction vector.</param>
    public void SetDirection(Vec2F direction)
    {
        _direction = direction;
    }
    /// <summary>
    /// Gets the direction of the ball entity.
    /// </summary>
    /// <returns>The direction vector.</returns>
    public Vec2F GetDirection()
    {
        return _direction;
    }
    
    /// <summary>
    /// Launches the ball entity by normalizing its direction vector.
    /// </summary>
    public void Launch()
    {
        _direction = Vec2F.Normalize(_direction);
    }

    /// <summary>
    /// Multiplies the extent of the ball entity by a factor.
    /// </summary>
    /// <param name="factor">The scalar factor.</param>
    public void MultiplyExtent(Vec2F factor)
    {
        Shape.Extent *= factor;
    }

    
    /// <summary>
    /// Factory method for creating new instances of the BallEntity class.
    /// </summary>
    /// <param name="pos">The position of the ball entity.</param>
    /// <param name="extent">The extent of the ball entity.</param>
    /// <param name="speed">The speed of the ball entity.</param>
    /// <param name="direction">The direction of the ball entity.</param>
    /// <param name="isBallStuck">A value indicating whether the ball is stuck.</param>
    /// <returns>A BallEntity instance.</returns>
    public static BallEntity Create(Vec2F pos, Vec2F extent, float speed, Vec2F direction, bool isBallStuck)
    {
        return new BallEntity(
            new DynamicShape(pos, extent),
            new Image(Path.Combine("Assets", "Images", "Ball.png")), direction, speed, isBallStuck);
    }

    public static BallEntity Clone()
    {
        
    }
    
    
}