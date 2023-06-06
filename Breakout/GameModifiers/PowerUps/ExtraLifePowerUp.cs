using Breakout.PowerUps.Activators;
using Breakout.States.GameRunning;
using DIKUArcade.Graphics;

namespace Breakout.GameModifiers.PowerUps;

/// <summary>
/// Represents the Extra Life Power-Up.
/// </summary>
public class ExtraLifeGameModifier : IGameModifier
{
    /// <summary>
    /// Gets the image associated with the Extra Life Power-Up.
    /// </summary>
    /// <returns>The image of the Extra Life Power-Up.</returns>
    public IBaseImage GetImage() => 
        new Image(Path.Combine("Assets", "Images", "LifePickUp.png"));
    
    /// <summary>
    /// Gets the activator for the Extra Life Power-Up.
    /// </summary>
    /// <returns>The activator for the Extra Life Power-Up.</returns>
    public IGameModifierActivator Activator() => 
        new HealthPowerUpActivator(GameRunningState.GetInstance().EntityManager.PlayerEntity);
}