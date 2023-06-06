using Breakout.Entities;
using Breakout.Utility;

namespace Breakout.GameModifiers.PowerUps.Activators;

/// <summary>
/// Represents an activator for the Player Speed power-up.
/// </summary>
public class PlayerSpeedPowerUpActivator : IGameModifierActivator
{
    private readonly PlayerEntity _playerEntity;

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
        _playerEntity.SetPlayerMovementSpeed(_playerEntity.GetPlayerMovementSpeed() * GameUtil.PlayerSpeedFactor);
        Task.Delay(5000)
            .ContinueWith(t =>
                _playerEntity.SetPlayerMovementSpeed(_playerEntity.GetPlayerMovementSpeed() *
                                                     1 /
                                                     GameUtil.PlayerSpeedFactor));
    }
}