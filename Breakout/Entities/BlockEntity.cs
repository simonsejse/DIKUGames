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
    public int Value { get; set; }
    /// <summary>
    /// Gets or sets the health of the block.
    /// </summary>
    public int Health { get; set; }
    public int StartHealth { get; set; }
    public IBlockType BlockType { get; set; }
    public IBaseImage Image2 { get; set; }


    /// <summary>
    /// Initializes a new instance of the BlockEntity class with the specified shape, image, value, and health.
    /// </summary>
    /// <param name="shape">The shape of the block.</param>
    /// <param name="image">The image to use for the block. Will represent the non damaged block.</param>
    /// <param name="image2">The second image to use for the block. Will represent the damaged block.</param>
    /// <param name="value">The value of the block.</param>
    /// <param name="health">The health of the block.</param>
    /// <param name="blockType">The type of the block.</param>
    public BlockEntity(Shape shape, IBaseImage image, IBaseImage image2, int value, int health, IBlockType blockType) : 
        base(shape, image)
    {
        Value = value;
        Health = health;
        BlockType = blockType;
        Health = blockType.GetBlockTypeBehavior().ModifyHealth(health);
        StartHealth = Health;
        Image2 = image2;
    }
    /// <summary>
    /// Returns a boolean indicating whether the block health is below zero.
    /// </summary>
    /// <returns>A boolean indicating if the block has died.</returns>
    public bool IsDead() => Health <= 0;

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

    public void CollisionHandler()
    {
        BlockType.CollisionHandler(this);
    }

    /// <summary>
    /// A factory method for instantiating a default BlockEntity
    /// </summary>
    /// <returns>A BlockEntity instance</returns>
    /// <param name="pos">The position of the block.</param>
    /// <param name="image">The image of the block.</param>
    /// <param name="image2">The second image of the block.</param>
    /// <param name="blockType">The type of the block.</param>
    /// <returns></returns>
    public static BlockEntity Create(Vec2F pos, Image image, Image image2, IBlockType blockType)
    {
        return new BlockEntity(
            new StationaryShape(pos, ConstantsUtil.BlockExtent),
            image,
            image2, 
            10, 
            1,
            blockType
        );
    }
}
