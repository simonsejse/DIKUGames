using DIKUArcade.Events;
using DIKUArcade.Events.Generic;

namespace Breakout.Factories;

/// <summary>
/// Represents a game event factory.
/// </summary>
/// <typeparam name="TEvent">The type of game event.</typeparam>
public interface IGameEventFactory<TEvent> where TEvent : Enum
{
    /// <summary>
    /// Creates a game event of the specified type with the given message and optional string argument.
    /// </summary>
    /// <param name="type">The type of the game event.</param>
    /// <param name="message">The message associated with the game event.</param>
    /// <param name="stringArg1">An optional string argument.</param>
    /// <returns>The created game event.</returns>
    GameEvent<TEvent> CreateGameEvent(GameEventType type, string message, string stringArg1 = "");
    /// <summary>
    /// Creates a game event of the specified type for specific event processors with the given message.
    /// </summary>
    /// <typeparam name="T">The type of the event processor.</typeparam>
    /// <param name="type">The type of the game event.</param>
    /// <param name="to">The event processor instance.</param>
    /// <param name="message">The message associated with the game event.</param>
    /// <returns>The created game event.</returns>
    GameEvent<TEvent> CreateGameEventForSpecificProcessors<T>(GameEventType type, T to, string message) where T : IGameEventProcessor<TEvent>;
}