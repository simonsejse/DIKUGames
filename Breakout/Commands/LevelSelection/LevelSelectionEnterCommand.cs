using Breakout.Events;
using Breakout.Factories;
using Breakout.Handler;
using Breakout.States;
using DIKUArcade.Events;
using DIKUArcade.Events.Generic;

namespace Breakout.Commands.LevelSelection;

public class LevelSelectionEnterCommand : IKeyboardCommand
{
    private readonly DefaultMenu _menu;
    private readonly GameEventFactory _gameEventFactory;

    public LevelSelectionEnterCommand(DefaultMenu menu, GameEventFactory gameEventFactory)
    {
        _menu = menu;
        _gameEventFactory = gameEventFactory;
    }

public void Execute()
{
    GameEvent<GameEventType> @event = _menu.GetActiveMenuItem() switch
    {
        0 => _gameEventFactory.CreateGameEvent(GameEventType.GameStateEvent, "CHANGE_STATE",
            Enum.GetName(GameState.LevelSelection) ?? "LevelSelection"),
        _ => _gameEventFactory.CreateGameEvent(GameEventType.WindowEvent, "CLOSE_WINDOW")
    };


    // Register the game event
    BreakoutBus.GetBus().RegisterEvent(@event);
}

}