using Breakout.GameModifiers.PowerUps.Activators;
using Breakout.States.GameRunning;
using DIKUArcade.Graphics;

namespace Breakout.GameModifiers.PowerUps;

/// <summary>
/// Represents the Hard Ball Power-Up.
/// </summary>
public class HardBallPowerUp : IGameModifier {
    /// <summary>
    /// Gets the image associated with the Hard Ball Power-Up.
    /// </summary>
    /// <returns>The image of the Hard Ball Power-Up.</returns>
    public IBaseImage GetImage() => 
        new Image(Path.Combine("Assets", "Images", "ball2.png"));
    
    /// <summary>
    /// Gets the activator for the Hard Ball Power-Up.
    /// </summary>
    /// <returns>The activator for the Hard Ball Power-Up.</returns>
    public IGameModifierActivator Activator() => 
        new HardBallPowerUpActivator(GameRunningState.GetInstance().EntityManager);
}