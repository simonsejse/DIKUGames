using Breakout.GameModifiers.PowerUps.Activators;
using Breakout.PowerUps.Activators;
using Breakout.States.GameRunning;
using DIKUArcade.Graphics;

namespace Breakout.GameModifiers.PowerUps;

/// <summary>
/// Represents the Rocket Game Power-Up.
/// </summary>
public class RocketGameModifier : IGameModifier {
    /// <summary>
    /// Gets the image associated with the Rocket Game Power-Up.
    /// </summary>
    /// <returns>The image of the Rocket Game Power-Up.</returns>
    public IBaseImage GetImage() => 
        new Image(Path.Combine("Assets", "Images", "RocketPickUp.png"));


    /// <summary>
    /// Gets the activator for the Rocket Game Power-Up.
    /// </summary>
    /// <returns>The activator for the Rocket Game Power-Up.</returns>
    public IGameModifierActivator Activator() =>
        new PlayerSpeedPowerUpActivator(GameRunningState.GetInstance().EntityManager.PlayerEntity);

}