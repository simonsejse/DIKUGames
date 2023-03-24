using System;
using System.ComponentModel;

namespace Galaga.GalagaStates;

/// <summary>
/// Enum consisting of the different game states.
/// </summary>
public enum GameStateType
{
    GameRunning,
    GamePaused,
    MainMenu,
    GameLost
}

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
    /// <exception cref="InvalidEnumArgumentException">If the argument provided is not a valid state enum.</exception>
    public GameStateType TransformStringToState(string state)
    {
        if (!Enum.TryParse<GameStateType>(state, out var stateType))
            throw new ArgumentException(state);
        return stateType;
    }
    
    /// <summary>
    /// Transform the GameStateType into a string.
    /// </summary>
    /// <param name="state">The state enum you want to get the name of.</param>
    /// <returns>The name of the GameStateType as a string.</returns>
    /// <exception cref="InvalidEnumArgumentException"></exception>
    public string TransformStateToString(GameStateType state) {
        if (!Enum.IsDefined(typeof(GameStateType), state))
            throw new ArgumentException("No match", Enum.GetName(state));
        return Enum.GetName(state);
    }
}