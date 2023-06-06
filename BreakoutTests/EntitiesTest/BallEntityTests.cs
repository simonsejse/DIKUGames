using System.Data;
using Breakout.Factories;
using Breakout.IO;
using Breakout.Entities;
using Breakout.Utility;
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
        var initPos = ballEntity.Shape.Position;

        Assert.That(ballEntity.Shape.Position, Is.EqualTo(initPos));
        ballEntity.Move();
        Assert.That(ballEntity.Shape.Position, Is.Not.EqualTo(initPos));
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

}