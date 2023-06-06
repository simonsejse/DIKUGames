using System.Drawing;
using DIKUArcade.Graphics;

namespace Breakout.Handler;

/// <summary>
/// Interface for a menu that allows shifting the active menu item up and down.
/// </summary>
public interface IMenu
{
    void ShiftMenuUp();
    void ShiftMenuDown();
}