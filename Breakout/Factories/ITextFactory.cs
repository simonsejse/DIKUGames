using System.Drawing;
using DIKUArcade.Graphics;
using DIKUArcade.Math;

namespace Breakout.Factories;

public interface ITextFactory
{
    Text Create(string text, Vec2F pos, Vec2F extent, Color color);
}