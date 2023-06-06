using Breakout.Hazard.Activators;
using Breakout.States.GameRunning;
using DIKUArcade.Graphics;

namespace Breakout.GameModifiers.Hazard;

/// <summary>
/// Represents a lose life hazard in the Breakout game.
/// </summary>
public class LoseLifeHazard : IGameModifier {
    /// <summary>
    /// Gets the image representation of the lose life hazard.
    /// </summary>
    /// <returns>The image of the lose life hazard.</returns>
    public IBaseImage GetImage() {
        return new Image(Path.Combine("Assets", "Images", "LoseLife.png"));
    }

    /// <summary>
    /// Gets the activator for the lose life hazard.
    /// </summary>
    /// <returns>The activator for the lose life hazard.</returns>
    public IGameModifierActivator Activator() =>
        new LoseLifeHzActivator(GameRunningState.GetInstance().EntityManager.PlayerEntity);
}