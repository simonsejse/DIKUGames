

using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;

namespace Breakout.Entities;

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
    private int _points = 0;
    
    #endregion
    
    #region Constructor
    // Constructor that intializes player's shape and image by using the base class constructor
    public PlayerEntity(Shape shape, IBaseImage image) : base(shape, image)
    {

    }
    #endregion

    #region Methods
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
    #endregion

    /// <summary>
    /// Adds count points to the player's points. If the added points are not positive, do nothing
    /// </summary>
    /// <param name="val">Integer for the added points.</param>
    public void AddPoints(int count)
    {
        if(count >= 0)
        {
            _points += count;
        }
    }

    public int GetPoints()
    {
        return _points;
    }
    
    /// <summary>
    /// A factory method for instantiating a default PlayerEntity.
    /// </summary>
    /// <returns>A PlayerEntity instance.</returns>
    public static PlayerEntity Create()
    {
        return new PlayerEntity(new DynamicShape(0.5f - 0.2f / 2f,
                0.03f,
                0.2f,
                0.028f),
            new Image(Path.Combine(Directory.GetCurrentDirectory(), "Assets",
                "Images",
                "Player.png")));
    }
    
}
