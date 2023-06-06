using System.Drawing;
using DIKUArcade.Graphics;
using DIKUArcade.Math;

namespace Breakout.Factories;

/// <summary>
/// Concrete implementation of a <see cref="ITextFactory"/> that creates instances of 
/// the <see cref="Text"/> class.
/// </summary>
public static class DefaultTextFactory {
    /// <summary>
    /// Creates a new <see cref="Text"/> object with the specified text, position, extent, and color.
    /// </summary>
    /// <param name="text">The text to display.</param>
    /// <param name="pos">The position of the text.</param>
    /// <param name="extent">The extent of the text.</param>
    /// <param name="color">The color of the text.</param>
    /// <returns>A new instance of the <see cref="Text"/> class.</returns>
    public static Text Create(string text, Vec2F pos, Vec2F extent, Color color) {
        var button = new Text(text, pos, extent);
        button.SetColor(color);
        return button;
    }
}