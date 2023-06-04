using Breakout.PowerUps.Activators;
using Breakout.States.GameRunning;
using DIKUArcade.Graphics;

namespace Breakout.PowerUps;

public class PlayerSpeedPowerUp : IPowerUp
{
    public IBaseImage GetImage() => 
        new Image(Path.Combine("Assets", "Images", "SpeedPickUp.png"));
    
    public IPowerUpActivator Activator() => 
        new PlayerSpeedPowerUpActivator(GameRunningState.GetInstance().EntityManager.PlayerEntity);
}