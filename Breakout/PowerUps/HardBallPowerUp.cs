using Breakout.PowerUps.Activators;
using Breakout.States.GameRunning;
using DIKUArcade.Graphics;

namespace Breakout.PowerUps;

public class HardBallPowerUp : IPowerUp
{
    public IBaseImage GetImage() => 
        new Image(Path.Combine("Assets", "Images", "ball2.png"));
    
    public IPowerUpActivator Activator() => 
        new HardBallPowerUpActivator(GameRunningState.GetInstance().EntityManager);
}