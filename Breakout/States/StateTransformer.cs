namespace Breakout.States;


/// <summary>
/// A state transformer that allows switching from string and to state enums.
/// </summary>
public class StateTransformer
{
    /// <summary>
    /// Transform the state string into a GameStateType.
    /// </summary>
    /// <param name="state">The state as a string to convert to the enum type.</param>
    /// <returns>A game state enum.</returns>
    /// <exception cref="ArgumentException">If the argument provided is not a valid state enum.</exception>
    public GameState TransformStringToState(string state)
    {
        if (!Enum.TryParse<GameState>(state, out var stateType))
            throw new ArgumentException(state);
        return stateType;
    }
    
    /// <summary>
    /// Transform the GameStateType into a string.
    /// </summary>
    /// <param name="state">The state enum you want to get the name of.</param>
    /// <returns>The name of the GameStateType as a string.</returns>
    /// <exception cref="ArgumentException"></exception>
    public string TransformStateToString(GameState state) {
        if (!Enum.IsDefined(typeof(GameState), state))
            throw new ArgumentException("No match", Enum.GetName(state));
        return Enum.GetName(state);
    }
}