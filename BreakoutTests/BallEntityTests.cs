using System.Data;
using Breakout.Factories;
using Breakout.IO;
using Breakout.Entities;
using DIKUArcade.GUI;
using DIKUArcade.Math;

namespace BreakoutTests;

/// <summary>
/// We have mainly used the Test-Driven Development Approach for these tests
/// </summary>
public class BallEntityTests
{
    private BallEntity ballEntity;
    
    [SetUp]
    public void Setup()
    {
        ballEntity = BallEntity.Create(0.1f, new Vec2F(0.01f, 0.01f));
    }

    [Test]
    public void TestMove()
    {
        var initPos = ballEntity.Shape.Position;

        Assert.That(ballEntity.Shape.Position, Is.EqualTo(initPos));
        ballEntity.Move();
        Assert.That(ballEntity.Shape.Position, Is.Not.EqualTo(initPos));
    }

  
}