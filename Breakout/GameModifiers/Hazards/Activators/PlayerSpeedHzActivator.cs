using Breakout.Entities;
using Breakout.Utility;

namespace Breakout.GameModifiers.Hazards.Activators;

public class PlayerSpeedHzActivator : IGameModifierActivator {
    private readonly PlayerEntity _playerEntity;

    public PlayerSpeedHzActivator(PlayerEntity playerEntity) {
        _playerEntity = playerEntity;
    }

    public void Activate() {
        _playerEntity.SetPlayerMovementSpeed(_playerEntity.GetPlayerMovementSpeed() / GameUtil.PlayerSpeedFactor);
        Task.Delay(5000)
            .ContinueWith(t =>
                _playerEntity.SetPlayerMovementSpeed(
                    _playerEntity.GetPlayerMovementSpeed() * GameUtil.PlayerSpeedFactor));
    }
}