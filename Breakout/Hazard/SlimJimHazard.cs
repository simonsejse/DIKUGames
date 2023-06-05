using Breakout.Hazard.Activators;
using Breakout.PowerUps;
using Breakout.PowerUps.Activators;
using Breakout.States.GameRunning;
using DIKUArcade.Graphics;

namespace Breakout.Hazard;

public class SlimJimHazard : IHazard
{
    public IBaseImage GetImage()
    {
        return new Image(Path.Combine("Assets", "Images", "SlimJim.png"));
    }

    public IHazardActivator Activator() =>
        new SlimJimHzActivator(GameRunningState.GetInstance().EntityManager.PlayerEntity);
}