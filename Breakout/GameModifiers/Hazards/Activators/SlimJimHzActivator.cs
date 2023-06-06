using Breakout.Entities;
using DIKUArcade.Math;

namespace Breakout.GameModifiers.Hazard.Activators;

/// <summary>
/// Represents an activator for the Slim Jim hazard in the Breakout game.
/// </summary>
public class SlimJimHzActivator : IGameModifierActivator
{
    private const float ScaleFactor = 0.75f;
    private readonly PlayerEntity _playerEntity;

    /// <summary>
    /// Initializes a new instance of the <see cref="SlimJimHzActivator"/> class
    /// with the specified player entity.
    /// </summary>
    /// <param name="playerEntity">The player entity to activate the hazard on.</param>
    public SlimJimHzActivator(PlayerEntity playerEntity)
    {
        _playerEntity = playerEntity;
    }

    /// <summary>
    /// Activates the Slim Jim hazard, causing the player entity to scale down
    /// for a period of time and then return to its original size.
    /// </summary>
    public void Activate()
    {
        _playerEntity.MultiplyExtent(new Vec2F(ScaleFactor, ScaleFactor));
        Task.Delay(5000).ContinueWith(t => _playerEntity.MultiplyExtent(new Vec2F(1 / ScaleFactor, 1 / ScaleFactor)));
    }
}
