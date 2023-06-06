using Breakout.Entities;
using Breakout.Events;
using Breakout.PowerUps.Activators;
using Breakout.States;
using Breakout.States.GameRunning;
using Breakout.Utility;
using DIKUArcade.Events;
using DIKUArcade.Events.Generic;
using DIKUArcade.Graphics;
using DIKUArcade.Math;
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
    public void SingletonPatternReturnsSameInstance()
    {
        var instance1 = GameRunningState.GetInstance();
        var instance2 = GameRunningState.GetInstance();

        Assert.That(instance2, Is.SameAs(instance1));
    }

    [Test]
    public void ResetStateAfterResettingInstance()
    {
        _gameRunningState.ResetState();
    }

    [Test]
    public void UpdateStateBallMovesWithPlayerPaddleWhenStuck()
    {
        _gameRunningState.EntityManager.BallEntities.ClearContainer();
        _gameRunningState.EntityManager.BlockEntities.ClearContainer();
        _gameRunningState.EntityManager.BallEntities.AddEntity(BallEntity.Create(new Vec2F(0,
                0),
            PositionUtil.BallExtent,
            PositionUtil.BallDirection,
            true));

        var player = _gameRunningState.EntityManager.PlayerEntity;
        
        _gameRunningState.UpdateState();

        _gameRunningState.EntityManager.BallEntities.Iterate(ball => {
            var positionX = ball.Shape.Position.X;
            var positionY = ball.Shape.Position.Y;
            Assert.Multiple(() =>
            {
                Assert.That(player.Shape.Position.X, Is.EqualTo(positionX));
                Assert.That(player.Shape.Position.Y, Is.EqualTo(positionY));
            });
        });

        _gameRunningState.UpdateState();
        
        _gameRunningState.EntityManager.BallEntities.Iterate(ball => {
            var playerShape = player.Shape;
            var positionX = playerShape.Position.X + playerShape.Extent.X / 2 - ball.Shape.Extent.X / 2;
            var positionY = playerShape.Position.Y + playerShape.Extent.Y / 2 + ball.Shape.Extent.Y / 2;
            Assert.Multiple(() =>
            {
                Assert.That(ball.Shape.Position.X - PositionUtil.BallExtent.X / 2, Is.EqualTo(positionX));
                Assert.That(ball.Shape.Position.Y + PositionUtil.BallExtent.Y / 2, Is.EqualTo(positionY));
            });
        });

    }

    [Test]
    public void UpdateStateWithNoBallsAndNoBlocksLoadNextLevel()
    {
        _gameRunningState.EntityManager.BallEntities.ClearContainer();
        _gameRunningState.EntityManager.BlockEntities.ClearContainer();
        _gameRunningState.CurrentLevel = 1;

        _gameRunningState.UpdateState();

        Assert.That(_gameRunningState.CurrentLevel, Is.EqualTo(2));  // Assuming LoadNextLevel increments the level by 1
    }

    [Test]
    public void HandleGameLogicWithNoMoreBallsDecreasesPlayerLives()
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

