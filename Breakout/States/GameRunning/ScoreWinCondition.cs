using Breakout.Entities;

namespace Breakout.States.GameRunning;

/// <summary>
/// Represents a win condition where the player wins if their score exceeds a certain threshold.
/// </summary>
public class ScoreWinCondition : IWinCondition {
    private readonly PlayerEntity _playerEntity;

    /// <summary>
    /// Initializes a new instance of the <see cref="ScoreWinCondition"/> class with the specified 
    /// player entity.
    /// </summary>
    /// <param name="playerEntity">The player entity.</param>
    public ScoreWinCondition(PlayerEntity playerEntity) {
        _playerEntity = playerEntity;
    }

    /// <summary>
    /// Determines whether the win condition has been met.
    /// The player wins if their score exceeds 3000.
    /// </summary>
    /// <param name="currentLevel">The current level number.</param>
    /// <returns>True if the win condition has been met; otherwise, false.</returns>
    public bool HasWon(int currentLevel) {
        return _playerEntity.GetPoints() > 3000;
    }
}