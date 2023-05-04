using Breakout.Storage;
namespace BreakoutTests;

[TestFixture]
public class LevelStorageTest
{
    private LevelStorage _levelStorage;
    
    [SetUp]
    public void Setup()
    {
        _levelStorage = new LevelStorage();
    }

    
    [Test]
    public void TestLoadLevelStoragePaths()
    {
        Assert.That(_levelStorage.LevelPaths, Has.Count.EqualTo(6));
    }
    
    
  
}