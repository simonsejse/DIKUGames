using Breakout.Hazard.Activators;
using Breakout.PowerUps;
using Breakout.PowerUps.Activators;
using Breakout.States.GameRunning;
using DIKUArcade.Graphics;

namespace Breakout.Hazard;

public class PlayerSpeedHazard : IHazard
{
    public IBaseImage GetImage()
    {
        return new Image(Path.Combine("Assets", "Images", "Slowness.png"));
    }

    public IHazardActivator Activator() =>
        new PlayerSpeedHzActivator(GameRunningState.GetInstance().EntityManager.PlayerEntity);
}