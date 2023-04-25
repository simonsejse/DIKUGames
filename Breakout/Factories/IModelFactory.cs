using System.Drawing;
using DIKUArcade.Graphics;
using DIKUArcade.Math;

namespace Breakout.Factories;

public interface IModelFactory<out T> {
    T Parse (string @string);
}