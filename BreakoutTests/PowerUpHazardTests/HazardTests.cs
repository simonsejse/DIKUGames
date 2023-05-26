using Breakout.Entities;
using DIKUArcade.GUI;
using Breakout.PowerUps;
using Breakout.Hazard;
using Breakout.Hazard.Activators;

namespace BreakoutTests.PowerUpHazardTests;

/// <summary>
/// We have mainly used the Test-Driven Development Approach for these tests
/// </summary>
public class HazardTests
{
    private readonly List<IPowerUp> Hazards = new List<IPowerUp>()
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
        foreach(IPowerUp hazard in Hazards) 
        {
            Assert.That(hazard.GetImage(), Is.Not.Null);
            Assert.That(hazard.Activator(), Is.Not.Null);
        }
    }

    [Test]
    public void LoseLifeHazard()
    {
        PlayerEntity player = PlayerEntity.Create();
        IPowerUp extraLifePowerUp = new LoseLifeHazard();
        IPowerUpActivator activator = new LoseLifeHzActivator(player);
        Assert.That(player.GetLives(), Is.EqualTo(3));
        activator.Activate();
        Assert.That(player.GetLives(), Is.LessThan(3));
    }

    [Test]
    public void SlimJimHazard()
    {
        PlayerEntity player = PlayerEntity.Create();
        IPowerUp extraLifePowerUp = new SlimJimHazard();
        IPowerUpActivator activator = new SlimJimHzActivator(player);
        Assert.That(player.Shape.Extent.X, Is.EqualTo(0.2f));
        Assert.That(player.Shape.Extent.Y, Is.EqualTo(0.028f));
        activator.Activate();
        Assert.That(player.Shape.Extent.X, Is.LessThan(0.2f));
        Assert.That(player.Shape.Extent.Y, Is.LessThan(0.028f));
    }
}