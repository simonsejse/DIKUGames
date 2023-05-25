using Breakout.Events;
using Breakout.Factories;
using Breakout.States;
using DIKUArcade.Events;
using DIKUArcade.Events.Generic;

namespace Breakout.Commands.GameLost;

public class ReturnToMainMenuCommand : IKeyboardCommand
{
    private readonly GameEventFactory _gameEventFactory;

    public ReturnToMainMenuCommand(GameEventFactory gameEventFactory)
    {
        _gameEventFactory = gameEventFactory;
    }
    
    public void Execute()
    {
        GameEvent<GameEventType> toMainMenuEvent = _gameEventFactory.CreateGameEvent(GameEventType.GameStateEvent,
            "CHANGE_STATE",
            Enum.GetName(GameState.Menu) ?? "Menu");
        BreakoutBus.GetBus().RegisterEvent(toMainMenuEvent);
    }
}