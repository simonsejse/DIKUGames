using Breakout.Entities;
using Breakout.GameModifiers;
using Breakout.GameModifiers.Hazard;
using Breakout.GameModifiers.Hazard.Activators;
using Breakout.GameModifiers.Hazards;
using Breakout.GameModifiers.Hazards.Activators;
using DIKUArcade.GUI;
using Breakout.Hazard.Activators;
using Breakout.Utility;

namespace BreakoutTests.PowerUpHazardTests;

/// <summary>
/// We have mainly used the Test-Driven Development Approach for these tests
/// </summary>
[TestFixture]
public class HazardTests
{
    private readonly List<IGameModifier> Hazards = new()
    {
        new LoseLifeHazard(),
        new SlimJimHazard()
    };

    [SetUp]
    public void Setup()
    {
        Window.CreateOpenGLContext();
    }

    [Test]
    public void TestPowerUp()
    {
        foreach(var hazard in Hazards) 
        {
            Assert.That(hazard.GetImage(), Is.Not.Null);
            Assert.That(hazard.Activator(), Is.Not.Null);
        }
    }

    [Test]
    public void LoseLifeHazard()
    {
        PlayerEntity player = PlayerEntity.Create();
        IGameModifier extraLifePowerUp = new LoseLifeHazard();
        IGameModifierActivator activator = new LoseLifeHzActivator(player);
        Assert.That(player.GetLives(), Is.EqualTo(3));
        activator.Activate();
        Assert.That(player.GetLives(), Is.LessThan(3));
    }

    [Test]
    public void SlimJimHazard()
    {
        PlayerEntity player = PlayerEntity.Create();
        IGameModifier extraLifePowerUp = new SlimJimHazard();
        IGameModifierActivator activator = new SlimJimHzActivator(player);
        Assert.That(player.Shape.Extent.X, Is.EqualTo(0.2f));
        Assert.That(player.Shape.Extent.Y, Is.EqualTo(0.028f));
        activator.Activate();
        Assert.That(player.Shape.Extent.X, Is.LessThan(0.2f));
        Assert.That(player.Shape.Extent.Y, Is.LessThan(0.028f));
    }
    
    [Test]
    public async Task PlayerSpeedHzActivator()
    {
        PlayerEntity player = PlayerEntity.Create();
        float initialSpeed = player.GetPlayerMovementSpeed();
        float expectedSpeed = initialSpeed / GameUtil.PlayerSpeedFactor;

        IGameModifierActivator activator = new PlayerSpeedHzActivator(player);
        activator.Activate();

        Assert.That(player.GetPlayerMovementSpeed(), Is.EqualTo(expectedSpeed).Within(0.001f));

        await Task.Delay(5500);

        Assert.That(player.GetPlayerMovementSpeed(), Is.EqualTo(initialSpeed).Within(0.001f));
    }
    
    [Test]
    public void GetRandomHazard_NonNull()
    {
        var hazard = GameModifierStorage.GetRandomHazard();
        
        Assert.That(hazard, Is.Not.Null);
    }
    
    [Test]
    public void GetRandomHazard_GivenHazard()
    {
        IGameModifier hazard = GameModifierStorage.GetRandomHazard();
        
        Assert.That(hazard is LoseLifeHazard || 
                      hazard is SlimJimHazard || 
                      hazard is PlayerSpeedHazard, Is.True);
    }
    

}