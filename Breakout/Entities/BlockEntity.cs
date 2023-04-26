using DIKUArcade.Math;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;

namespace Breakout.Entities;

public class BlockEntity : Entity
{
    #region Properties
    public int Value { get; set; }
    public int Health { get; set; }
    #endregion
    
    #region Constructors
    public BlockEntity(Shape shape, IBaseImage image, int value, int health) : base(shape, image)
    {
        Value = value;
        Health = health;
    }
    #endregion
}
