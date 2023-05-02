using DIKUArcade.Events;
using DIKUArcade.Events.Generic;

namespace Breakout.Factories;

public interface IGameEventFactory<TEvent> where TEvent : Enum
{
    GameEvent<TEvent> CreateGameEventForAllProcessors(GameEventType type, string message, string parameter1, string parameter2);

    GameEvent<TEvent> CreateGameEventForSpecificProcessors<T>(GameEventType type, T to, string message,
        string parameter1, string parameter2) where T : IGameEventProcessor<TEvent>;
}