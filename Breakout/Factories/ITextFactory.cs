using System.Drawing;
using DIKUArcade.Graphics;
using DIKUArcade.Math;

namespace Breakout.Factories;

/// <summary>
/// Defines a factory for creating instances of the <see cref="Text"/> class.
/// </summary>
public interface ITextFactory
{
    /// <summary>
    /// Creates a new <see cref="Text"/> object with the specified text, position, extent, and color.
    /// </summary>
    /// <param name="text">The text to display.</param>
    /// <param name="pos">The position of the text.</param>
    /// <param name="extent">The extent of the text.</param>
    /// <param name="color">The color of the text.</param>
    /// <returns>A new instance of the <see cref="Text"/> class.</returns>
    Text Create(string text, Vec2F pos, Vec2F extent, Color color);
}