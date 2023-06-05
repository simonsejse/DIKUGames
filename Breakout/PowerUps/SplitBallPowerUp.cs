using Breakout.PowerUps.Activators;
using Breakout.States.GameRunning;
using DIKUArcade.Graphics;

namespace Breakout.PowerUps;

/// <summary>
/// Represents the Split Ball Power-Up.
/// </summary>
public class SplitBallPowerUp : IPowerUp
{
    /// <summary>
    /// Gets the image associated with the Split Ball Power-Up.
    /// </summary>
    /// <returns>The image of the Split Ball Power-Up.</returns>
    public IBaseImage GetImage() =>
        new Image(Path.Combine("Assets", "Images", "SplitPowerUp.png"));


    /// <summary>
    /// Gets the activator for the Split Ball Power-Up.
    /// </summary>
    /// <returns>The activator for the Split Ball Power-Up.</returns>
    public IPowerUpActivator Activator() =>
        new SplitBallPowerUpActivator(GameRunningState.GetInstance().EntityManager);
}