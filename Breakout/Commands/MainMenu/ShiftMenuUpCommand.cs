using System.Drawing;
using Breakout.Handler;

namespace Breakout.Commands.MainMenu;

public class ShiftMenuUpCommand : IKeyboardCommand
{
    private readonly IMenu _state;

    public ShiftMenuUpCommand(IMenu state)
    {
        _state = state;
    }

    public void Execute()
    {
        int activeButton = _state.ActiveButton;
        if (activeButton <= 0) return;

        _state.SetButtonColor(activeButton, Color.White);
        activeButton = --_state.ActiveButton;
        _state.SetButtonColor(activeButton, Color.Crimson);
    }
}