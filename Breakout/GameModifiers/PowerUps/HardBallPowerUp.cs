using Breakout.GameModifiers.PowerUps.Activators;
using Breakout.States.GameRunning;
using DIKUArcade.Graphics;

namespace Breakout.GameModifiers.PowerUps;

public class HardBallPowerUp : IGameModifier
{
    public IBaseImage GetImage() => 
        new Image(Path.Combine("Assets", "Images", "ball2.png"));
    
    public IGameModifierActivator Activator() => 
        new HardBallPowerUpActivator(GameRunningState.GetInstance().EntityManager);
}