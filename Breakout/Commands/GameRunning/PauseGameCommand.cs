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

    public PauseGameCommand(GameEventFactory gameEventFactory)
    {
        _gameEventFactory = gameEventFactory;
    }

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