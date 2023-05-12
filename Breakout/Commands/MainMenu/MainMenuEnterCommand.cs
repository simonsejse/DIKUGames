using Breakout.Events;
using Breakout.Factories;
using Breakout.Handler;
using Breakout.States;
using DIKUArcade.Events;
using DIKUArcade.Events.Generic;

namespace Breakout.Commands.MainMenu;

public class MainMenuEnterCommand : IKeyboardCommand
{
    private readonly IMenu _menu;
    private readonly GameEventFactory _gameEventFactory;

    public MainMenuEnterCommand(IMenu menu, GameEventFactory gameEventFactory)
    {
        _menu = menu;
        _gameEventFactory = gameEventFactory;
    }

    public void Execute()
    {
        GameEvent<GameEventType> @event = _menu.ActiveButton switch
        {
            0 => _gameEventFactory.CreateGameEventForAllProcessors(GameEventType.GameStateEvent,
                "NEW_GAME",
                Enum.GetName(GameState.Running) ?? "Running"),
            _ => _gameEventFactory.CreateGameEventForAllProcessors(GameEventType.WindowEvent, "CLOSE_WINDOW")
        };
        BreakoutBus.GetBus().RegisterEvent(@event);
    }
}