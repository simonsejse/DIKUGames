using Breakout.Entities;
using Breakout.Entities.BlockTypes;
using Breakout.GameModifiers.PowerUps;
using Breakout.States.GameRunning;
using Breakout.Utility;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.GUI;
using DIKUArcade.Math;
using DIKUArcade.Physics;

namespace BreakoutTests.EntitiesTest;

[TestFixture]
public class CollisionProcessorTests
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
        

        Assert.That(playerEntity.GetPoints(), Is.EqualTo(0));
    }
    
    
}