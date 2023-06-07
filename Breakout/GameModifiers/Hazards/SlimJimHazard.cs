using Breakout.GameModifiers.Hazard.Activators;
using Breakout.States.GameRunning;
using DIKUArcade.Graphics;

namespace Breakout.GameModifiers.Hazard;

/// <summary>
/// Represents a Slim Jim hazard in the Breakout game.
/// </summary>
public class SlimJimHazard : IGameModifier {
    /// <summary>
    /// Gets the image representation of the Slim Jim hazard.
    /// </summary>
    /// <returns>The image of the Slim Jim hazard.</returns>
    public IBaseImage GetImage() {
        return new Image(Path.Combine("Assets", "Images", "SlimJim.png"));
    }

    /// <summary>
    /// Gets the activator for the Slim Jim hazard.
    /// </summary>
    /// <returns>The activator for the Slim Jim hazard.</returns>
    public IGameModifierActivator Activator() =>

        new SlimJimHzActivator(GameRunningState.GetInstance().EntityManager.PlayerEntity);
}