namespace Breakout.Hazard;

/// <summary>
/// A strategy for activating a power up depending on the type of power up.
/// </summary>
public interface IHazardActivator
{
    void Activate();
}
