using System.Data;
using Breakout.Containers;
using Breakout.Factories;
using Breakout.IO;
using Breakout.Entities;
using Breakout.Utility;
using DIKUArcade.GUI;
using DIKUArcade.Math;
using Breakout.PowerUps;
using Breakout.PowerUps.Activators;
using Breakout.States.GameRunning;
using DIKUArcade.Entities;

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
        new SplitBallPowerUp(),
        new PlayerSpeedPowerUp()
    };

    [SetUp]
    public void Setup()
    {
        Window.CreateOpenGLContext();
    }

    [Test]
    public void TestPowerUp()
    {
        foreach (IPowerUp powerUp in PowerUps)
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

    [Test]
    public void TestPlayerSpeedPowerUpActivator()
    {
        PlayerEntity playerEntity = PlayerEntity.Create();
        IPowerUpActivator activator = new PlayerSpeedPowerUpActivator(playerEntity);
        float initialSpeed = playerEntity.GetPlayerMovementSpeed();

        activator.Activate();

        Assert.That(playerEntity.GetPlayerMovementSpeed(), Is.EqualTo(initialSpeed * 2.0f));
    }

    [Test]
    public void TestWidePowerUpActivator()
    {
        PlayerEntity playerEntity = PlayerEntity.Create();
        IPowerUpActivator activator = new WidePowerUpActivator(playerEntity);
        Vec2F initialExtent = playerEntity.Shape.Extent;

        activator.Activate();

        Assert.That(playerEntity.Shape.Extent.X, Is.EqualTo(initialExtent.X * 1.5f).Within(0.001f));
        Assert.That(playerEntity.Shape.Extent.Y, Is.EqualTo(initialExtent.Y).Within(0.001f));

        Task.Delay(5500).Wait();

        Assert.That(playerEntity.Shape.Extent.X, Is.EqualTo(initialExtent.X).Within(0.001f));
        Assert.That(playerEntity.Shape.Extent.Y, Is.EqualTo(initialExtent.Y).Within(0.001f));
    }

    [Test]
    public void TestBigBallPowerUpActivator()
    {
        GameRunningState gameRunningState = new GameRunningState();
        EntityManager entityManager = new EntityManager(gameRunningState);

        BallEntity ball1 = BallEntity.Create(new Vec2F(0.5f, 0.5f), new Vec2F(0.03f, 0.03f), new Vec2F(0.01f, 0.01f),
            false);
        BallEntity ball2 = BallEntity.Create(new Vec2F(0.3f, 0.7f), new Vec2F(0.02f, 0.02f), new Vec2F(-0.02f, -0.01f),
            true);
        BallEntity ball3 = BallEntity.Create(new Vec2F(0.8f, 0.2f), new Vec2F(0.04f, 0.04f), new Vec2F(-0.01f, 0.02f),
            false);

        entityManager.BallEntities.AddEntity(ball1);
        entityManager.BallEntities.AddEntity(ball2);
        entityManager.BallEntities.AddEntity(ball3);

        IPowerUpActivator activator = new BigBallPowerUpActivator(entityManager);

        Assert.Multiple(() =>
        {
            Assert.That(ball1.Shape.Extent.X, Is.EqualTo(0.03f).Within(0.001f));
            Assert.That(ball1.Shape.Extent.Y, Is.EqualTo(0.03f).Within(0.001f));

            Assert.That(ball2.Shape.Extent.X, Is.EqualTo(0.02f).Within(0.001f));
            Assert.That(ball2.Shape.Extent.Y, Is.EqualTo(0.02f).Within(0.001f));

            Assert.That(ball3.Shape.Extent.X, Is.EqualTo(0.04f).Within(0.001f));
            Assert.That(ball3.Shape.Extent.Y, Is.EqualTo(0.04f).Within(0.001f));
        });

        activator.Activate();

        Assert.Multiple(() =>
        {
            Assert.That(ball1.Shape.Extent.X, Is.EqualTo(0.045f).Within(0.001f));
            Assert.That(ball1.Shape.Extent.Y, Is.EqualTo(0.045f).Within(0.001f));

            Assert.That(ball2.Shape.Extent.X, Is.EqualTo(0.03f).Within(0.001f));
            Assert.That(ball2.Shape.Extent.Y, Is.EqualTo(0.03f).Within(0.001f));

            Assert.That(ball3.Shape.Extent.X, Is.EqualTo(0.06f).Within(0.001f));
            Assert.That(ball3.Shape.Extent.Y, Is.EqualTo(0.06f).Within(0.001f));
        });

        Task.Delay(5500).Wait();

        Assert.Multiple(() =>
        {
            Assert.That(ball1.Shape.Extent.X, Is.EqualTo(0.03f).Within(0.001f));
            Assert.That(ball1.Shape.Extent.Y, Is.EqualTo(0.03f).Within(0.001f));

            Assert.That(ball2.Shape.Extent.X, Is.EqualTo(0.02f).Within(0.001f));
            Assert.That(ball2.Shape.Extent.Y, Is.EqualTo(0.02f).Within(0.001f));

            Assert.That(ball3.Shape.Extent.X, Is.EqualTo(0.04f).Within(0.001f));
            Assert.That(ball3.Shape.Extent.Y, Is.EqualTo(0.04f).Within(0.001f));
        });


    }
    
    
}
    