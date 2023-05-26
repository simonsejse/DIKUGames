using Breakout.Entities;
using DIKUArcade.Math;

namespace Breakout.PowerUps.Activators;

public class WidePowerUpActivator : IPowerUpActivator
{
    private readonly PlayerEntity _playerEntity;

    public WidePowerUpActivator(PlayerEntity playerEntity)
    {
        _playerEntity = playerEntity;
    }
    
    public void Activate()
    {
        _playerEntity.MultiplyExtent(new Vec2F(1.5f, 1.0f));
        Task.Delay(5000).ContinueWith(t => _playerEntity.MultiplyExtent(new Vec2F(1/1.5f, 1.0f)));
    }
}