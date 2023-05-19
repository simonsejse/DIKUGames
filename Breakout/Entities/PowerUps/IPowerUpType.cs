using DIKUArcade.Graphics;

namespace Breakout.Entities.PowerUps;

public interface IPowerUpType
{
    IBaseImage GetImage();
    void DropPowerUp(BlockEntity block);
}