using Breakout.Events;
using Breakout.Factories;
using Breakout.States;
using DIKUArcade.Events;
using DIKUArcade.Events.Generic;

namespace Breakout.Commands.MainMenu;

public class MainMenuEnterCommand : IKeyboardCommand
{
    private readonly int _index;
    private readonly GameEventFactory _gameEventFactory;

    public MainMenuEnterCommand(int index, GameEventFactory gameEventFactory)
    {
        _index = index;
        _gameEventFactory = gameEventFactory;
    }

    public void Execute()
    {
        GameEvent<GameEventType> @event = _index switch
        {
            0 => _gameEventFactory.CreateGameEventForAllProcessors(GameEventType.GameStateEvent,
                "CHANGE_STATE",
                Enum.GetName(GameState.Running) ?? "Running"),
            _ => _gameEventFactory.CreateGameEventForAllProcessors(GameEventType.WindowEvent, "CLOSE_WINDOW")
        };
        BreakoutBus.GetBus().RegisterEvent(@event);
    }
}