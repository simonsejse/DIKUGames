using Breakout.Entities;
using Breakout.PowerUps;
using DIKUArcade.Math;

namespace Breakout.Hazard.Activators;

public class SlimJimHzActivator : IPowerUpActivator
{
    private const float ScaleFactor = 0.75f;
    private readonly PlayerEntity _playerEntity;

    public SlimJimHzActivator(PlayerEntity playerEntity)
    {
        _playerEntity = playerEntity;
    }

    public void Activate()
    {
        _playerEntity.MultiplyExtent(new Vec2F(ScaleFactor, ScaleFactor));
        Task.Delay(5000).ContinueWith(t => _playerEntity.MultiplyExtent(new Vec2F(1 / ScaleFactor, 1 / ScaleFactor)));
    }
}
