using Breakout.Entities.PowerUps;

namespace Breakout.PowerUps;

public static class PowerUpStorage
{
    private static readonly List<IPowerUpType> PowerUpType = new();
    
    static PowerUpStorage()
    {
        PowerUpType.Add(new ExtraLifePowerUp());
    }
    
    public static IPowerUpType GetRandomPowerUp()
    {
        var random = new Random();
        int randomIndex = random.Next(0, PowerUpType.Count);
        return PowerUpType[randomIndex];
    }
}