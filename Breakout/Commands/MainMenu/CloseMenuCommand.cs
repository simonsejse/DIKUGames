using Breakout.Events;
using Breakout.Factories;
using DIKUArcade.Events;
using DIKUArcade.Events.Generic;

namespace Breakout.Commands.MainMenu;

public class CloseMenuCommand : IKeyboardCommand
{
    private readonly IGameEventFactory<GameEventType> _gameEventFactory;

    /// <summary>
    /// Initializes a new instance of the <see cref="CloseMenuCommand"/> class.
    /// </summary>
    public CloseMenuCommand() 
    {
        _gameEventFactory = new GameEventFactory();
    }

    /// <summary>
    /// Executes the command by creating a game event to close the window and registering it with the Breakout bus.
    /// </summary>
    public void Execute()
    {
        GameEvent<GameEventType> closeEvent = _gameEventFactory.CreateGameEvent(
            GameEventType.WindowEvent,
            "CLOSE_WINDOW");
            
        BreakoutBus.GetBus().RegisterEvent(closeEvent);
    }
}