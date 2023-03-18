using System;
using System.Drawing;
using DIKUArcade.Events;
using DIKUArcade.Events.Generic;
using DIKUArcade.Input;

namespace Galaga.GalagaStates;

public class MainStateKeyboardAction : IKeyboardIntermediaryPressHandler
{
    private readonly MainMenu _mainMenu;

    public MainStateKeyboardAction(MainMenu mainMenu)
    {
        _mainMenu = mainMenu;
    }
    
    public void KeyPress(KeyboardKey key)
    {
        Console.WriteLine("Hi");
        switch (key)
        {  
            case KeyboardKey.W:
            case KeyboardKey.Up:
                if (_mainMenu.ActiveMenuButton <= 0) return;
                _mainMenu.MenuButtons[_mainMenu.ActiveMenuButton].SetColor(Color.White);
                _mainMenu.ActiveMenuButton--;
                _mainMenu.MenuButtons[_mainMenu.ActiveMenuButton].SetColor(Color.GreenYellow);
                break;
            case KeyboardKey.S:
            case KeyboardKey.Down:
                if (_mainMenu.ActiveMenuButton + 1 >= MainMenu.MaxMenuButtons) return;
                _mainMenu.MenuButtons[_mainMenu.ActiveMenuButton].SetColor(Color.White);
                _mainMenu.ActiveMenuButton++;
                _mainMenu.MenuButtons[_mainMenu.ActiveMenuButton].SetColor(Color.Red);
                break;
            case KeyboardKey.Enter:
                GameEvent<GameEventType> gameEvent = _mainMenu.ActiveMenuButton switch
                {
                    0 => new GameEvent<GameEventType>
                    {
                        EventType = GameEventType.GameStateEvent,
                        Message = "CHANGE_STATE",
                        StringArg1 = Enum.GetName(GameStateType.GameRunning),
                    },
                    _ => new GameEvent<GameEventType>
                    {
                        EventType = GameEventType.WindowEvent,
                        Message = "CLOSE_GAME",
                    }
                };
                GalagaBus.GetBus().RegisterEvent(gameEvent);
                break;
        }
    }
}