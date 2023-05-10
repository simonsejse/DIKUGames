using Breakout.Entities;
using DIKUArcade.Math;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;


namespace Breakout.Entites;

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

    private void BounceOffBlock(BlockEntity block)
    {
        float ballCenterY = Shape.Position.Y + Shape.Extent.Y / 2;
        float blockCenterY = block.Shape.Position.Y + block.Shape.Extent.Y / 2;

        float deltaY = ballCenterY - blockCenterY;
        _direction.X *= 1.0f;

        // Adjust the Y direction based on the position relative to the block
        if (deltaY < 0 && _direction.Y > 0)
        {
            _direction.Y *= -1.0f; // Bounce upwards
        }
        else if (deltaY > 0 && _direction.Y < 0)
        {
            _direction.Y *= -1.0f; // Bounce downwards
        }
        else
        {
            _direction.X *= -1.0f; // Only change the X direction
        }
    }
    
    public void CheckBlockCollisions(BallEntity ballEntity, EntityContainer<BlockEntity> blockEntities)
    {
        bool blockCollision = false; // Flag to track if a block has been deleted during a collision

        blockEntities.Iterate(block =>
        {
            if (!blockCollision && DIKUArcade.Physics.CollisionDetection.Aabb(ballEntity.Shape.AsDynamicShape(), block.Shape).Collision)
            {
                blockCollision = true;
                block.Health--;
                if (block.Health > 0)
                {
                    ballEntity.BounceOffBlock(block);
                    block.DeleteEntity();
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

    public void RotateDirection(float angle)
    {
        float radians = angle * (float)Math.PI / 180.0f;

        float newX = _direction.X * (float)Math.Cos(radians) - _direction.Y * (float)Math.Sin(radians);
        float newY = _direction.X * (float)Math.Sin(radians) + _direction.Y * (float)Math.Cos(radians);

        _direction.X = newX;
        _direction.Y = newY;
    }

    private bool CheckCollision(BallEntity ballEntity, BlockEntity block)
    {
        var ballShape = ballEntity.Shape.AsDynamicShape();
        var blockShape = block.Shape.AsDynamicShape();

        return DIKUArcade.Physics.CollisionDetection.Aabb(ballShape, blockShape).Collision;
    }

    // R.5
    public void Launch()
    {
        _direction = Vec2F.Normalize(_direction);
    }

    #endregion
}