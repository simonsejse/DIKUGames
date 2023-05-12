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
    public void TestPlayerFactoryCreation()
    {
        var playerEntity = PlayerEntity.Create();

        Assert.Multiple(() =>
        {
            Assert.That(playerEntity, Is.Not.Null);
            Assert.That(playerEntity.Shape, Is.Not.Null);
            Assert.That(playerEntity.Image, Is.Not.Null);
            Assert.That(playerEntity.Shape.Position.X, Is.EqualTo(0.5f - 0.2f / 2f));
            Assert.That(playerEntity.Shape.Position.Y, Is.EqualTo(0.03f));
            Assert.That(playerEntity.Shape.Extent.X, Is.EqualTo(0.2f));
            Assert.That(playerEntity.Shape.Extent.Y, Is.EqualTo(0.028f));
        });
    }
}