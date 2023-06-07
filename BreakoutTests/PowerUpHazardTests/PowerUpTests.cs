using Breakout.Containers;
using Breakout.Entities;
using Breakout.GameModifiers;
using Breakout.GameModifiers.PowerUps;
using Breakout.GameModifiers.PowerUps.Activators;
using Breakout.Utility;
using DIKUArcade.GUI;
using DIKUArcade.Math;
using Breakout.PowerUps.Activators;
using Breakout.States.GameRunning;

namespace BreakoutTests.PowerUpHazardTests;

/// <summary>
/// We have mainly used the Test-Driven Development Approach for these tests
/// </summary>
[TestFixture]
public class PowerUpTests
{
    private readonly List<IGameModifier> PowerUps = new()
    {
        new ExtraLifePowerUp(),
        new WidePowerUp(),
        new BigBallPowerUp(),
        new SplitBallPowerUp(),
        new PlayerSpeedGameModifier()
    };

    [SetUp]
    public void Setup()
    {
        Window.CreateOpenGLContext();
    }

    [Test]
    public void TestPowerUp()
    {
        foreach (IGameModifier powerUp in PowerUps)
        {
            Assert.That(powerUp.GetImage(), Is.Not.Null);
            Assert.That(powerUp.Activator(), Is.Not.Null);
        }
    }

    [Test]
    public void TestExtraLifePowerUp()
    {
        IGameModifier extraLifeGameModifier = new ExtraLifePowerUp();
    }
    

    [Test]
    public void TestWidePowerUpActivator()
    {
        PlayerEntity playerEntity = PlayerEntity.Create();
        IGameModifierActivator activator = new WideGameModifierActivator(playerEntity);
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

        IGameModifierActivator activator = new BigBallPowerUpActivator(entityManager);

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
    
    [Test]
    public async Task TestPlayerSpeedPowerUpActivator()
    {
        PlayerEntity playerEntity = PlayerEntity.Create();
        float initialSpeed = playerEntity.GetPlayerMovementSpeed();
        float expectedSpeed = initialSpeed * GameUtil.PlayerSpeedFactor;

        PlayerSpeedPowerUpActivator activator = new PlayerSpeedPowerUpActivator(playerEntity);
        
        activator.Activate();
        
        Assert.That(playerEntity.GetPlayerMovementSpeed(), Is.EqualTo(expectedSpeed).Within(0.001f));
        
        await Task.Delay(5500);
        
        Assert.That(playerEntity.GetPlayerMovementSpeed(), Is.EqualTo(initialSpeed).Within(0.001f));
    }
    
    [Test]
    public void GetRandomPowerUp_NonNull()
    {
        IGameModifier gameModifier = GameModifierStorage.GetRandomPowerUp();
        
        Assert.That(gameModifier, Is.Not.Null);
    }
    
    [Test]
    public void GetRandomPowerUp_GivenPowerUpType()
    {
        IGameModifier gameModifier = GameModifierStorage.GetRandomPowerUp();
        
        Assert.That(gameModifier is ExtraLifePowerUp ||
                      gameModifier is WidePowerUp ||
                      gameModifier is BigBallPowerUp ||
                      gameModifier is SplitBallPowerUp ||
                      gameModifier is HardBallPowerUp ||
                      gameModifier is PlayerSpeedGameModifier, Is.True);
    }
    
    [Test]
    public void TestSplitBallPowerUpActivator()
    {
        GameRunningState gameRunningState = new GameRunningState();
        EntityManager entityManager = new EntityManager(gameRunningState);

        var ball1 = BallEntity.Create(new Vec2F(0.5f, 0.5f), new Vec2F(0.03f, 0.03f), new Vec2F(0.01f, 0.01f), false);
        var ball2 = BallEntity.Create(new Vec2F(0.3f, 0.7f), new Vec2F(0.02f, 0.02f), new Vec2F(-0.02f, -0.01f), true);
        var ball3 = BallEntity.Create(new Vec2F(0.8f, 0.2f), new Vec2F(0.04f, 0.04f), new Vec2F(-0.01f, 0.02f), false);

        entityManager.BallEntities.AddEntity(ball1);
        entityManager.BallEntities.AddEntity(ball2);
        entityManager.BallEntities.AddEntity(ball3);

        var activator = new SplitBallGameModifierActivator(entityManager);
        
        activator.Activate();
        
        var newBalls = new List<BallEntity>();
        foreach (var ball in entityManager.BallEntities)
        {
            newBalls.Add((BallEntity)ball);
        }

        Assert.That(newBalls.Count, Is.EqualTo(12));
        
        foreach (var ball in newBalls)
        {
            Assert.That(ball.HardBallMode, Is.False);
        }
    }

    
    [Test]
    public void TestHardBallPowerUpActivator()
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

        HardBallPowerUpActivator activator = new HardBallPowerUpActivator(entityManager);
        
        activator.Activate();
        
        Assert.Multiple(() =>
        {
            Assert.That(ball1.Image, Is.EqualTo(ball1.HardBallImage));
            Assert.That(ball1.HardBallMode, Is.True);

            Assert.That(ball2.Image, Is.EqualTo(ball2.HardBallImage));
            Assert.That(ball2.HardBallMode, Is.True);

            Assert.That(ball3.Image, Is.EqualTo(ball3.HardBallImage));
            Assert.That(ball3.HardBallMode, Is.True);
        });

        Task.Delay(5500).Wait();

        Assert.Multiple(() =>
        {
            Assert.That(ball1.Image, Is.EqualTo(ball1.DefaultBallImage));
            Assert.That(ball1.HardBallMode, Is.False);

            Assert.That(ball2.Image, Is.EqualTo(ball2.DefaultBallImage));
            Assert.That(ball2.HardBallMode, Is.False);

            Assert.That(ball3.Image, Is.EqualTo(ball3.DefaultBallImage));
            Assert.That(ball3.HardBallMode, Is.False);
        });
    }
    
}
    