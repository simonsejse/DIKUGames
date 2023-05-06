using System.Drawing;
using Breakout.States;
using DIKUArcade.Graphics;

namespace Breakout.Commands.MainMenu;

public class ShiftMenuUpCommand : IKeyboardCommand
{
    private readonly MainMenuState _state;

    public ShiftMenuUpCommand(MainMenuState state)
    {
        _state = state;
    }

    public void Execute()
    {
        
        int activeButton = _state.ActiveButton;
        Text[] menuButtons = _state.MenuButtons;
        if (activeButton <= 0) return;
        
        menuButtons[activeButton].SetColor(Color.White);
        activeButton = --_state.ActiveButton;
        menuButtons[activeButton].SetColor(Color.Crimson);
    }

}