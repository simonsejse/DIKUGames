using Breakout.Handler;

namespace Breakout.Commands.MainMenu;

public class ShiftMenuUpCommand : IKeyboardCommand
{
    private readonly IMenu _menu;

    public ShiftMenuUpCommand(IMenu menu)
    {
        _menu = menu;
    }

    public void Execute()
    {
        _menu.ShiftMenuUp();
    }
}