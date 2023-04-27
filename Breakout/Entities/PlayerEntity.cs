

using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;

namespace Breakout.Entites;

/// <summary>
/// A class that represents the player entity.
/// </summary>
public class PlayerEntity : Entity
{
    #region Properties and fields
    // Field for player's movement and its movement speed
    private float _moveRight = 0.0f;
    private float _moveLeft = 0.0f;
    private const float MovementSpeed = 0.05f;
    #endregion
    
    #region Constructor
    // Constructor that intializes player's shape and image by using the base class constructor
    public PlayerEntity(Shape shape, IBaseImage image) : base(shape, image)
    {

    }
    #endregion

    #region Methods
    // Moves the player left or right based upon their movement fields and speed and updates their position and direction
    // Also restricts position to be within game window limits
    public void Move()
    {
        if (Shape.Position.X < 0f){
            SetMoveLeft(false);
        }
        if (Shape.Position.X > (1.0f - Shape.Extent.X)){
            SetMoveRight(false);
        }
        Shape.Move();
    }
    // Updates the player's direction based upon their movement fields
    private void UpdateDirection()
    {
        var x = _moveLeft + _moveRight;
        Shape.AsDynamicShape().Direction = new Vec2F(x, 0);
    }
    // Sets the movement of the player to Left based upon a boolean value and updates the direction
    public void SetMoveLeft(bool val)
    {
        _moveLeft = val ? _moveLeft - MovementSpeed : 0f;
        UpdateDirection();
    }
    // Sets the movement of the player to Right based upon a boolean value and updates the direction
    public void SetMoveRight(bool val)
    {
        _moveRight = val ? _moveRight + MovementSpeed : 0f;
        UpdateDirection();
    }
    #endregion
}
