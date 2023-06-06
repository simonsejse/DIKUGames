using Breakout.Entities;
using Breakout.Utility;

namespace Breakout.GameModifiers.Hazard.Activators;

public class PlayerSpeedHzActivator : IGameModifierActivator
{
    private readonly PlayerEntity _playerEntity;

    public PlayerSpeedHzActivator(PlayerEntity playerEntity)
    {
        _playerEntity = playerEntity;
    }

    public void Activate()
    {
        float currentSpeed = _playerEntity.GetPlayerMovementSpeed();
        _playerEntity.SetPlayerMovementSpeed(currentSpeed / GameUtil.PlayerSpeedFactor);
        Task.Delay(5000).ContinueWith(t => _playerEntity.SetPlayerMovementSpeed(currentSpeed));
    }
}