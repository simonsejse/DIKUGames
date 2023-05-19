using DIKUArcade.Graphics;

namespace Breakout.Entities.PowerUps;

public class ExtraLifePowerUp : IPowerUpType
{
    
    public IBaseImage GetImage()
    {
        return new Image(Path.Combine("Assets", "Images", "LifePickUp.png"));
    }

    public void ActivatePowerUp()
    {
        Console.WriteLine("Kæmpe penis i min mund!");
    }
}