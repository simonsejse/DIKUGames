using Breakout.Events;
using Breakout.Factories;
using Breakout.Handler;
using Breakout.States;
using DIKUArcade.Events;
using DIKUArcade.Events.Generic;

namespace Breakout.Commands.GameLost;

public class GameOverEnterCommand : IKeyboardCommand
{
    private readonly DefaultMenu _menu;
    private readonly GameEventFactory _gameEventFactory;

    public GameOverEnterCommand(DefaultMenu menu, GameEventFactory gameEventFactory)
    {
        _menu = menu;
        _gameEventFactory = gameEventFactory;
    }
    public void Execute()
    {
        GameEvent<GameEventType> @event = _menu.GetActiveMenuItem() switch
        {
            0 => _gameEventFactory.CreateGameEvent(GameEventType.GameStateEvent, "CHANGE_STATE",
                Enum.GetName(GameState.Menu) ?? "Menu"),
            _ => _gameEventFactory.CreateGameEvent(GameEventType.WindowEvent, "CLOSE_WINDOW")
        };

        BreakoutBus.GetBus().RegisterEvent(@event);
    }
}