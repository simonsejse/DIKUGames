using Breakout.Entities;

namespace Breakout.PowerUps.Activators;

/// <summary>
/// Represents an activator for the Health power-up.
/// </summary>
public class HealthPowerUpActivator : IPowerUpActivator
{
    private readonly PlayerEntity _playerEntity;

    /// <summary>
    /// Initializes a new instance of the HealthPowerUpActivator class.
    /// </summary>
    /// <param name="playerEntity">The PlayerEntity instance.</param>
    public HealthPowerUpActivator(PlayerEntity playerEntity)
    {
        _playerEntity = playerEntity;
    }
    
    /// <summary>
    /// Activates the Health power-up by adding a life to the player.
    /// </summary>
    public void Activate()
    {
        _playerEntity.AddLife();
    }
}