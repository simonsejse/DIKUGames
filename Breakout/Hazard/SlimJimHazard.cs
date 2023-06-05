using Breakout.Hazard.Activators;
using Breakout.PowerUps;
using Breakout.PowerUps.Activators;
using Breakout.States.GameRunning;
using DIKUArcade.Graphics;

namespace Breakout.Hazard;

/// <summary>
/// Represents a Slim Jim hazard power-up in the Breakout game.
/// </summary>
public class SlimJimHazard : IGameModifier
{
    /// <summary>
    /// Gets the image representation of the Slim Jim hazard power-up.
    /// </summary>
    /// <returns>The image of the Slim Jim hazard power-up.</returns>
    public IBaseImage GetImage()
    {
        return new Image(Path.Combine("Assets", "Images", "SlimJim.png"));
    }

    /// <summary>
    /// Gets the activator for the Slim Jim hazard power-up.
    /// </summary>
    /// <returns>The activator for the Slim Jim hazard power-up.</returns>
    public IGameModifierActivator Activator() =>
        new SlimJimHzActivator(GameRunningState.GetInstance().EntityManager.PlayerEntity);
}