using Breakout.Hazard.Activators;
using Breakout.PowerUps;
using Breakout.PowerUps.Activators;
using Breakout.States.GameRunning;
using DIKUArcade.Graphics;

namespace Breakout.Hazard;

/// <summary>
/// Represents a lose life hazard power-up in the Breakout game.
/// </summary>
public class LoseLifeHazard : IPowerUp
{
    /// <summary>
    /// Gets the image representation of the lose life hazard power-up.
    /// </summary>
    /// <returns>The image of the lose life hazard power-up.</returns>
    public IBaseImage GetImage()
    {
        return new Image(Path.Combine("Assets", "Images", "LoseLife.png"));
    }

    /// <summary>
    /// Gets the activator for the lose life hazard power-up.
    /// </summary>
    /// <returns>The activator for the lose life hazard power-up.</returns>
    public IPowerUpActivator Activator() =>
        new LoseLifeHzActivator(GameRunningState.GetInstance().EntityManager.PlayerEntity);
}