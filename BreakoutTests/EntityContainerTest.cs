using Breakout.Containers;
using Breakout.States.GameRunning;


namespace BreakoutTests;

/// <summary>
/// We have mainly used the Test-Driven Development Approach for these tests
/// </summary>
[TestFixture]
public class EntityContainerTest
{
    private GameRunningState _gameRunningState;
    private EntityManager _entityManager;
    
    [SetUp]
    public void Setup()
    {
        _gameRunningState = new GameRunningState();
        _entityManager = new EntityManager(_gameRunningState);
    }

    
    [Test]
    public void TestRendering()
    {
        _entityManager.RenderEntities();
    }
    
}