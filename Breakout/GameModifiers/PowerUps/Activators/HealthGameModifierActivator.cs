using Breakout.Entities;
using Breakout.GameModifiers;

namespace Breakout.PowerUps.Activators;

/// <summary>
/// Represents an activator for the Health power-up.
/// </summary>
public class HealthGameModifierActivator : IGameModifierActivator
{
    private readonly PlayerEntity _playerEntity;

    /// <summary>
    /// Initializes a new instance of the HealthPowerUpActivator class.
    /// </summary>
    /// <param name="playerEntity">The PlayerEntity instance.</param>
    public HealthGameModifierActivator(PlayerEntity playerEntity)
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