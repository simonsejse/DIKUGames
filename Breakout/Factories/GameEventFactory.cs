using DIKUArcade.Events;
using DIKUArcade.Events.Generic;

namespace Breakout.Factories;

/// <summary>
/// Default concrete implementation for the abstract interface <see cref="IGameEventFactory{TEvent}"/>.
/// Another good design pattern to use could've been the builder pattern since the GameEvent class has a lot of properties and hence
/// the builder pattern could've been a good choice to use here.
/// </summary>
public class GameEventFactory : IGameEventFactory<GameEventType>
{
    /// <summary>
    /// Creates a new instance of GameEvent with the specified type, message, and string argument.
    /// </summary>
    /// <param name="type">The type of the game event.</param>
    /// <param name="message">The message associated with the game event.</param>
    /// <param name="stringArg1">The string argument associated with the game event.</param>
    /// <returns>The created game event.</returns>
    public GameEvent<GameEventType> CreateGameEvent(GameEventType type,
        string message = "",
        string stringArg1 = "")
    {
        return new GameEvent<GameEventType>
        {
            EventType = type,
            Message = message,
            StringArg1 = stringArg1
        };
    }

    /// <summary>
    /// Creates a new instance of GameEvent for specific processors, with the specified type, target, and message.
    /// </summary>
    /// <typeparam name="T">The type of the game event processor.</typeparam>
    /// <param name="type">The type of the game event.</param>
    /// <param name="to">The target game event processor.</param>
    /// <param name="message">The message associated with the game event.</param>
    /// <returns>The created game event.</returns>
    public GameEvent<GameEventType> CreateGameEventForSpecificProcessors<T>(GameEventType type, T to, string message) where T : IGameEventProcessor<GameEventType>
    {
        return new GameEvent<GameEventType>
        {
            EventType = type,
            To = to,
            Message = message,
        };
    }
}