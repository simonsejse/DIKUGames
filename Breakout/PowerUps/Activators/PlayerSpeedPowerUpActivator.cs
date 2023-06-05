using Breakout.Entities;

namespace Breakout.PowerUps.Activators;

/// <summary>
/// Represents an activator for the Player Speed power-up.
/// </summary>
public class PlayerSpeedPowerUpActivator : IPowerUpActivator
{
    private readonly PlayerEntity _playerEntity;
    private const float ScaleFactor = 2.0f;

    /// <summary>
    /// Initializes a new instance of the PlayerSpeedPowerUpActivator class.
    /// </summary>
    /// <param name="playerEntity">The PlayerEntity instance.</param>
    public PlayerSpeedPowerUpActivator(PlayerEntity playerEntity)
    {
        _playerEntity = playerEntity;
    }
    
    /// <summary>
    /// Activates the Player Speed power-up by increasing the player's movement speed for a duration.
    /// </summary>
    public void Activate()
    {
        float currentSpeed = _playerEntity.GetPlayerMovementSpeed();
        _playerEntity.SetPlayerMovementSpeed(currentSpeed * ScaleFactor);
        Task.Delay(5000).ContinueWith(t => _playerEntity.SetPlayerMovementSpeed(currentSpeed));
    }
}