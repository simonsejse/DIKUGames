using Breakout.Entities;
using Breakout.Utility;

namespace Breakout.GameModifiers.Hazards.Activators;

/// <summary>
/// Represents an activator for the Hazard that modifies the player speed.
/// </summary>
public class PlayerSpeedHzActivator : IGameModifierActivator
{
    private readonly PlayerEntity _playerEntity;

    /// <summary>
    /// Initializes a new instance of the <see cref="PlayerSpeedHzActivator"/> class with the specified player entity.
    /// </summary>
    /// <param name="playerEntity">The player entity to modify the speed for.</param>
    public PlayerSpeedHzActivator(PlayerEntity playerEntity)
    {
        _playerEntity = playerEntity;
    }

    /// <summary>
    /// Activates the player speed modification.
    /// </summary>
    public void Activate()
    {
        _playerEntity.SetPlayerMovementSpeed(_playerEntity.GetPlayerMovementSpeed() / GameUtil.PlayerSpeedFactor);
        Task.Delay(5000)
            .ContinueWith(t =>
                _playerEntity.SetPlayerMovementSpeed(
                    _playerEntity.GetPlayerMovementSpeed() * GameUtil.PlayerSpeedFactor));
    }
}