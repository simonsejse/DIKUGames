namespace Breakout.GameModifiers;

/// <summary>
/// A strategy for activating a power up depending on the type of power up.
/// </summary>
public interface IGameModifierActivator
{
    void Activate();
}