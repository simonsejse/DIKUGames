using Breakout.Hazard.Activators;
using Breakout.PowerUps;
using Breakout.PowerUps.Activators;
using Breakout.States.GameRunning;
using DIKUArcade.Graphics;

namespace Breakout.Hazard;

public class SlimJimHazard : IPowerUp
{
    public IBaseImage GetImage()
    {
        return new Image(Path.Combine("Assets", "Images", "SlimJim.png"));
    }

    public IPowerUpActivator Activator() =>
        new SlimJimHzActivator(GameRunningState.GetInstance().EntityManager.PlayerEntity);
}