using System.Drawing;
using DIKUArcade.Graphics;
using DIKUArcade.Math;

namespace Breakout.Factories;

public interface ModelFactory<T> {
    List<T> parse (string @string);
}