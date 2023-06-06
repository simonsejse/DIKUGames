using DIKUArcade.Input;
using DIKUArcade.State;

namespace Breakout.States.GameWon;

public class GameWonState : IGameState
{
    private static GameWonState? _instance;
    
    /// <summary>
    /// Gets the singleton instance of the <see cref="GameWonState"/>.
    /// </summary>
    /// <returns>The singleton instance of the <see cref="GameWonState"/>.</returns>
    public static GameWonState GetInstance()
    {
        return _instance ??= new GameWonState();
    }

    /// <summary>
    /// Resets the state of the game won state.
    /// </summary>
    public void ResetState()
    {
    }

    /// <summary>
    /// Updates the game state.
    /// </summary>
    public void UpdateState()
    {
    }

    /// <summary>
    /// Renders the game state.
    /// </summary>
    public void RenderState()
    {
    }

    /// <summary>
    /// Handles the keyboard event in the game won state.
    /// </summary>
    /// <param name="action">The keyboard action.</param>
    /// <param name="key">The keyboard key.</param>
    public void HandleKeyEvent(KeyboardAction action, KeyboardKey key)
    {
    }
}