using Breakout.PowerUps;
using DIKUArcade.Math;

namespace Breakout.Entities.PowerUps;

public class SlimJimHZActivator : IPowerUpActivator
{
    private const float ScaleFactor = 0.75f;
    private readonly PlayerEntity _playerEntity;

    public SlimJimHZActivator(PlayerEntity playerEntity)
    {
        _playerEntity = playerEntity;
    }
    
    public void Activate()
    {
        _playerEntity.MultiplyExtent(new Vec2F(ScaleFactor, ScaleFactor));
        Task.Delay(5000).ContinueWith(t => _playerEntity.MultiplyExtent(new Vec2F(1 / ScaleFactor, 1 / ScaleFactor)));
    }
}