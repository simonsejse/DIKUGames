using DIKUArcade.Math;
using DIKUArcade.Entities;
using Breakout.Entities.BlockTypes;
using DIKUArcade.Graphics;

namespace Breakout.Entities;

/// <summary>
/// Defines the class for the blocks within the game with a certain value and health.
/// </summary>
public class BlockEntity : Entity
{
    #region Properties
    public int Value { get; set; }
    /// <summary>
    /// Gets or sets the health of the block.
    /// </summary>
    public int Health { get; set; }
    public int StartHealth { get; set; }
    public IBlockType BlockType { get; set; }
    public IBaseImage Image2 { get; set; }
    
    #endregion
    
    #region Constructors

    /// <summary>
    /// Initializes a new instance of the BlockEntity class with the specified shape, image, value, and health.
    /// </summary>
    /// <param name="shape">The shape of the block.</param>
    /// <param name="image">The image to use for the block.</param>
    /// <param name="value">The value of the block.</param>
    /// <param name="health">The health of the block.</param>
    /// <param name="blockType">The type of the block.</param>
    public BlockEntity(Shape shape, IBaseImage image, IBaseImage image2, int value, int health, IBlockType blockType) : 
        base(shape, image)
    {
        Value = value;
        Health = health;
        BlockType = blockType;
        if (blockType is HardenedBlockType) 
        {
            Health = Health * 2;
        }
        StartHealth = Health;
        Image2 = image2;
    }
    
    #endregion

    #region Methods
    /// <summary>
    /// Removes 1 point of health from the block entity
    /// </summary>
    public virtual void TakeDamage() 
    {
        Health--;
        if (IsDead())
        {
            DeleteEntity();
        }
    }

    public bool IsDead()
    {
        if (Health <= 0)
        {
            return true;
        }
        return false;
    }

    public void CollisionHandler()
    {
        BlockType.CollisionHandler(this);
    }
    #endregion

    public static BlockEntity Create(Vec2F pos, Image image, Image image2, IBlockType blockType)
    {
        return new BlockEntity(
            new StationaryShape(pos, new Vec2F(0.08333333333f, 0.04f)),
            image,
            image2, 
            10, 
            100,
            blockType
        );
    }
}
