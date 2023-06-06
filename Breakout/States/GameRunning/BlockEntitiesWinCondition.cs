using Breakout.Containers;
using Breakout.Levels;

namespace Breakout.States.GameRunning;

/// <summary>
/// Represents the win condition where the
/// player has won if there are no more blocks left in the game
/// and there are no more levels to load.
/// </summary>
public class BlockEntitiesWinCondition : IWinCondition {
    private readonly EntityManager _entityManager;
    private readonly LevelLoader _levelLoader;

    public BlockEntitiesWinCondition(EntityManager entityManager, LevelLoader levelLoader) {
        _entityManager = entityManager;
        _levelLoader = levelLoader;
    }

    /// <summary>
    /// Checks if the player has won the game.
    /// </summary>
    /// <param name="currentLevel">The current level number.</param>
    /// <returns>True if the player has won the game, false otherwise.</returns>
    public bool HasWon(int currentLevel) {
        bool moreBlocksLeft = _entityManager.BlockEntities.CountEntities() > 0;
        if (moreBlocksLeft) return false;

        bool noMoreLevels = currentLevel == _levelLoader.NumberOfLevels - 1;
        return noMoreLevels;
    }
}