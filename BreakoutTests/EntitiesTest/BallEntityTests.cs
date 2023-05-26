using System.Data;
using Breakout.Factories;
using Breakout.IO;
using Breakout.Entities;
using Breakout.Utility;
using DIKUArcade.GUI;
using DIKUArcade.Math;

namespace BreakoutTests.BreakoutTests;

/// <summary>
/// We have mainly used the Test-Driven Development Approach for these tests
/// </summary>
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

  
}