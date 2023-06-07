using Breakout.Events;
using Breakout.Factories;
using Breakout.Handler;
using Breakout.States;
using DIKUArcade.Events;
using DIKUArcade.Events.Generic;

namespace Breakout.Commands.MainMenu;

public class MainMenuEnterCommand : IKeyboardCommand {
    private readonly DefaultMenu _menu;
    private readonly GameEventFactory _gameEventFactory;

    /// <summary>
    /// Initializes a new instance of the <see cref="MainMenuEnterCommand"/> class.
    /// </summary>
    /// <param name="menu">The current default menu.</param>
    /// <param name="gameEventFactory">The game event factory.</param>
    public MainMenuEnterCommand(DefaultMenu menu, GameEventFactory gameEventFactory) {
        _menu = menu;
        _gameEventFactory = gameEventFactory;
    }

    /// <summary>
    /// Executes the command by creating a game event based on the active menu item and registering 
    /// it with the Breakout bus.
    /// </summary>
    public void Execute() {
        GameEvent<GameEventType> @event = _menu.GetActiveMenuItem() switch {
            0 => _gameEventFactory.CreateGameEvent(GameEventType.GameStateEvent, "NEW_GAME",
                Enum.GetName(GameState.Running) ?? "Running"),
            _ => _gameEventFactory.CreateGameEvent(GameEventType.WindowEvent, "CLOSE_WINDOW")
        };

        BreakoutBus.GetBus().RegisterEvent(@event);
    }
}