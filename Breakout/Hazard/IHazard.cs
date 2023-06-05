using Breakout.PowerUps;
using DIKUArcade.Graphics;

namespace Breakout.Hazard;

/// <summary>
/// A strategy for individual hazards that can drop.
/// A hazard is an object that can randomly drop from a standard block and be picked up by the player.
/// </summary>
public interface IHazard
{
    IBaseImage GetImage();
    IHazardActivator Activator();
}