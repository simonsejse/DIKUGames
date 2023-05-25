

using Breakout.Utility;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;

namespace Breakout.Entities;

/// <summary>
/// A class that represents the player entity.
/// </summary>
public class PlayerEntity : Entity
{
    // Field for player's movement and its movement speed
    private float _moveRight = 0.0f;
    private float _moveLeft = 0.0f;
    private const float MovementSpeed = 0.05f;
    private int _points = 0;
    private int _lives;
    
    // Constructor that intializes player's shape and image by using the base class constructor
    public PlayerEntity(Shape shape, IBaseImage image) : base(shape, image)
    {
        _lives = 3;
    }

    /// <summary>
    /// Moves the player left or right based upon their movement fields and speed and updates their position
    /// and direction. Also restricts position to be within game window limits
    /// </summary>
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
    /// <summary>
    /// Updates the player's direction based upon their movement fields
    /// </summary>
    private void UpdateDirection()
    {
        float x = _moveLeft + _moveRight;
        Shape.AsDynamicShape().Direction = new Vec2F(x, 0);
    }
    /// <summary>
    /// Sets the movement of the player to the left based on a boolean value and updates their direction.
    /// </summary>
    /// <param name="val">A boolean value indicating whether the player should move left.</param>
    public void SetMoveLeft(bool val)
    {
        _moveLeft = val ? _moveLeft - MovementSpeed : 0f;
        UpdateDirection();
    }
    /// <summary>
    /// Sets the movement of the player to the right based on a boolean value and updates their direction.
    /// </summary>
    /// <param name="val">A boolean value indicating whether the player should move right.</param>
    public void SetMoveRight(bool val)
    {
        _moveRight = val ? _moveRight + MovementSpeed : 0f;
        UpdateDirection();
    }

    /// <summary>
    /// Adds count points to the player's points. If the added points are not positive, do nothing
    /// </summary>
    /// <param name="count">Integer for the added points.</param>
    public void AddPoints(int count)
    {
        if (count < 0) return;
        _points += count;
    }
    /// <summary>
    /// Gets the amount of points the player has.
    /// </summary>
    /// <returns>An int the represents the amount of points.</returns>
    public int GetPoints()
    {
        return _points;
    }
    
    /// <summary>
    /// Represents the lives the player has left.
    /// </summary>
    /// <returns>An int that represents the amount of lives the player has left.</returns>
    public int GetLives()
    {
        return _lives;
    }
    
    /// <summary>
    /// Decrements the players life by one. If the player has no lives left, do nothing.
    /// </summary>
    public void TakeLife()
    {
        if (_lives <= 0) return;
        _lives--;
    }

    /// <summary>
    /// Increments players life by one.
    /// </summary>
    public void AddLife()
    {
        _lives++;
    }
    
    public bool GetMoveLeft()
    {
        return _moveLeft != 0f;
    }

    public bool GetMoveRight()
    {
        return _moveRight != 0f;
    }
    
    
    /// <summary>
    /// A factory method for instantiating a default PlayerEntity.
    /// </summary>
    /// <returns>A PlayerEntity instance.</returns>
    public static PlayerEntity Create()
    {
        return new PlayerEntity(
            new DynamicShape(PositionUtil.PlayerPosition, PositionUtil.PlayerExtent),
            new Image(Path.Combine(Directory.GetCurrentDirectory(), "Assets", "Images", "Player.png"))
        );
    }

}
