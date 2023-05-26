using Breakout.Entities;
using DIKUArcade.Graphics;

namespace Breakout.PowerUps;

/// <summary>
/// A strategy for individual power ups that can drop.
/// A power up is an object that can be dropped from a block and picked up by the player.
/// </summary>
public interface IPowerUp
{
    IBaseImage GetImage();
    IPowerUpActivator Activator();
}