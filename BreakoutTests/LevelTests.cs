using Breakout.Factories;
using Breakout.IO;

namespace BreakoutTests;

/// <summary>
/// We have mainly used the Test-Driven Development Approach for these tests
/// </summary>
public class LevelTests
{
    [SetUp]
    public void Setup()
    {
    }

    
    [Test]
    public void TestCentralMass()
    {
        var levelFactory = new LevelFactory();
        
        FileReader.ReadFileFromPath(Path.Combine("Assets", "Levels", "central-mass.txt"), out var data);

        var level = levelFactory.Parse(data);
        
        Assert.That(level.Map, Is.Not.Empty);
        Assert.That(level.Map, Has.Length.EqualTo(24));
        foreach(var column in level.Map) Assert.That(column, Has.Length.EqualTo(12));
        
        foreach (var row in level.Map)
        {
            foreach (var @char in row)
            {
                if (@char is '-' or '\r' or '\n' or '\u0000') continue;
                Assert.That(level.Legends, Contains.Key(@char));
            }
        }

        Assert.Multiple(() =>
        {
            Assert.That(level.Meta.Name, Is.EqualTo("Central Mass"));
            Assert.That(level.Meta.Time, Is.Null);
            Assert.That(level.Meta.Hardened, Is.Null);
            Assert.That(level.Meta.PowerUp, Is.Null);
            Assert.That(level.Meta.Unbreakable, Is.Null);
            Assert.That(level.Legends, Contains.Key('#'));
            Assert.That(level.Legends, Contains.Key('%'));
            Assert.That(level.Legends, Contains.Value("red-block.png"));
            Assert.That(level.Legends, Contains.Value("orange-block.png"));
        });
    }
    
    [Test]
    public void TestColumns()
    {
        var levelFactory = new LevelFactory();
        
        FileReader.ReadFileFromPath(Path.Combine("Assets", "Levels", "columns.txt"), out var data);

        var level = levelFactory.Parse(data);
        
        Assert.That(level.Map, Is.Not.Empty);
        Assert.That(level.Map, Has.Length.EqualTo(24));
        foreach(var column in level.Map) Assert.That(column, Has.Length.EqualTo(12));
        
        foreach (var row in level.Map)
        {
            foreach (var @char in row)
            {
                if (@char is '-' or '\r' or '\n' or '\u0000') continue;
                Assert.That(level.Legends, Contains.Key(@char));
            }
        }

        Assert.Multiple(() =>
        {
            Assert.That(level.Meta.Name, Is.EqualTo("Columns"));
            Assert.That(level.Meta.Time, Is.Null);
            Assert.That(level.Meta.Hardened, Is.Null);
            Assert.That(level.Meta.PowerUp, Is.Null);
            Assert.That(level.Meta.Unbreakable, Is.Null);
            Assert.That(level.Legends, Contains.Key('#'));
            Assert.That(level.Legends, Contains.Key('%'));
            Assert.That(level.Legends, Contains.Value("red-block.png"));
            Assert.That(level.Legends, Contains.Value("orange-block.png"));
        });
    }
    
    
    [Test]
    public void TestWall()
    {
        var levelFactory = new LevelFactory();
        
        FileReader.ReadFileFromPath(Path.Combine("Assets", "Levels", "wall.txt"), out var data);

        var level = levelFactory.Parse(data);
        
        Assert.That(level.Map, Is.Not.Empty);
        Assert.That(level.Map, Has.Length.EqualTo(24));
        foreach(var column in level.Map) Assert.That(column, Has.Length.EqualTo(12));
        
        foreach (var row in level.Map)
        {
            foreach (var @char in row)
            {
                if (@char is '-' or '\r' or '\n' or '\u0000') continue;
                Assert.That(level.Legends, Contains.Key(@char));
            }
        }

        Assert.Multiple(() =>
        {
            Assert.That(level.Meta.Name, Is.EqualTo("Central Mass"));
            Assert.That(level.Meta.Time, Is.Null);
            Assert.That(level.Meta.Hardened, Is.Null);
            Assert.That(level.Meta.PowerUp, Is.Null);
            Assert.That(level.Meta.Unbreakable, Is.Null);
            Assert.That(level.Legends, Contains.Key('#'));
            Assert.That(level.Legends, Contains.Key('%'));
            Assert.That(level.Legends, Contains.Value("red-block.png"));
            Assert.That(level.Legends, Contains.Value("orange-block.png"));
        });
    }
    
    [Test]
    public void TestLevel1()
    {
        var levelFactory = new LevelFactory();
        
        FileReader.ReadFileFromPath(Path.Combine("Assets", "Levels", "level1.txt"), out var data);

        var level = levelFactory.Parse(data);
        
        Assert.That(level.Map, Is.Not.Empty);
        Assert.That(level.Map, Has.Length.EqualTo(25));
        foreach(var column in level.Map) Assert.That(column, Has.Length.EqualTo(12));
        
        foreach (var row in level.Map)
        {
            foreach (var @char in row)
            {
                if (@char is '-' or '\r' or '\n' or '\u0000') continue;
                Assert.That(level.Legends, Contains.Key(@char));
            }
        }

        Assert.Multiple(() =>
        {
            Assert.That(level.Meta.Name, Is.EqualTo("LEVEL 1"));
            Assert.That(level.Meta.Time, Is.EqualTo(300));
            Assert.That(level.Meta.Hardened, Is.EqualTo('#'));
            Assert.That(level.Meta.PowerUp, Is.EqualTo('2'));
            Assert.That(level.Meta.Unbreakable, Is.Null);
            Assert.That(level.Legends, Contains.Key('%'));
            Assert.That(level.Legends, Contains.Key('0'));
            Assert.That(level.Legends, Contains.Key('1'));
            Assert.That(level.Legends, Contains.Key('a'));
            Assert.That(level.Legends, Contains.Value("blue-block.png"));
            Assert.That(level.Legends, Contains.Value("grey-block.png"));
            Assert.That(level.Legends, Contains.Value("orange-block.png"));
            Assert.That(level.Legends, Contains.Value("purple-block.png"));
        });
    }
    
    [Test]
    public void TestLevel2()
    {
        var levelFactory = new LevelFactory();
        
        FileReader.ReadFileFromPath(Path.Combine("Assets", "Levels", "level2.txt"), out var data);

        var level = levelFactory.Parse(data);
        
        Assert.That(level.Map, Is.Not.Empty);
        Assert.That(level.Map, Has.Length.EqualTo(25));
        foreach(var column in level.Map) Assert.That(column, Has.Length.EqualTo(12));
        
        foreach (var row in level.Map)
        {
            foreach (var @char in row)
            {
                if (@char is '-' or '\r' or '\n' or '\u0000') continue;
                Assert.That(level.Legends, Contains.Key(@char));
            }
        }

        Assert.Multiple(() =>
        {
            Assert.That(level.Meta.Name, Is.EqualTo("LEVEL 2"));
            Assert.That(level.Meta.Time, Is.EqualTo(180));
            Assert.That(level.Meta.Hardened, Is.Null);
            Assert.That(level.Meta.PowerUp, Is.EqualTo('i'));
            Assert.That(level.Meta.Unbreakable, Is.Null);
            Assert.That(level.Legends, Contains.Key('h'));
            Assert.That(level.Legends, Contains.Key('i'));
            Assert.That(level.Legends, Contains.Key('j'));
            Assert.That(level.Legends, Contains.Key('k'));
            Assert.That(level.Legends, Contains.Value("green-block.png"));
            Assert.That(level.Legends, Contains.Value("teal-block.png"));
            Assert.That(level.Legends, Contains.Value("blue-block.png"));
            Assert.That(level.Legends, Contains.Value("brown-block.png"));
        });
    }
    
    [Test]
    public void TestLevel3()
    {
        var levelFactory = new LevelFactory();
        
        FileReader.ReadFileFromPath(Path.Combine("Assets", "Levels", "level3.txt"), out var data);

        var level = levelFactory.Parse(data);
        
        Assert.That(level.Map, Is.Not.Empty);
        Assert.That(level.Map, Has.Length.EqualTo(25));
        foreach(var column in level.Map) Assert.That(column, Has.Length.EqualTo(12));
        
        foreach (var row in level.Map)
        {
            foreach (var @char in row)
            {
                if (@char is '-' or '\r' or '\n' or '\u0000') continue;
                Assert.That(level.Legends, Contains.Key(@char));
            }
        }

        Assert.Multiple(() =>
        {
            Assert.That(level.Meta.Name, Is.EqualTo("LEVEL 3"));
            Assert.That(level.Meta.Time, Is.EqualTo(180));
            Assert.That(level.Meta.Hardened, Is.Null);
            Assert.That(level.Meta.PowerUp, Is.EqualTo('#'));
            Assert.That(level.Meta.Unbreakable, Is.EqualTo('Y'));
            Assert.That(level.Legends, Contains.Key('0'));
            Assert.That(level.Legends, Contains.Key('w'));
            Assert.That(level.Legends, Contains.Key('#'));
            Assert.That(level.Legends, Contains.Key('Y'));
            Assert.That(level.Legends, Contains.Key('b'));
            Assert.That(level.Legends, Contains.Value("orange-block.png"));
            Assert.That(level.Legends, Contains.Value("darkgreen-block.png"));
            Assert.That(level.Legends, Contains.Value("green-block.png"));
            Assert.That(level.Legends, Contains.Value("brown-block.png"));
            Assert.That(level.Legends, Contains.Value("yellow-block.png"));
        });
    }
    
  
}