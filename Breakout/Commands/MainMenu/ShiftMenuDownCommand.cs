using System.Drawing;
using Breakout.Handler;
using Breakout.States;
using DIKUArcade.Graphics;

namespace Breakout.Commands.MainMenu;

public class ShiftMenuDownCommand : IKeyboardCommand
{
    private readonly IMenu _menu;

    public ShiftMenuDownCommand(IMenu menu)
    {
        _menu = menu;
    }

    public void Execute()
    {
        _menu.ShiftMenuDown();
    }
}