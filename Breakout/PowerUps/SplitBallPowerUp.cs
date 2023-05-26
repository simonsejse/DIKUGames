using Breakout.PowerUps.Activators;
using Breakout.States.GameRunning;
using DIKUArcade.Graphics;

namespace Breakout.PowerUps;

public class SplitBallPowerUp : IPowerUp
{
    public IBaseImage GetImage() =>
        new Image(Path.Combine("Assets", "Images", "SplitPowerUp.png"));


    public IPowerUpActivator Activator() =>
        new SplitBallPowerUpActivator(GameRunningState.GetInstance().EntityManager);
}