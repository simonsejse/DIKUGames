using Breakout.Containers;
using Breakout.Entities;
using Breakout.States.GameRunning;
using Breakout.Utility;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.GUI;

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



}