using DIKUArcade.Math;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;

namespace Breakout.Entities;

/// <summary>
/// Defines the class for the blocks within the game with a certain value and health.
/// </summary>
public class BlockEntity : Entity
{
    #region Properties
    //TestPush 2
    /// <summary>
    /// Gets or sets the value of the block.
    /// </summary>
    public int Value { get; set; }
    /// <summary>
    /// Gets or sets the health of the block.
    /// </summary>
    public int Health { get; set; }
    #endregion
    
    #region Constructors
    /// <summary>
    /// Initializes a new instance of the BlockEntity class with the specified shape, image, value, and health.
    /// </summary>
    /// <param name="shape">The shape of the block.</param>
    /// <param name="image">The image to use for the block.</param>
    /// <param name="value">The value of the block.</param>
    /// <param name="health">The health of the block.</param>
    public BlockEntity(Shape shape, IBaseImage image, int value, int health) : base(shape, image)
    {
        Value = value;
        Health = health;
    }
    #endregion
}
