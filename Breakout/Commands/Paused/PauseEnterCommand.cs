using Breakout.Events;
using Breakout.Factories;
using Breakout.Handler;
using Breakout.States;
using DIKUArcade.Events;
using DIKUArcade.Events.Generic;

namespace Breakout.Commands.Paused;

public class PauseEnterCommand : IKeyboardCommand
{
    private readonly IMenu _menu;
    private readonly GameEventFactory _gameEventFactory;

    public PauseEnterCommand(IMenu menu, GameEventFactory gameEventFactory)
    {
        _menu = menu;
        _gameEventFactory = gameEventFactory;
    }

    public void Execute()
    {
        GameEvent<GameEventType> @event = _menu.ActiveButton switch
        {
            0 => _gameEventFactory.CreateGameEventForAllProcessors(GameEventType.GameStateEvent,
                "CHANGE_STATE",
                Enum.GetName(GameState.Running) ?? "Running"),
            _ => _gameEventFactory.CreateGameEventForAllProcessors(GameEventType.GameStateEvent,
                "CHANGE_STATE", 
                Enum.GetName(GameState.Menu) ?? "Menu"),
        };
        BreakoutBus.GetBus().RegisterEvent(@event);
    }
}