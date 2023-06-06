using System.Data;
using Breakout.Factories;
using Breakout.IO;
using Breakout.Entities;
using Breakout.Entities.BlockTypes;
using Breakout.GameModifiers.PowerUps;
using Breakout.PowerUps;
using Breakout.States.GameRunning;
using Breakout.Utility;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.GUI;
using DIKUArcade.Math;
using DIKUArcade.Physics;

namespace BreakoutTests.EntitiesTest;

[TestFixture]
public class CollisionManagerTests
{
    private EntityContainer<BlockEntity> blockEntities;
    private BallEntity ballEntity;
    private PlayerEntity playerEntity;
    private GameRunningState gameRunningState;
    
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
    public void TestCheckBlockCollisions_ColFalse()
    {
        var block = BlockEntity.Create(
            new Vec2F(0.5f, 0.5f),
            new Image(Path.Combine("Assets", "Images", "teal-block.png")), 
            new Image(Path.Combine("Assets", "Images", "teal-block-damaged.png")),
            new StandardBlockType(), 
            new ExtraLifePowerUp(),
            null
        );
        blockEntities.AddEntity(block);
        
        CollisionProcessor.CheckBlockCollisions(blockEntities, ballEntity, playerEntity, gameRunningState);
        
        Assert.That(ballEntity.GetCollisionDirection(), Is.EqualTo(CollisionDirection.CollisionDirUnchecked));
        Assert.That(playerEntity.GetPoints(), Is.EqualTo(0));
    }
    
    [Test]
    public void TestCheckBallCollisions_ColFalse()
    {
        var ball1 = BallEntity.Create(new Vec2F(0.5f, 0.5f), new Vec2F(0.1f, 0.1f), new Vec2F(0.1f, 0.1f), false);
        var ball2 = BallEntity.Create(new Vec2F(0.8f, 0.8f), new Vec2F(0.1f, 0.1f), new Vec2F(0.1f, 0.1f), false);
        var ball3 = BallEntity.Create(new Vec2F(0.2f, 0.2f), new Vec2F(0.1f, 0.1f), new Vec2F(0.1f, 0.1f), false);

        var ballEntities = new EntityContainer<BallEntity>();
        ballEntities.AddEntity(ball1);
        ballEntities.AddEntity(ball2);
        ballEntities.AddEntity(ball3);

        CollisionProcessor.CheckBallCollisions(ball1, ballEntities);

        Assert.That(ball1.GetCollisionDirection(), Is.EqualTo(CollisionDirection.CollisionDirUnchecked));
        Assert.That(ball2.GetCollisionDirection(), Is.EqualTo(CollisionDirection.CollisionDirUnchecked));
        Assert.That(ball3.GetCollisionDirection(), Is.EqualTo(CollisionDirection.CollisionDirUnchecked));
    }
    
    [Test]
    public void TestCheckBallPlayerCollision_ColTrue()
    {
        var ball = BallEntity.Create(new Vec2F(0.5f, 0.9f), new Vec2F(0.1f, 0.1f), new Vec2F(0.1f, -0.1f), false);
        var player = PlayerEntity.Create();

        CollisionProcessor.CheckBallPlayerCollision(ball, player);
        
        Assert.That(ball.GetDirection(), Is.Not.EqualTo(new Vec2F(0.1f, -0.1f)));
        Assert.That(ball.Shape.Position, Is.Not.EqualTo(new Vec2F(0.5f, 0.9f)));
    }
    
    
    
    /*
    [Test]
    public void TestCheckBlockCollisions_ColTrue()
    {
        var block = BlockEntity.Create(
            new Vec2F(0.5f, 0.03f),
            new Image(Path.Combine("Assets", "Images", "teal-block.png")),
            new Image(Path.Combine("Assets", "Images", "teal-block-damaged.png")),
            new StandardBlockType(),
            new ExtraLifePowerUp()
        );
        blockEntities.AddEntity(block);

        ballEntity = BallEntity.Create(PositionUtil.BallPosition, PositionUtil.BallExtent, PositionUtil.BallDirection, false);
        ballEntity.Shape.SetPosition(new Vec2F(0.5f, 0.03f));

        CollisionProcessor.CheckBlockCollisions(blockEntities, ballEntity, playerEntity, gameRunningState);

        Assert.AreNotEqual(CollisionDirection.CollisionDirUnchecked, ballEntity.GetCollisionDirection());
        Assert.That(block.IsDead(), Is.True);
        Assert.That(playerEntity.GetPoints(), Is.EqualTo(block.Value));
    }
    
    [Test]
    public void TestCheckBallCollisions_ColTrue()
    {
        var ball1 = BallEntity.Create(new Vec2F(0.5f, 0.5f), new Vec2F(0.1f, 0.1f), new Vec2F(0.1f, 0.1f), false);
        var ball2 = BallEntity.Create(new Vec2F(0.55f, 0.55f), new Vec2F(0.1f, 0.1f), new Vec2F(0.1f, 0.1f), false);
        var ball3 = BallEntity.Create(new Vec2F(0.6f, 0.6f), new Vec2F(0.1f, 0.1f), new Vec2F(0.1f, 0.1f), false);

        var ballEntities = new EntityContainer<BallEntity>();
        ballEntities.AddEntity(ball1);
        ballEntities.AddEntity(ball2);
        ballEntities.AddEntity(ball3);

        CollisionProcessor.CheckBallCollisions(ball1, ballEntities);

        Assert.AreNotEqual(CollisionDirection.CollisionDirUnchecked, ball2.GetCollisionDirection());
        Assert.AreNotEqual(CollisionDirection.CollisionDirUnchecked, ball3.GetCollisionDirection());
    } */

    
}