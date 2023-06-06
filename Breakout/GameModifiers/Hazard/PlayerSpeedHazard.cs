using Breakout.GameModifiers.Hazard.Activators;
using Breakout.States.GameRunning;
using DIKUArcade.Graphics;

namespace Breakout.GameModifiers.Hazard;

public class PlayerSpeedHazard : IGameModifier
{
    public IBaseImage GetImage()
    {
        return new Image(Path.Combine("Assets", "Images", "Slowness.png"));
    }

    public IGameModifierActivator Activator() =>
        new PlayerSpeedHzActivator(GameRunningState.GetInstance().EntityManager.PlayerEntity);
}