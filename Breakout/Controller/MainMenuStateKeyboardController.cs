using Breakout.Events;
using Breakout.Factories;
using Breakout.Handler;
using DIKUArcade.Events;
using DIKUArcade.Events.Generic;
using DIKUArcade.Input;

namespace Breakout.Controller;

public class MainMenuStateKeyboardController : IKeyboardPressHandler
{
    private readonly IGameEventFactory<GameEventType> _gameEventFactory;

    public MainMenuStateKeyboardController()
    {
        _gameEventFactory = new GameEventFactory();
    }
    
    public void HandleKeyPress(KeyboardKey key)
    {
        switch (key)
        {
            case KeyboardKey.Escape:
                GameEvent<GameEventType> closeEvent = _gameEventFactory.CreateGameEventForAllProcessors(
                    GameEventType.WindowEvent,
                    "CLOSE_WINDOW");
            
                BreakoutBus.GetBus().RegisterEvent(closeEvent);
                break;

        }
    }
}