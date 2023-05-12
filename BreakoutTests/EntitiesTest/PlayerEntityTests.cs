using Breakout.Entities;
using DIKUArcade.GUI;

namespace BreakoutTests.EntitiesTest;

[TestFixture]
public class PlayerEntityTests
{
    
    [SetUp]
    public void Setup()
    {
        Window.CreateOpenGLContext();
    }
    
    [Test]
    public void TestPlayerDefaultValues()
    {
        PlayerEntity playerEntity = PlayerEntity.Create();
        Assert.That(playerEntity, Is.Not.Null);
        Assert.That(playerEntity.Shape, Is.Not.Null);
        Assert.That(playerEntity.Image, Is.Not.Null);
        Assert.That(playerEntity.Shape.Position.X, Is.EqualTo(0.5f - 0.2f / 2f));
        Assert.That(playerEntity.Shape.Position.Y, Is.EqualTo(0.03f));
        Assert.That(playerEntity.Shape.Extent.X, Is.EqualTo(0.2f));
        Assert.That(playerEntity.Shape.Extent.Y, Is.EqualTo(0.028f));
    }

    [Test]
    public void TestPlayerMoveRight()
    {
        PlayerEntity playerEntity = PlayerEntity.Create();
        playerEntity.SetMoveRight(true);
        playerEntity.Move();
        Assert.That(playerEntity.Shape.Position.X, Is.GreaterThan(0.5f - 0.2f / 2f));
    }

    [Test]
    public void TestPlayerMoveLeft()
    {
        PlayerEntity playerEntity = PlayerEntity.Create();
        playerEntity.SetMoveLeft(true);
        playerEntity.Move();
        Assert.That(playerEntity.Shape.Position.X, Is.LessThan(0.5f - 0.2f / 2f));
    }

    [Test]
    public void TestPlayerPoints()
    {
        PlayerEntity playerEntity = PlayerEntity.Create();
        Assert.That(playerEntity.GetPoints(), Is.EqualTo(0));
        playerEntity.AddPoints(100);
        Assert.That(playerEntity.GetPoints(), Is.EqualTo(100));
        playerEntity.AddPoints(-100);
        Assert.That(playerEntity.GetPoints(), Is.EqualTo(100));
    }

    [Test]
    public void TestPlayerLives()
    {
        PlayerEntity playerEntity = PlayerEntity.Create();
        Assert.That(playerEntity.GetLives(), Is.EqualTo(3));
        playerEntity.TakeLife();
        Assert.That(playerEntity.GetLives(), Is.EqualTo(2));
        for (int i = 0; i < 10; i++)
        {
            playerEntity.TakeLife();
        }
        Assert.That(playerEntity.GetLives(), Is.EqualTo(0));
    }
}