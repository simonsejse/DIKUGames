using Breakout.GameModifiers.PowerUps.Activators;
using Breakout.States.GameRunning;
using DIKUArcade.Graphics;

namespace Breakout.GameModifiers.PowerUps;

/// <summary>
/// Represents a game modifier for the Hard Ball power-up.
/// </summary>
public class HardBallPowerUp : IGameModifier {
    /// <summary>
    /// Gets the image representation of the Hard Ball power-up.
    /// </summary>
    /// <returns>The image representing the Hard Ball power-up.</returns>
    public IBaseImage GetImage() => 
        new Image(Path.Combine("Assets", "Images", "ball2.png"));
    
    /// <summary>
    /// Creates and returns an activator for the Hard Ball power-up.
    /// </summary>
    /// <returns>An activator for the Hard Ball power-up.</returns>
    public IGameModifierActivator Activator() => 
        new HardBallPowerUpActivator(GameRunningState.GetInstance().EntityManager);
}