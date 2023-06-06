using Breakout.Containers;
using Breakout.Controller;
using Breakout.Entities;
using Breakout.Events;
using Breakout.Factories;
using Breakout.Handler;
using Breakout.Levels;
using Breakout.Utility;
using DIKUArcade.Events;
using DIKUArcade.Events.Generic;
using DIKUArcade.Graphics;
using DIKUArcade.Input;
using DIKUArcade.Math;
using DIKUArcade.State;
using DIKUArcade.Timers;

namespace Breakout.States.GameRunning;

/// <summary>
/// Represents the game state when the game is running.
/// </summary>
public class GameRunningState : IGameState
{
    private Level _currentLevel;
    public int CurrentLevel { get; set; }
    
    private readonly IGameEventFactory<GameEventType> _gameEventFactory;
    private readonly IKeyboardEventHandler _keyboardEventHandler;
    private readonly IWinCondition _winCondition;
    private readonly LevelLoader _levelLoader;
    public readonly EntityManager EntityManager;
    private readonly GameRunningStateUiManager _gameRunningStateUiManager = new();
    
    private static GameRunningState? _instance;
    /// <summary>
    /// Gets the singleton instance of the <see cref="GameRunningState"/>.
    /// </summary>
    /// <returns>The singleton instance of the <see cref="GameRunningState"/>.</returns>
    public static GameRunningState GetInstance()
    {
        return _instance ??= new GameRunningState();
    }
    
    /// <summary>
    /// Initializes a new instance of the <see cref="GameRunningState"/> class.
    /// </summary>
    public GameRunningState()
    {
        CurrentLevel = 0;
        _levelLoader = new LevelLoader();
        _currentLevel = _levelLoader.LoadLevel(CurrentLevel);

        _gameEventFactory = new GameEventFactory();
        EntityManager = new EntityManager(this)
        {
            BlockEntities = _levelLoader.ConstructBlockEntities(_currentLevel)
        };
        _keyboardEventHandler = new RunningStateKeyboardController(EntityManager.PlayerEntity);

        var ballEntity = BallEntity.Create(PositionUtil.PlayerPosition + PositionUtil.PlayerExtent / 2, PositionUtil.BallExtent, PositionUtil.BallDirection, true);
        EntityManager.AddBallEntity(ballEntity);
        UpdateText();
        
        _winCondition = new BlockEntitiesWinCondition(EntityManager, _levelLoader);
    }
    
    /// <summary>
    /// Resets the state by clearing the singleton instance.
    /// </summary>
    public void ResetState()
    {
        _instance = null;
    }
    
    /// <summary>
    /// Handles all update logic for the game running state.
    /// </summary>
    public void UpdateState()
    {
        EntityManager.Move();
        EntityManager.BallEntities.Iterate(ball =>
        {
            if (!ball.IsBallStuck) return;
            
            var playerShape = EntityManager.PlayerEntity.Shape;
            float positionX = playerShape.Position.X + playerShape.Extent.X / 2 - ball.Shape.Extent.X / 2;
            float positionY = playerShape.Position.Y + playerShape.Extent.Y / 2 + ball.Shape.Extent.Y / 2;
            ball.Shape.Position = new Vec2F(positionX, positionY);
        });
        
        _gameRunningStateUiManager.UpdateTimer(_currentLevel.Meta.Time);
        HandleGameLogic();
    }
    
    /// <summary>
    /// Handles game winning and losing logic.
    /// </summary>
    public void HandleGameLogic()
    {
        bool timeRanOut = _currentLevel.Meta.Time.HasValue && _currentLevel.Meta.Time <= StaticTimer.GetElapsedSeconds();
        bool playerNoMoreLives = EntityManager.PlayerEntity.GetLives() == 0;
        
        if (playerNoMoreLives || timeRanOut)
        {
            GameEvent<GameEventType> gameEvent = _gameEventFactory.CreateGameEvent(GameEventType.GameStateEvent, "CHANGE_STATE", nameof(GameState.Lost));
            BreakoutBus.GetBus().RegisterEvent(gameEvent);
            return;
        }

        if (_winCondition.HasWon(CurrentLevel))
        {
            GameEvent<GameEventType> gameEvent = _gameEventFactory.CreateGameEvent(GameEventType.GameStateEvent, "CHANGE_STATE", nameof(GameState.Won));
            BreakoutBus.GetBus().RegisterEvent(gameEvent);
            return;
        }
        
        bool noMoreBalls = EntityManager.BallEntities.CountEntities() == 0;
        if (noMoreBalls)
        {
            EntityManager.PlayerEntity.TakeLife();
            _gameRunningStateUiManager.ToggleLaunch();
            EntityManager.AddBallEntity(BallEntity.Create(PositionUtil.PlayerPosition + PositionUtil.PlayerExtent / 2, PositionUtil.BallExtent, PositionUtil.BallDirection, true));
            _gameRunningStateUiManager.UpdateHealth(EntityManager.PlayerEntity.GetLives());
        }
        
        bool moreBlocksLeft = EntityManager.BlockEntities.CountEntities() > 0;
        if (!moreBlocksLeft) LoadNextLevel();
    }
    
    /// <summary>
    /// Loads the next level into the game.
    /// </summary>
    public void LoadNextLevel()
    {
        if (EntityManager.BallEntities.CountEntities() > 0)
            EntityManager.BallEntities.ClearContainer();
        if (EntityManager.PowerUpEntities.CountEntities() > 0)
            EntityManager.PowerUpEntities.ClearContainer();
        
        CurrentLevel++;
        _currentLevel = _levelLoader.LoadLevel(CurrentLevel);
        EntityManager.BlockEntities = _levelLoader.ConstructBlockEntities(_currentLevel);
        _gameRunningStateUiManager.UpdateLevel(CurrentLevel);
        StaticTimer.RestartTimer();
    }

    /// <summary>
    /// Renders the game state.
    /// </summary>
    public void RenderState()
    {
        EntityManager.RenderEntities();
        _gameRunningStateUiManager.RenderText();
    }

    /// <summary>
    /// Handles the keyboard event based on the specified action and key.
    /// </summary>
    /// <param name="action">The action associated with the keyboard event (e.g., KeyPress, KeyRelease).</param>
    /// <param name="key">The keyboard key that triggered the event.</param>
    public void HandleKeyEvent(KeyboardAction action, KeyboardKey key)
    {
        if (key == KeyboardKey.L)
        {
            EntityManager.BallEntities.Iterate(ball =>
            {
                if (!ball.IsBallStuck) return;
                _gameRunningStateUiManager.ToggleLaunch();
                ball.IsBallStuck = false;
                ball.Launch();
            });
        }
        if (action != KeyboardAction.KeyRelease) 
            _keyboardEventHandler.HandleKeyPress(key);
        else
            _keyboardEventHandler.HandleKeyRelease(key);
    }

    /// <summary>
    /// Updates the text elements displaying the player's health, score, and current level.
    /// </summary>
    public void UpdateText()
    {
        int lives = EntityManager.PlayerEntity.GetLives();
        _gameRunningStateUiManager.UpdateHealth(lives);
        _gameRunningStateUiManager.UpdateScore(EntityManager.PlayerEntity.GetPoints());
        _gameRunningStateUiManager.UpdateLevel(CurrentLevel);
    }
}