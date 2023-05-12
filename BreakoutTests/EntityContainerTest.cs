using System.Data;
using Breakout.Containers;
using Breakout.Factories;
using Breakout.IO;
using Breakout.Entities;
using Breakout.States;
using DIKUArcade.GUI;
using DIKUArcade.Math;

namespace BreakoutTests;

/// <summary>
/// We have mainly used the Test-Driven Development Approach for these tests
/// </summary>
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