using Breakout.Entities;

namespace Breakout.PowerUps.Activators;

public class PlayerSpeedPowerUpActivator : IPowerUpActivator
{
    private readonly PlayerEntity _playerEntity;
    private const float ScaleFactor = 2.0f;

    public PlayerSpeedPowerUpActivator(PlayerEntity playerEntity)
    {
        _playerEntity = playerEntity;
    }
    
    public void Activate()
    {
        float currentSpeed = _playerEntity.GetPlayerMovementSpeed();
        _playerEntity.SetPlayerMovementSpeed(currentSpeed * ScaleFactor);
        Task.Delay(5000).ContinueWith(t => _playerEntity.SetPlayerMovementSpeed(currentSpeed));
    }
}