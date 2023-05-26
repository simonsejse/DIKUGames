using Breakout.PowerUps.Activators;
using Breakout.States.GameRunning;
using DIKUArcade.Graphics;

namespace Breakout.PowerUps;

public class WidePowerUp : IPowerUp
{
    public IBaseImage GetImage()
    {
        return new Image(Path.Combine("Assets", "Images", "WidePowerUp.png"));
    }

    public IPowerUpActivator Activator() =>
        new WidePowerUpActivator(GameRunningState.GetInstance().EntityManager.PlayerEntity);
}