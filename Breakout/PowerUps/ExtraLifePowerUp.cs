using Breakout.PowerUps.Activators;
using Breakout.States.GameRunning;
using DIKUArcade.Graphics;

namespace Breakout.PowerUps;

public class ExtraLifePowerUp : IPowerUp
{
    public IBaseImage GetImage() => 
        new Image(Path.Combine("Assets", "Images", "LifePickUp.png"));
    
    public IPowerUpActivator Activator() => 
        new HealthPowerUpActivator(GameRunningState.GetInstance().EntityManager.PlayerEntity);
}