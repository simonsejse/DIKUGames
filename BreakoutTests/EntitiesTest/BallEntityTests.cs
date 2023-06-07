using Breakout.Entities;
using Breakout.Utility;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.GUI;
using DIKUArcade.Math;
using DIKUArcade.Physics;

namespace BreakoutTests.BreakoutTests;

/// <summary>
/// We have mainly used the Test-Driven Development Approach for these tests
/// </summary>
[TestFixture]
public class BallEntityTests
{
    private BallEntity ballEntity;
    
    [SetUp]
    public void Setup()
    {
        Window.CreateOpenGLContext();
        ballEntity = BallEntity.Create(PositionUtil.BallPosition, PositionUtil.BallExtent, PositionUtil.BallDirection, false);
    }

    [Test]
    public void TestMove()
    {
        Vec2F initialPosition = new Vec2F(0.5f, 0.5f);
        Vec2F extent = new Vec2F(0.1f, 0.1f);
        Vec2F direction = new Vec2F(1.0f, 0.0f);
        float speed = 0.2f;
        bool isBallStuck = false;
        IBaseImage defaultBallImage = new Image(Path.Combine("Assets", "Images", "ball.png"));
        BallEntity ballEntity = new BallEntity(new DynamicShape(initialPosition, extent), defaultBallImage, null, direction, speed, isBallStuck);

        ballEntity.Move();

        Assert.That(ballEntity.Shape.Position.X, Is.Not.EqualTo(initialPosition.X));
        Assert.That(ballEntity.Shape.Position.Y, Is.EqualTo(initialPosition.Y));


        ballEntity.Shape.Position = new Vec2F(-extent.X, 0.5f);
        ballEntity.Move();
        Assert.That(ballEntity.GetDirection().X, Is.Not.EqualTo(Math.Abs(direction.X)));

        ballEntity.Shape.Position = new Vec2F(1.0f + extent.X, 0.5f);
        ballEntity.Move();
        Assert.That(ballEntity.GetDirection().X, Is.Not.EqualTo(-Math.Abs(direction.X)));

        ballEntity.Shape.Position = new Vec2F(0.5f, 1.0f + extent.Y);
        ballEntity.Move();
        Assert.That(ballEntity.GetDirection().Y, Is.EqualTo(-direction.Y));

        ballEntity.Shape.Position = new Vec2F(-extent.X - 0.1f, 0.5f);
        ballEntity.Move();
        Assert.That(ballEntity.GetDirection().X, Is.Not.EqualTo(Math.Abs(direction.X)));
    }

    
    [Test]
    public void TestBallBounceOff()
    {
        // Arrange
        Vec2F direction = new Vec2F(1.0f, 1.0f);
        BallEntity ballEntity = new BallEntity(null, null, null, direction, 0.0f, false);


        ballEntity.BallBounceOff(CollisionDirection.CollisionDirUp);
        Assert.That(ballEntity.GetDirection().X, Is.EqualTo(direction.X));
        Assert.That(ballEntity.GetDirection().Y, Is.EqualTo(direction.Y));
        
        ballEntity.BallBounceOff(CollisionDirection.CollisionDirDown);
        Assert.That(ballEntity.GetDirection().X, Is.EqualTo(direction.X));
        Assert.That(ballEntity.GetDirection().Y, Is.EqualTo(direction.Y));
        
        ballEntity.BallBounceOff(CollisionDirection.CollisionDirLeft);
        Assert.That(ballEntity.GetDirection().X, Is.EqualTo(direction.X));
        Assert.That(ballEntity.GetDirection().Y, Is.EqualTo(direction.Y));
        
        ballEntity.BallBounceOff(CollisionDirection.CollisionDirRight);
        Assert.That(ballEntity.GetDirection().X, Is.EqualTo(direction.X));
        Assert.That(ballEntity.GetDirection().Y, Is.EqualTo(direction.Y));
        
        ballEntity.BallBounceOff(CollisionDirection.CollisionDirUnchecked);
        Assert.That(ballEntity.GetDirection().X, Is.EqualTo(direction.X));
        Assert.That(ballEntity.GetDirection().Y, Is.EqualTo(direction.Y));
        
        Assert.Throws<ArgumentOutOfRangeException>(() => ballEntity.BallBounceOff((CollisionDirection)99));
    }


    
    [Test]
    public void TestMoveStuck()
    {
        ballEntity = BallEntity.Create(PositionUtil.BallPosition, PositionUtil.BallExtent, PositionUtil.BallDirection, true);

        var initPos = ballEntity.Shape.Position;

        Assert.That(ballEntity.Shape.Position, Is.EqualTo(initPos));
        ballEntity.Move();
        Assert.That(ballEntity.Shape.Position, Is.EqualTo(initPos));
    }
    
    [Test]
    public void TestOutOfBounds()
    {
        ballEntity = BallEntity.Create(PositionUtil.BallPosition, PositionUtil.BallExtent, PositionUtil.BallDirection, true);
        
        ballEntity.Shape.Position.Y = -0.2f;
        
        bool isOutOfBounds = ballEntity.OutOfBounds();

        Assert.That(isOutOfBounds, Is.True);
    }

    [Test]
    public void TestMarkForDeletion()
    {
        Assert.IsFalse(ballEntity.IsMarkedForDeletion());
        
        ballEntity.MarkForDeletion();
        
        Assert.IsTrue(ballEntity.IsMarkedForDeletion());
    }
    
    [Test]
    public void TestChangeDirection()
    {
        ballEntity.SetDirection(new Vec2F(1f, 1f));

        ballEntity.ChangeDirection(2f, -2f);
        Assert.That(ballEntity.GetDirection().X, Is.EqualTo(2f).Within(0.0001f));
        Assert.That(ballEntity.GetDirection().Y, Is.EqualTo(-2f).Within(0.0001f));
    }
    
    [Test]
    public void TestLaunch()
    {
        ballEntity.SetDirection(new Vec2F(0.5f, 0.5f));

        ballEntity.Launch();
        var normalizedDirection = Vec2F.Normalize(new Vec2F(0.5f, 0.5f));
        Assert.That(ballEntity.GetDirection().X, Is.EqualTo(normalizedDirection.X).Within(0.0001f));
        Assert.That(ballEntity.GetDirection().Y, Is.EqualTo(normalizedDirection.Y).Within(0.0001f));
    }

    [Test]
    public void TestMultiplyExtent()
    {
        ballEntity = BallEntity.Create(PositionUtil.BallPosition, PositionUtil.BallExtent, PositionUtil.BallDirection, true);

        Vec2F factor = new Vec2F(2.0f, 2.0f);
        ballEntity.MultiplyExtent(factor);
        
        Vec2F expectedExtent = new Vec2F(PositionUtil.BallExtent.X * factor.X, PositionUtil.BallExtent.Y * factor.Y);
        
        Assert.That(ballEntity.Shape.Extent.X, Is.EqualTo(expectedExtent.X).Within(0.0001f));
        Assert.That(ballEntity.Shape.Extent.Y, Is.EqualTo(expectedExtent.Y).Within(0.0001f));
    }
    
    [Test]
    public void TestCreate()
    {
        Vec2F pos = new Vec2F(1.0f, 1.0f);
        Vec2F extent = new Vec2F(2.0f, 2.0f);
        Vec2F direction = new Vec2F(0.5f, 0.5f);
        bool isBallStuck = true;
        
        BallEntity ballEntity = BallEntity.Create(pos, extent, direction, isBallStuck);
        
        Assert.That(ballEntity.Shape.Position, Is.EqualTo(pos));
        Assert.That(ballEntity.Shape.Extent, Is.EqualTo(extent));
        Assert.That(ballEntity.GetDirection(), Is.EqualTo(direction));
        Assert.That(ballEntity.IsBallStuck, Is.EqualTo(isBallStuck));
    }
    
    [Test]
    public void TestBallEntityConstructor_ClonePattern()
    {
        Vec2F pos = new Vec2F(0.5f, 0.5f);
        Vec2F extent = new Vec2F(0.1f, 0.1f);
        Vec2F direction = new Vec2F(1.0f, 0.5f);
        float speed = 2.0f;
        bool isBallStuck = true;
        IBaseImage defaultBallImage = new Image(Path.Combine("Assets", "Images", "ball.png"));
        IBaseImage hardBallImage = new Image(Path.Combine("Assets", "Images", "ball2.png"));
        BallEntity originalBall = new BallEntity(new DynamicShape(pos, extent), defaultBallImage, hardBallImage, direction, speed, isBallStuck);

        BallEntity clonedBall = originalBall.Clone();
        
        Assert.That(clonedBall.Shape.Position.X, Is.EqualTo(originalBall.Shape.Position.X));
        Assert.That(clonedBall.Shape.Position.Y, Is.EqualTo(originalBall.Shape.Position.Y));
        Assert.That(clonedBall.Shape.Extent.X, Is.EqualTo(originalBall.Shape.Extent.X));
        Assert.That(clonedBall.Shape.Extent.Y, Is.EqualTo(originalBall.Shape.Extent.Y));
        Assert.That(clonedBall.Image, Is.EqualTo(originalBall.Image));
        Assert.That(clonedBall.GetDirection(), Is.EqualTo(originalBall.GetDirection()));
        Assert.That(clonedBall.IsBallStuck, Is.EqualTo(originalBall.IsBallStuck));
    }
    

}