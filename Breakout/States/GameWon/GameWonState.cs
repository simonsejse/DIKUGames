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
    public static GameWonState GetInstance() {
        return _instance ??= new GameWonState();
    }

    public void ResetState() {
    }

    public void UpdateState() {
    }

    public void RenderState() {
    }

    public void HandleKeyEvent(KeyboardAction action, KeyboardKey key) {
    }
}