using System.Data;
using Breakout.Containers;
using Breakout.Factories;
using Breakout.IO;
using Breakout.Entites;
using DIKUArcade.GUI;
using DIKUArcade.Math;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace BreakoutTests;

/// <summary>
/// We have mainly used the Test-Driven Development Approach for these tests
/// </summary>
public class EntityContainerTest
{
    private EntityContainers _entityContainers;
    
    [SetUp]
    public void Setup()
    {
        _entityContainers = new EntityContainers();
    }

    
    [Test]
    public void TestRendering()
    {
        _entityContainers.RenderEntities();
        _entityContainers.RenderEntities();
    }

  
}