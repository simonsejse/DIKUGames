namespace Breakout.States.GameRunning;

/// <summary>
/// A win condition for the game.
/// </summary>
public interface IWinCondition
{
    /// <summary>
    /// Checks if the player has won the game.
    /// </summary>
    /// <param name="currentLevel">Represents the current level</param>
    /// <returns>A boolean indicating if the player has won.</returns>
    bool HasWon(int currentLevel);
}