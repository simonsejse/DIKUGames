﻿using DIKUArcade.Events;
using DIKUArcade.Events.Generic;

namespace Breakout.Factories;

/// <summary>
/// Default concrete implementation for the abstract interface <see cref="IGameEventFactory{TEvent}"/>.
/// Another good design pattern to use could've been the builder pattern since the GameEvent class has a lot of properties and hence
/// the builder pattern could've been a good choice to use here.
/// </summary>
public class GameEventFactory : IGameEventFactory<GameEventType>
{
    public GameEvent<GameEventType> CreateGameEventForAllProcessors(GameEventType type, string message = "")
    {
        return new GameEvent<GameEventType>
        {
            EventType = type,
            Message = message,
        };
    }

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