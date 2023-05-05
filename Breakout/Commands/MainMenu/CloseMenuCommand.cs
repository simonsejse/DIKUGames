using Breakout.Events;
using Breakout.Factories;
using DIKUArcade.Events;
using DIKUArcade.Events.Generic;

namespace Breakout.Commands.MainMenu;

public class CloseMenuCommand : IKeyboardCommand
{
    private readonly IGameEventFactory<GameEventType> _gameEventFactory;

    public CloseMenuCommand() 
    {
        _gameEventFactory = new GameEventFactory();
    }

    public void Execute()
    {
        GameEvent<GameEventType> closeEvent = _gameEventFactory.CreateGameEventForAllProcessors(
            GameEventType.WindowEvent,
            "CLOSE_WINDOW");
            
        BreakoutBus.GetBus().RegisterEvent(closeEvent);
    }
}