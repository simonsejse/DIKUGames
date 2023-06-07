using Breakout.Handler;

namespace Breakout.Commands.MainMenu;

public class ShiftMenuDownCommand : IKeyboardCommand {
    private readonly IMenu _menu;

    /// <summary>
    /// Initializes a new instance of the <see cref="ShiftMenuDownCommand"/> class.
    /// </summary>
    /// <param name="menu">The current menu instance.</param>
    public ShiftMenuDownCommand(IMenu menu) {
        _menu = menu;
    }

    /// <summary>
    /// Executes the command by shifting the menu selection one downward.
    /// </summary>
    public void Execute() {
        _menu.ShiftMenuDown();
    }
}