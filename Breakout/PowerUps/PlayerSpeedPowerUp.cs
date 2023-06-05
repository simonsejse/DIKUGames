using Breakout.PowerUps.Activators;
using Breakout.States.GameRunning;
using DIKUArcade.Graphics;

namespace Breakout.PowerUps;

/// <summary>
/// Represents the Player Speed Power-Up.
/// </summary>
public class PlayerSpeedGameModifier : IGameModifier
{
    /// <summary>
    /// Gets the image associated with the Player Speed Power-Up.
    /// </summary>
    /// <returns>The image of the Player Speed Power-Up.</returns>
    public IBaseImage GetImage() => 
        new Image(Path.Combine("Assets", "Images", "SpeedPickUp.png"));
    
    /// <summary>
    /// Gets the activator for the Player Speed Power-Up.
    /// </summary>
    /// <returns>The activator for the Player Speed Power-Up.</returns>
    public IGameModifierActivator Activator() => 
        new PlayerSpeedGameModifierActivator(GameRunningState.GetInstance().EntityManager.PlayerEntity);
}