using System.Drawing;
using DIKUArcade.Graphics;

namespace Breakout.Handler;

public interface IMenu
{
    void ShiftMenuUp();
    void ShiftMenuDown();
}