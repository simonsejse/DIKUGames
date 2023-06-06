using Breakout.Containers;
using Breakout.Entities;
using Breakout.GameModifiers;
using Breakout.Hazard.Activators;
using Breakout.PowerUps.Activators;
using Breakout.States.GameRunning;
using Breakout.Utility;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.GUI;
using DIKUArcade.Math;

namespace BreakoutTests.ContainersTest;

[TestFixture]
public class EntityManagerTests
{
    private EntityManager entityManager;
    private GameRunningState gameRunningState;
    private EntityContainer<BlockEntity> blockEntities;
    private BallEntity ballEntity;
    private PlayerEntity playerEntity;

    [SetUp]
    public void Setup()
    {
        Window.CreateOpenGLContext();
        blockEntities = new EntityContainer<BlockEntity>();
        ballEntity = BallEntity.Create(PositionUtil.BallPosition, PositionUtil.BallExtent, PositionUtil.BallDirection, false);
        playerEntity = new PlayerEntity(new DynamicShape(PositionUtil.PlayerPosition, PositionUtil.PlayerExtent),
            new Image(Path.Combine(Directory.GetCurrentDirectory(), "Assets", "Images", "Player.png"))
        );
        gameRunningState = new GameRunningState();
    }
    
    [Test]
    public void TestMove()
    {
        GameRunningState state = new GameRunningState();
        EntityManager entityManager = new EntityManager(state);
        BallEntity ball1 = BallEntity.Create(PositionUtil.BallPosition, PositionUtil.BallExtent, PositionUtil.BallDirection, false);
        BallEntity ball2 = BallEntity.Create(PositionUtil.BallPosition, PositionUtil.BallExtent, PositionUtil.BallDirection, false);
        entityManager.BallEntities.AddEntity(ball1);
        entityManager.BallEntities.AddEntity(ball2);
        
        entityManager.Move();

        Assert.Multiple(() =>
        {
            Assert.That(ball1.Shape.Position.X, Is.Not.EqualTo(PositionUtil.BallDirection.X));
            Assert.That(ball1.Shape.Position.Y, Is.Not.EqualTo(PositionUtil.BallDirection.Y));

            Assert.That(ball2.Shape.Position.X, Is.Not.EqualTo(PositionUtil.BallDirection.X));
            Assert.That(ball2.Shape.Position.Y, Is.Not.EqualTo(PositionUtil.BallDirection.Y));

            Assert.That(entityManager.BallEntities.CountEntities(), Is.EqualTo(2));
        });
    }
    
    [Test]
    public void TestPowerUpEntityBehavior()
    {
        GameRunningState state = new GameRunningState();
        EntityManager entityManager = new EntityManager(state);

        PlayerEntity player = PlayerEntity.Create();

        IGameModifierActivator gameModifierActivator = new HealthPowerUpActivator(playerEntity);
        var startpos = new Vec2F(0.5f, 0.5f);
        GameModifierEntity powerUp = GameModifierEntity.Create(startpos,
            new Image(Path.Combine("Assets", "Images", "LifePickUp.png")),
            gameModifierActivator
        );
        entityManager.PowerUpEntities.AddEntity(powerUp);

        entityManager.Move();

        Assert.That(powerUp.Shape.Position.X, Is.EqualTo(startpos.X));
        Assert.That(powerUp.Shape.Position.Y, Is.Not.EqualTo(startpos.Y));
    }
    
    [Test]
    public void TestHazardEntityBehavior()
    {
        GameRunningState state = new GameRunningState();
        EntityManager entityManager = new EntityManager(state);

        PlayerEntity player = PlayerEntity.Create();

        IGameModifierActivator gameModifierActivator = new LoseLifeHzActivator(playerEntity);
        var startpos = new Vec2F(0.5f, 0.5f);
        GameModifierEntity hazard = GameModifierEntity.Create(startpos,
            new Image(Path.Combine("Assets", "Images", "LoseLife.png")),
            gameModifierActivator
        );
        entityManager.HazardEntities.AddEntity(hazard);

        entityManager.Move();

        Assert.That(hazard.Shape.Position.X, Is.EqualTo(startpos.X));
        Assert.That(hazard.Shape.Position.Y, Is.Not.EqualTo(startpos.Y));
    }
    
}