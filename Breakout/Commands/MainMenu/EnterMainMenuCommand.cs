using Breakout.Events;
using Breakout.Factories;
using Breakout.States;
using DIKUArcade.Events;
using DIKUArcade.Events.Generic;

namespace Breakout.Commands.MainMenu;

public class EnterMainMenuCommand : IKeyboardCommand
{
    private readonly MainMenuState _state;
    private readonly GameEventFactory _gameEventFactory;

    public EnterMainMenuCommand(MainMenuState state, GameEventFactory gameEventFactory)
    {
        _state = state;
        _gameEventFactory = gameEventFactory;
    }

    public void Execute()
    {
        GameEvent<GameEventType> @event = _state.ActiveButton switch
        {
            0 => _gameEventFactory.CreateGameEventForAllProcessors(GameEventType.GameStateEvent,
                "CHANGE_STATE",
                Enum.GetName(GameState.Running) ?? "Running"),
            _ => _gameEventFactory.CreateGameEventForAllProcessors(GameEventType.WindowEvent, "CLOSE_WINDOW")
        };
        BreakoutBus.GetBus().RegisterEvent(@event);
    }
}