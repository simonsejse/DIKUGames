using Breakout.GameModifiers.Hazard;
using Breakout.GameModifiers.PowerUps;
using Breakout.Hazard;

namespace Breakout.GameModifiers;

/// <summary>
/// Static class that stores all the power up types.
/// </summary>
public static class GameModifierStorage
{
    /// <summary>
    /// A collection of all the power up types.
    /// </summary>
    private static readonly List<IGameModifier> PowerUps = new();
    /// <summary>
    /// A collection of all the hazards.
    /// </summary>
    private static readonly List<IGameModifier> Hazards = new();

    
    /// <summary>
    /// Static constructor that adds all the power up types to the collection.
    /// </summary>
    static GameModifierStorage()
    {
        //Power Ups
        PowerUps.Add(new ExtraLifeGameModifier());
        PowerUps.Add(new WideGameModifier());
        PowerUps.Add(new BigBallGameModifier());
        PowerUps.Add(new SplitBallGameModifier());
        PowerUps.Add(new PlayerSpeedGameModifier());
        //Hazards
        Hazards.Add(new LoseLifeHazard());
        Hazards.Add(new SlimJimHazard());
        Hazards.Add(new PlayerSpeedHazard());
    }
    
    /// <summary>
    /// Returns a random power up.
    /// </summary>
    /// <returns>A random power up.</returns>
    public static IGameModifier GetRandomPowerUp()
    {
        var random = new Random();
        int randomIndex = random.Next(0, PowerUps.Count);
        return PowerUps[randomIndex];
    }
    
    /// <summary>
    /// Returns a random power up.
    /// </summary>
    /// <returns>A random power up.</returns>
    public static IGameModifier GetRandomHazard()
    {
        var random = new Random();
        int randomIndex = random.Next(0, Hazards.Count);
        return Hazards[randomIndex];
    }
}