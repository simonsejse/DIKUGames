using Breakout.Handler;

namespace Breakout.Commands.MainMenu;

public class ShiftMenuUpCommand : IKeyboardCommand {
    private readonly IMenu _menu;

    /// <summary>
    /// Initializes a new instance of the <see cref="ShiftMenuUpCommand"/> class.
    /// </summary>
    /// <param name="menu">The current menu instance.</param>
    public ShiftMenuUpCommand(IMenu menu) {
        _menu = menu;
    }

    /// <summary>
    /// Executes the command by shifting the menu selection one upward.
    /// </summary>
    public void Execute() {
        _menu.ShiftMenuUp();
    }
}