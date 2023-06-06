using Breakout.Events;
using Breakout.Factories;
using Breakout.States;
using DIKUArcade.Events;
using DIKUArcade.Events.Generic;
using DIKUArcade.Timers;

namespace Breakout.Commands.GameRunning;

public class PauseGameCommand : IKeyboardCommand
{
    private readonly GameEventFactory _gameEventFactory;

    /// <summary>
    /// Initializes a new instance of the <see cref="PauseGameCommand"/> class.
    /// </summary>
    /// <param name="gameEventFactory">The game event factory.</param>
    public PauseGameCommand(GameEventFactory gameEventFactory)
    {
        _gameEventFactory = gameEventFactory;
    }

    /// <summary>
    /// Executes the command by pausing the game and registering a game event for the "Paused" state.
    /// </summary>
    public void Execute()
    {
        StaticTimer.PauseTimer();
        GameEvent<GameEventType> pauseEvent = _gameEventFactory.CreateGameEvent(
            GameEventType.GameStateEvent,
            "CHANGE_STATE",
            Enum.GetName(GameState.Paused) ?? "Paused");
        BreakoutBus.GetBus().RegisterEvent(pauseEvent);
    }
}