using Breakout.Factories;

namespace BreakoutTests;

public class LevelTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestLevel1()
    {
        var levelFactory = new LevelFactory();
        var levels = levelFactory.Parse("");
        
        
        
        Assert.That(levels, Is.Empty);
    }
}