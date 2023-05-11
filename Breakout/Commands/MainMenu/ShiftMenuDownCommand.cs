using System.Drawing;
using Breakout.Handler;
using Breakout.States;
using DIKUArcade.Graphics;

namespace Breakout.Commands.MainMenu;

public class ShiftMenuDownCommand : IKeyboardCommand
{
    private readonly IMenu _state;

    public ShiftMenuDownCommand(IMenu state)
    {
        _state = state;
    }

    public void Execute()
    {
        int activeButton = _state.ActiveButton;
        Text[] menuButtons = _state.MenuButtons;
        
        if (activeButton + 1 >= menuButtons.Length) return;
        menuButtons[activeButton].SetColor(Color.White);
        activeButton = ++_state.ActiveButton;
        menuButtons[activeButton].SetColor(Color.Crimson);
    }
}