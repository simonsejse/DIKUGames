using Breakout.Hazard;

namespace Breakout.PowerUps;

/// <summary>
/// Static class that stores all the power up types.
/// </summary>
public static class PowerUpStorage
{
    /// <summary>
    /// A collection of all the power up types.
    /// </summary>
    private static readonly List<IPowerUp> PowerUps = new();
    
    /// <summary>
    /// Static constructor that adds all the power up types to the collection.
    /// </summary>
    static PowerUpStorage()
    {
        //PowerUps.Add(new ExtraLifePowerUp());
        //PowerUps.Add(new WidePowerUp());
        //PowerUps.Add(new BigBallPowerUp());
        //PowerUps.Add(new SplitBallPowerUp());
        //PowerUps.Add(new PlayerSpeedPowerUp());
        PowerUps.Add(new HardBallPowerUp());
    }
    
    /// <summary>
    /// Returns a random power up.
    /// </summary>
    /// <returns>A random power up.</returns>
    public static IPowerUp GetRandomPowerUp()
    {
        var random = new Random();
        int randomIndex = random.Next(0, PowerUps.Count);
        return PowerUps[randomIndex];
    }
}