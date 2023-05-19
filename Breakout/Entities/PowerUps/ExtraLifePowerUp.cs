using Breakout.Containers;
using DIKUArcade.Graphics;
using DIKUArcade.Math;

namespace Breakout.Entities.PowerUps;

public class ExtraLifePowerUp : IPowerUpType
{
    public IBaseImage GetImage()
    {
        return new Image(Path.Combine("Assets", "Images", "LifePickUp.png"));
    }

    public void DropPowerUp()
    {
        EntityManager.PowerUps.AddEntity(PowerUpEntity.Create(new Vec2F(0.5f, 0.5f), "LifePickUp"));
            
    }
}