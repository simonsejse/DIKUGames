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

    /// <summary>
    /// Initializes a new instance of the <see cref="PauseEnterCommand"/> class.
    /// </summary>
    /// <param name="menu">The default menu.</param>
    /// <param name="gameEventFactory">The game event factory.</param>
    public PauseEnterCommand(DefaultMenu menu, GameEventFactory gameEventFactory)
    {
        _menu = menu;
        _gameEventFactory = gameEventFactory;
    }

    /// <summary>
    /// Executes the command by creating a game event based on the active menu item and registering it with the Breakout bus.
    /// </summary>
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