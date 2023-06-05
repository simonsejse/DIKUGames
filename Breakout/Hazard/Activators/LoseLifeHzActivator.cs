using Breakout.Entities;
using Breakout.PowerUps;

namespace Breakout.Hazard.Activators;

/// <summary>
/// Represents an activator for the Lose Life hazard power-up in the Breakout game.
/// </summary>
public class LoseLifeHzActivator : IPowerUpActivator
{
    private readonly PlayerEntity _playerEntity;

    /// <summary>
    /// Initializes a new instance of the <see cref="LoseLifeHzActivator"/> class
    /// with the specified player entity.
    /// </summary>
    /// <param name="playerEntity">The player entity to activate the hazard on.</param>
    public LoseLifeHzActivator(PlayerEntity playerEntity)
    {
        _playerEntity = playerEntity;
    }

    /// <summary>
    /// Activates the Lose Life hazard power-up, causing the player entity to lose a life.
    /// </summary>
    public void Activate()
    {
        _playerEntity.TakeLife();
    }
}
