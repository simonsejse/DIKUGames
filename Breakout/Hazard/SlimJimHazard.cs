using Breakout.Entities.PowerUps;
using Breakout.PowerUps;
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
        new SlimJimHZActivator(GameRunningState.GetInstance().EntityManager.PlayerEntity);
}