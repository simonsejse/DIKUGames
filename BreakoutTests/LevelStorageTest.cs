using System.Data;
using Breakout.Entities;
using Breakout.Factories;
using Breakout.IO;
using Breakout.Storage;
namespace BreakoutTests;

/// <summary>
/// We have mainly used the Test-Driven Development Approach for these tests
/// </summary>
public class LevelStorageTest
{
    private LevelStorage _levelStorage;
    
    [SetUp]
    public void Setup()
    {
        _levelStorage = new LevelStorage();
    }

    
    [Test]
    public void TestCentralMass()
    {
        Assert.That(_levelStorage.LevelPaths, Has.Count.EqualTo(6));
    }
    
    
  
}