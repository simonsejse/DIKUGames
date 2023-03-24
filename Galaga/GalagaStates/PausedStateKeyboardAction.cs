using System;
using System.Drawing;
using DIKUArcade.Events;
using DIKUArcade.Events.Generic;
using DIKUArcade.Input;

namespace Galaga.GalagaStates;

public class PausedStateKeyboardAction : IKeyboardIntermediaryPressHandler
{
    private readonly GamePaused _gamePaused;

    public PausedStateKeyboardAction(GamePaused gamePaused)
    {
        _gamePaused = gamePaused;
    }
    
    public void KeyPress(KeyboardKey key)
    {
        switch (key)
        {
            case KeyboardKey.W:
            case KeyboardKey.Up:
                if (_gamePaused.ActiveMenuButton <= 0) return;
                _gamePaused.MenuButtons[_gamePaused.ActiveMenuButton].SetColor(Color.White);
                _gamePaused.ActiveMenuButton--;
                _gamePaused.MenuButtons[_gamePaused.ActiveMenuButton].SetColor(Color.Aqua);
                break;
            case KeyboardKey.S:
            case KeyboardKey.Down:
                if (_gamePaused.ActiveMenuButton + 1 >= _gamePaused.MenuButtons.Length) return;
                _gamePaused.MenuButtons[_gamePaused.ActiveMenuButton].SetColor(Color.White);
                _gamePaused.ActiveMenuButton++;
                _gamePaused.MenuButtons[_gamePaused.ActiveMenuButton].SetColor(Color.Aqua);
                break;
            case KeyboardKey.Enter:
                GameEvent<GameEventType> gameEvent = _gamePaused.ActiveMenuButton switch
                {
                    0 => new GameEvent<GameEventType>
                    {
                        EventType = GameEventType.GameStateEvent,
                        Message = "CHANGE_STATE",
                        StringArg1 = Enum.GetName(GameStateType.GameRunning),
                    },
                    _ => new GameEvent<GameEventType>
                    {
                        EventType = GameEventType.GameStateEvent,
                        Message = "CHANGE_STATE",
                        StringArg1 = Enum.GetName(GameStateType.MainMenu),
                    }
                };
                GalagaBus.GetBus().RegisterEvent(gameEvent);
                break;
        }
    }
}