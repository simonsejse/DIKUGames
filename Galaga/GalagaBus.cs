using DIKUArcade.Events;
using DIKUArcade.Events.Generic;

namespace Galaga;

/// <summary>
/// Singleton design patterns.
/// </summary>
public static class GalagaBus {
    /// <summary>
    /// Static event bus reference. 
    /// </summary>
    private static GameEventBus<GameEventType> _eventBus;
    
    /// <summary>
    /// Returns the single Event Bus instance.
    /// </summary>
    /// <returns>The GameEventBus singleton instance</returns>
    public static GameEventBus<GameEventType> GetBus() {
        return _eventBus ??= new GameEventBus<GameEventType>();
    }
}