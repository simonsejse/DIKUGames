using Breakout.PowerUps.Activators;
using Breakout.States.GameRunning;
using DIKUArcade.Graphics;

namespace Breakout.PowerUps;

public class BigBallPowerUp : IPowerUp
{
    public IBaseImage GetImage() => 
        new Image(Path.Combine("Assets", "Images", "BigPowerUp.png"));


    public IPowerUpActivator Activator() =>
        new BigBallPowerUpActivator(GameRunningState.GetInstance().EntityManager);
}