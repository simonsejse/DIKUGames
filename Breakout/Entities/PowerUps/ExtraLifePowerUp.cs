using Breakout.Containers;
using Breakout.Utility;
using DIKUArcade.Graphics;
using DIKUArcade.Math;

namespace Breakout.Entities.PowerUps;

public class ExtraLifePowerUp : IPowerUpType
{
    public IBaseImage GetImage()
    {
        return new Image(Path.Combine("Assets", "Images", "LifePickUp.png"));
    }

    public void DropPowerUp(BlockEntity block)
    {
        float positionY = block.Shape.Position.Y + ConstantsUtil.BlockExtent.Y / 2f;
        float positionX = block.Shape.Position.X + ConstantsUtil.BlockExtent.X / 2f;

        var position = new Vec2F(positionX, positionY);
        EntityManager.PowerUps.AddEntity(PowerUpEntity.Create(position, "LifePickUp"));
    }
}