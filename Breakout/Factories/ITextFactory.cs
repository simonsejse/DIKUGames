using System.Drawing;
using DIKUArcade.Graphics;
using DIKUArcade.Math;

namespace Breakout.Factories;

/// <summary>
/// Defines a factory for creating instances of the <see cref="Text"/> class.
/// </summary>
public interface ITextFactory
{
    Text Create(string text, Vec2F pos, Vec2F extent, Color color);
}