using Breakout.PowerUps.Activators;
using Breakout.States.GameRunning;
using DIKUArcade.Graphics;

namespace Breakout.PowerUps;

/// <summary>
/// Represents the Wide Power-Up.
/// </summary>
public class WideGameModifier : IGameModifier
{
    /// <summary>
    /// Gets the image associated with the Wide Power-Up.
    /// </summary>
    /// <returns>The image of the Wide Power-Up.</returns>
    public IBaseImage GetImage()
    {
        return new Image(Path.Combine("Assets", "Images", "WidePowerUp.png"));
    }

    /// <summary>
    /// Gets the activator for the Wide Power-Up.
    /// </summary>
    /// <returns>The activator for the Wide Power-Up.</returns>
    public IGameModifierActivator Activator() =>
        new WideGameModifierActivator(GameRunningState.GetInstance().EntityManager.PlayerEntity);
}