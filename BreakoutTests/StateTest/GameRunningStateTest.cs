using Breakout.Entities;
using Breakout.GameModifiers;
using Breakout.GameModifiers.PowerUps;
using Breakout.PowerUps.Activators;
using Breakout.States.GameRunning;
using Breakout.Utility;
using DIKUArcade.Graphics;
using Window = DIKUArcade.GUI.Window;

namespace BreakoutTests.StateTest;


/// <summary>
/// Unit testing for the GameRunningState based on the Arrange, Act and Assert principles.
/// </summary>
[TestFixture]
public class GameRunningStateTests
{
    private GameRunningState _gameRunningState;

    [SetUp]
    public void Setup()
    {
        Window.CreateOpenGLContext();
        _gameRunningState = GameRunningState.GetInstance();
    }

    [Test]
    public void GetInstance_Always_ReturnsSameInstance()
    {
        var instance1 = GameRunningState.GetInstance();
        var instance2 = GameRunningState.GetInstance();

        Assert.AreSame(instance1, instance2);
    }

    [Test]
    public void ResetState_AfterResettingInstance_InstanceIsNull()
    {
        _gameRunningState.ResetState();
    }

    [Test]
    public void UpdateState_WithNoBallsAndNoBlocks_CallsLoadNextLevel()
    {
        _gameRunningState.EntityManager.BallEntities.ClearContainer();
        _gameRunningState.EntityManager.BlockEntities.ClearContainer();
        _gameRunningState.CurrentLevel = 1;

        _gameRunningState.UpdateState();

        Assert.AreEqual(2, _gameRunningState.CurrentLevel);  // Assuming LoadNextLevel increments the level by 1
    }

    [Test]
    public void HandleGameLogic_WithNoMoreBalls_DecreasesPlayerLives()
    {
        _gameRunningState.EntityManager.BallEntities.ClearContainer();
        _gameRunningState.EntityManager.PlayerEntity.SetLives(3);

        _gameRunningState.HandleGameLogic();

        Assert.That(_gameRunningState.EntityManager.PlayerEntity.GetLives(), Is.EqualTo(2));
    }

    [Test]
    public void ClearsBallEntitiesAndPowerUpEntitiesOnLoadNextLevel()
    {
        _gameRunningState.EntityManager.BallEntities.AddEntity(BallEntity.Create(PositionUtil.BallPosition, PositionUtil.BallExtent, PositionUtil.BallDirection, true));
        _gameRunningState.EntityManager.PowerUpEntities.AddEntity(GameModifierEntity.Create(PositionUtil.BallPosition,
            new Image(Path.Combine("Assets",
                "Images", "ball2.png")), new HealthPowerUpActivator(_gameRunningState.EntityManager.PlayerEntity)));

        _gameRunningState.LoadNextLevel();
        Assert.Multiple(() =>
        {
            Assert.That(_gameRunningState.EntityManager.BallEntities.CountEntities(), Is.EqualTo(0));
            Assert.That(_gameRunningState.EntityManager.PowerUpEntities.CountEntities(), Is.EqualTo(0));
        });
    }
}

