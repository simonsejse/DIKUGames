using System.Data;
using Breakout.Factories;
using Breakout.IO;
using Breakout.Entities;
using Breakout.Utility;
using DIKUArcade.GUI;
using DIKUArcade.Math;
using Breakout.PowerUps;

namespace BreakoutTests.PowerUpHazardTests;

/// <summary>
/// We have mainly used the Test-Driven Development Approach for these tests
/// </summary>
public class PowerUpTests
{
    private readonly List<IPowerUp> PowerUps = new List<IPowerUp>()
    {
        new ExtraLifePowerUp(),
        new WidePowerUp(),
        new BigBallPowerUp(),
        new SplitBallPowerUp()
    };

    [SetUp]
    public void Setup()
    {
        Window.CreateOpenGLContext();
    }

    [Test]
    public void TestPowerUp()
    {
        foreach(IPowerUp powerUp in PowerUps) 
        {
            Assert.That(powerUp.GetImage(), Is.Not.Null);
            Assert.That(powerUp.Activator(), Is.Not.Null);
        }
    }

    [Test]
    public void TestExtraLifePowerUp()
    {
        IPowerUp extraLifePowerUp = new ExtraLifePowerUp();
    }
}