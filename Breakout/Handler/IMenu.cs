using System.Drawing;
using DIKUArcade.Graphics;

namespace Breakout.Handler;

public interface IMenu
{
    int ActiveButton { get; set; }
    Text[] MenuButtons { get; }
    void SetButtonColor(int index, Color color);
}