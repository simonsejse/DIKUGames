using Breakout.Entities;
using DIKUArcade.Math;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;


namespace Breakout.Entities;

public class BallEntity : Entity
{

    // Field for ball's movement speed and direction
    private float _speed;
    private Vec2F _direction;
    // Maximum speed for ball entities
    private const float MaxSpeed = 0.25f;

    // Constructor that intializes player's shape and image by using the base class constructor
    public BallEntity(Shape shape, IBaseImage image, Vec2F direction, float speed) : base(shape, image)
    {
        _direction = direction;
        _speed = speed;
    }

    
    public void Move()
    {
        // Limit speed of the ball
        if (_direction.Length() > MaxSpeed)
        {
            _direction = Vec2F.Normalize(_direction) * _speed;
        }

        Vec2F movement = _direction * _speed;

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
    public void BounceOffBlock(BlockEntity block)
    {
        float ballCenterX = Shape.Position.X + Shape.Extent.X / 2;
        float ballCenterY = Shape.Position.Y + Shape.Extent.Y / 2;
        float blockCenterX = block.Shape.Position.X + block.Shape.Extent.X / 2;
        float blockCenterY = block.Shape.Position.Y + block.Shape.Extent.Y / 2;
        float blockHeight = 0.08333333333f / 2;
        float targetY = 0.689999964f;

        float deltaX = ballCenterX - blockCenterX;
        float deltaY = ballCenterY - blockCenterY;

        if (Math.Abs(deltaX) < 0.5f && Math.Abs(deltaY) < 0.5f)
        {
            float minY = targetY - blockHeight - 0.03f;
            float maxY = targetY + blockHeight + 0.03f;
            
            if (Shape.Position.Y >= minY && Shape.Position.Y <= maxY)
            {
                float targetX = (Shape.Position.Y - targetY) * (2 / blockHeight);
                
                if (Math.Abs(Shape.Position.X - targetX) < 0.03f)
                {
                    _direction.X *= -1.0f;
                    _direction.Y *= -1.0f;
                    return;
                }
            }
        }
        
    if (deltaY < 0 && _direction.Y > 0)
    {
        _direction.X *= 1.0f;
        _direction.Y *= -1.0f; 
        
    }
    else if (deltaY > 0 && _direction.Y < 0)
    {
        _direction.Y *= -1.0f;
    }
    else
    {
        _direction.X *= -1.0f;
    }
}




    
    public void CheckBlockCollisions(EntityContainer<BlockEntity> blockEntities,
        PlayerEntity playerEntity)
    {
        bool blockCollision = false;

        blockEntities.Iterate(block =>
        {
            if (!blockCollision && DIKUArcade.Physics.CollisionDetection.Aabb(Shape.AsDynamicShape(), block.Shape).Collision)
            {
                blockCollision = true;
                block.CollisionHandler();
                BounceOffBlock(block);
                if (block.IsDead())
                {
                    playerEntity.AddPoints(block.Value);
                }
            }
        });
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
    /// <param name="direction">The direction of the ball.</param>
    /// <param name="speed">The speed of the ball.</param>
    /// <returns>A BallEntity instance</returns>
    public static BallEntity Create(float speed, Vec2F direction)
    {
        return new BallEntity(
            new DynamicShape(ConstantsUtil.BallPosition, ConstantsUtil.BallExtent),
            new Image(Path.Combine("Assets", "Images", "Ball.png")), direction, speed);
    }
    
}