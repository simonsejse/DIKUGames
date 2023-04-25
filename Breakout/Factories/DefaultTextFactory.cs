using System.Drawing;
using DIKUArcade.Graphics;
using DIKUArcade.Math;

namespace Breakout.Factories;

public class DefaultTextFactory : ITextFactory
{
    public Text Create(string text, Vec2F pos, Vec2F extent, Color color) {
        var button = new Text(text, pos, extent);
        button.SetColor(color);
        return button;
    }
}