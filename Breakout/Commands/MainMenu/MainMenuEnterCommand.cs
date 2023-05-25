using Breakout.Events;
using Breakout.Factories;
using Breakout.Handler;
using Breakout.States;
using DIKUArcade.Events;
using DIKUArcade.Events.Generic;
using DIKUArcade.Timers;

namespace Breakout.Commands.MainMenu;

public class MainMenuEnterCommand : IKeyboardCommand
{
    private readonly DefaultMenu _menu;
    private readonly GameEventFactory _gameEventFactory;

    public MainMenuEnterCommand(DefaultMenu menu, GameEventFactory gameEventFactory)
    {
        _menu = menu;
        _gameEventFactory = gameEventFactory;
    }

    public void Execute()
    {
        GameEvent<GameEventType> @event = _menu.GetActiveMenuItem() switch
        {
            0 => _gameEventFactory.CreateGameEvent(GameEventType.GameStateEvent, "NEW_GAME",
                Enum.GetName(GameState.Running) ?? "Running"),
            _ => _gameEventFactory.CreateGameEvent(GameEventType.WindowEvent, "CLOSE_WINDOW")
        };

        BreakoutBus.GetBus().RegisterEvent(@event);
    }
}