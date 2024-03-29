using DIKUArcade.Math;
using DIKUArcade.Entities;
using Breakout.Entities.BlockTypes;
using Breakout.GameModifiers;
using Breakout.States.GameRunning;
using Breakout.Utility;
using DIKUArcade.Graphics;

namespace Breakout.Entities;

/// <summary>
/// Defines the class for the blocks within the game with a certain value and health.
/// </summary>
public class BlockEntity : Entity {
    private readonly IGameModifier? _powerUp;
    private readonly IGameModifier? _hazard;
    
    public int Value { get; set; }
    /// <summary>
    /// Gets or sets the health of the block.
    /// </summary>
    public int Health { get; set; }
    public int StartHealth { get; set; }
    private IBlockType BlockType { get; set; }
    public IBaseImage DamagedImage { get; set; }

    /// <summary>
    /// Initializes a new instance of the BlockEntity class with the specified shape, image, value, and health.
    /// </summary>
    /// <param name="shape">The shape of the block.</param>
    /// <param name="image">The image to use for the block. Will represent the non damaged block.</param>
    /// <param name="damagedImage">The second image to use for the block. Will represent the damaged block.</param>
    /// <param name="value">The value of the block.</param>
    /// <param name="health">The health of the block.</param>
    /// <param name="blockType">The type of the block.</param>
    /// <param name="powerUp">The power-up type of the block.</param>
    /// <param name="hazard">The hazard type of the block.</param>
    private BlockEntity(Shape shape, IBaseImage image, IBaseImage damagedImage, int value, int health, 
        IBlockType blockType, IGameModifier? powerUp, IGameModifier? hazard) : base(shape, image) {
            Value = value;
            Health = health;
            BlockType = blockType;
            _powerUp = powerUp;
            _hazard = hazard;
            Health = blockType.GetBlockTypeBehavior().ModifyHealth(health);
            StartHealth = Health;
            DamagedImage = damagedImage;
    }
    /// <summary>
    /// Returns a boolean indicating whether the block health is below zero.
    /// </summary>
    /// <returns>A boolean indicating if the block has died.</returns>
    public bool IsDead() => Health <= 0;

    /// <summary>
    /// Removes 1 point of health from the block entity
    /// </summary>
    public virtual void TakeDamage()  {
        Health--;
        if (IsDead()) {
            DeleteEntity();
        }
    }

    public void HandleCollision() => BlockType.HandleCollision(this);
    
    /// <summary>
    /// Drops a power-up at the current position of the brick.
    /// </summary>
    public void DropPowerUp() {
        if (_powerUp == null) return;
        float positionX = Shape.Position.X + Shape.Extent.X / 2 - PositionUtil.PowerUpExtent.X / 2;
        float positionY = Shape.Position.Y + Shape.Extent.Y / 2 - PositionUtil.PowerUpExtent.Y / 2;

        var position = new Vec2F(positionX, positionY);
    
        var powerUp = GameModifierEntity.Create(
            position, 
            _powerUp.GetImage(), 
            _powerUp.Activator()
        );
        GameRunningState.GetInstance().EntityManager.PowerUpEntities.AddEntity(powerUp);
    }


    /// <summary>
    /// Drops a hazard at the current position of the brick depending on HazardDropRate.
    /// </summary>
    public void DropHazard() {
        if (_hazard == null) return;
        
        float randomValue = (float) new Random().NextDouble();

        if (!(randomValue < GameUtil.HazardDropRate)) return;
        
        float positionX = Shape.Position.X + Shape.Extent.X / 2 - PositionUtil.HazardExtent.X / 2;
        float positionY = Shape.Position.Y + Shape.Extent.Y / 2 - PositionUtil.HazardExtent.Y / 2;

        var position = new Vec2F(positionX, positionY);

        var hazard = GameModifierEntity.Create(position, _hazard.GetImage(), _hazard.Activator());
        GameRunningState.GetInstance().EntityManager.HazardEntities.AddEntity(hazard);
    }


    /// <summary>
    /// A factory method for instantiating a default BlockEntity
    /// </summary>
    /// <returns>A BlockEntity instance</returns>
    /// <param name="pos">The position of the block.</param>
    /// <param name="image">The image of the block.</param>
    /// <param name="image2">The second image of the block.</param>
    /// <param name="blockType">The type of the block.</param>
    /// <param name="powerUp">The powerup modifier</param>
    /// <param name="hazard">The hazard modifier</param>
    /// <returns></returns>
    public static BlockEntity Create(Vec2F pos, Image image, Image image2, IBlockType blockType, 
        IGameModifier? powerUp = null, IGameModifier? hazard = null) {
        return new BlockEntity(
            new StationaryShape(pos, PositionUtil.BlockExtent),
            image,
            image2, 
            10, 
            1,
            blockType,
            powerUp,
            hazard
        );
    }
}
