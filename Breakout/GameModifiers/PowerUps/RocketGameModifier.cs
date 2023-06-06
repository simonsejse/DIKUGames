using Breakout.GameModifiers.PowerUps.Activators;
using Breakout.PowerUps.Activators;
using Breakout.States.GameRunning;
using DIKUArcade.Graphics;

namespace Breakout.GameModifiers.PowerUps;

public class RocketGameModifier : IGameModifier
{
    public IBaseImage GetImage() => 
        new Image(Path.Combine("Assets", "Images", "RocketPickUp.png"));


    public IGameModifierActivator Activator() =>
        new PlayerSpeedPowerUpActivator(GameRunningState.GetInstance().EntityManager.PlayerEntity);

}