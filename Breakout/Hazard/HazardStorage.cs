using Breakout.PowerUps;

namespace Breakout.Hazard;

/// <summary>
/// Static class that stores all the power up types.
/// </summary>
public static class HazardStorage
{
    /// <summary>
    /// A collection of all the hazard types.
    /// </summary>
    private static readonly List<IHazard> Hazards = new();
    
    /// <summary>
    /// Static constructor that adds all the hazard types to the collection.
    /// </summary>
    static HazardStorage()
    {
        Hazards.Add(new LoseLifeHazard());
        Hazards.Add(new SlimJimHazard());
        Hazards.Add(new PlayerSpeedHazard());
    }
    
    /// <summary>
    /// Returns a random hazard.
    /// </summary>
    /// <returns>A random hazard.</returns>
    public static IHazard GetRandomHazard()
    {
        var random = new Random();
        int randomIndex = random.Next(0, Hazards.Count);
        return Hazards[randomIndex];
    }
}