using DIKUArcade.Graphics;

namespace Breakout;

/// <summary>
/// A contract for defining UI functionality for states.
/// </summary>
public interface UIDisplayer
{
    Text[] GetTexts();
}