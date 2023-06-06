using System.Drawing;
using DIKUArcade.Graphics;
using DIKUArcade.Math;

namespace Breakout.Factories;

/// <summary>
/// Defines a factory for creating instances of the <see cref="Text"/> class.
/// </summary>
public interface ITextFactory {
    /// <summary>
    /// Creates a text object with the specified properties.
    /// </summary>
    /// <param name="text">The text content.</param>
    /// <param name="pos">The position of the text.</param>
    /// <param name="extent">The extent (size) of the text.</param>
    /// <param name="color">The color of the text.</param>
    /// <returns>The created text object.</returns>
    Text Create(string text, Vec2F pos, Vec2F extent, Color color);
}