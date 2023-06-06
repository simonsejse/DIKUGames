using Breakout.GameModifiers.Hazards.Activators;
using Breakout.States.GameRunning;
using DIKUArcade.Graphics;

namespace Breakout.GameModifiers.Hazards;

/// <summary>
/// Represents a game modifier that affects the player's speed with a hazard effect.
/// </summary>
public class PlayerSpeedHazard : IGameModifier
{
    /// <summary>
    /// Gets the image representation of the hazard effect.
    /// </summary>
    /// <returns>The image representing the hazard effect.</returns>
    public IBaseImage GetImage()
    {
        return new Image(Path.Combine("Assets", "Images", "Slowness.png"));
    }

    /// <summary>
    /// Creates and returns an activator for the hazard effect.
    /// </summary>
    /// <returns>An activator for the hazard effect.</returns>
    public IGameModifierActivator Activator() =>
        new PlayerSpeedHzActivator(GameRunningState.GetInstance().EntityManager.PlayerEntity);
}