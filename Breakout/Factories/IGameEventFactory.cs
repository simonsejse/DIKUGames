using DIKUArcade.Events;
using DIKUArcade.Events.Generic;

namespace Breakout.Factories;

public interface IGameEventFactory<TEvent> where TEvent : Enum {
    GameEvent<TEvent> CreateGameEvent(GameEventType type, string message, string stringArg1 = "");
    GameEvent<TEvent> CreateGameEventForSpecificProcessors<T>(GameEventType type, T to, 
        string message) where T : IGameEventProcessor<TEvent>;
}