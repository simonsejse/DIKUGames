using Breakout.Events;
using Breakout.Factories;
using Breakout.Handler;
using Breakout.States;
using DIKUArcade.Events;
using DIKUArcade.Events.Generic;
using DIKUArcade.Timers;

namespace Breakout.Commands.Paused;

public class PauseEnterCommand : IKeyboardCommand
{
    private readonly DefaultMenu _menu;
    private readonly GameEventFactory _gameEventFactory;

    public PauseEnterCommand(DefaultMenu menu, GameEventFactory gameEventFactory)
    {
        _menu = menu;
        _gameEventFactory = gameEventFactory;
    }

    public void Execute()
    {
        GameEvent<GameEventType> @event;
        switch (_menu.GetActiveMenuItem())
        {
            case 0:
                StaticTimer.ResumeTimer();
                @event = _gameEventFactory.CreateGameEvent(GameEventType.GameStateEvent, "CHANGE_STATE",
                    Enum.GetName(GameState.Running) ?? "Running");
                break;
            case 1:
                @event = _gameEventFactory.CreateGameEvent(GameEventType.GameStateEvent, "CHANGE_STATE",
                    Enum.GetName(GameState.Menu) ?? "Menu");
                break;
            default: 
                @event = _gameEventFactory.CreateGameEvent(
                    GameEventType.WindowEvent,
                    "CLOSE_WINDOW");
                break;
        }

        BreakoutBus.GetBus().RegisterEvent(@event);
    }
}