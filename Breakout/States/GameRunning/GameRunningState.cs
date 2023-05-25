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
using DIKUArcade.State;
using DIKUArcade.Timers;

namespace Breakout.States.GameRunning;

/// <summary>
/// Represents the game state when the game is running.
/// </summary>
public class GameRunningState : IGameState
{
    private Level _currentLevel;
    private int CurrentLevel { get; set; }
    
    private readonly LevelLoader _levelLoader;
    private readonly IGameEventFactory<GameEventType> _gameEventFactory;
    private readonly IKeyboardEventHandler _keyboardEventHandler;
    private readonly IWinCondition _winCondition;
    private readonly EntityManager _entityManager;
    private readonly GameRunningStateUiManager _gameRunningStateUiManager = new();
    
    //TODO: Maybe delete
    private readonly PowerUpHandler _powerUpHandler;
    
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
        
        _gameEventFactory = new GameEventFactory();
        _levelLoader = new LevelLoader();
        _currentLevel = _levelLoader.LoadLevel(CurrentLevel);
        _entityManager = new EntityManager(this)
        {
            BlockEntities = _levelLoader.ConstructBlockEntities(_currentLevel)
        };
        _keyboardEventHandler = new RunningStateKeyboardController(_entityManager.PlayerEntity);

        var ballEntity = BallEntity.Create(PositionUtil.PlayerPosition + PositionUtil.PlayerExtent / 2, PositionUtil.BallExtent, PositionUtil.BallSpeed, PositionUtil.BallDirection);
        _entityManager.AddBallEntity(ballEntity);
        UpdateText();
        
        _winCondition = new BlockEntitiesWinCondition(_entityManager, _levelLoader);
        _powerUpHandler = new PowerUpHandler(_entityManager.PlayerEntity, _entityManager.BallEntities);
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
        _entityManager.Move();
        _gameRunningStateUiManager.UpdateTimer(_currentLevel.Meta.Time);
        HandleGameLogic();
    }

    /// <summary>
    /// 
    /// </summary>
    private void HandleGameLogic()
    {
        bool timeRanOut = _currentLevel.Meta.Time.HasValue && _currentLevel.Meta.Time <= StaticTimer.GetElapsedSeconds();
        bool playerNoMoreLives = _entityManager.PlayerEntity.GetLives() == 0;
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
        
        bool noMoreBalls = _entityManager.BallEntities.CountEntities() == 0;
        if (noMoreBalls)
        {
            _entityManager.PlayerEntity.TakeLife();
            _entityManager.AddBallEntity(BallEntity.Create(PositionUtil.PlayerPosition + PositionUtil.PlayerExtent / 2, PositionUtil.BallExtent, PositionUtil.BallSpeed, PositionUtil.BallDirection));
            _gameRunningStateUiManager.UpdateHealth(_entityManager.PlayerEntity.GetLives());
        }
        
        bool moreBlocksLeft = _entityManager.BlockEntities.CountEntities() > 0;
        if (!moreBlocksLeft) LoadNextLevel();
    }
    
    /// <summary>
    /// Loads the next level into the game.
    /// </summary>
    private void LoadNextLevel()
    {
        if (_entityManager.BallEntities.CountEntities() > 0)
            _entityManager.BallEntities.ClearContainer();
        
        CurrentLevel++;
        _currentLevel = _levelLoader.LoadLevel(CurrentLevel);
        _entityManager.BlockEntities = _levelLoader.ConstructBlockEntities(_currentLevel);
        _gameRunningStateUiManager.UpdateLevel(CurrentLevel);
    }

    /// <summary>
    /// Renders the game state.
    /// </summary>
    public void RenderState()
    {
        _entityManager.RenderEntities();
        _gameRunningStateUiManager.RenderText();
    }

    /// <summary>
    /// Handles the keyboard event based on the specified action and key.
    /// </summary>
    /// <param name="action">The action associated with the keyboard event (e.g., KeyPress, KeyRelease).</param>
    /// <param name="key">The keyboard key that triggered the event.</param>
    public void HandleKeyEvent(KeyboardAction action, KeyboardKey key)
    {
        if (action != KeyboardAction.KeyRelease) 
            _keyboardEventHandler.HandleKeyPress(key);
        else
            _keyboardEventHandler.HandleKeyRelease(key);
    }

    /// <summary>
    /// Updates the text elements displaying the player's health, score, and current level.
    /// TODO: This is not very good since it's instantiates a new text object every frame..^^ leading to performance issues.
    /// TODO: Instead we should invoke <see cref="Text"/> method <see cref="Text.SetText"/> to update the text.
    /// </summary>
    public void UpdateText()
    {
        int lives = _entityManager.PlayerEntity.GetLives();
        _gameRunningStateUiManager.UpdateHealth(lives);
        _gameRunningStateUiManager.UpdateScore(_entityManager.PlayerEntity.GetPoints());
        _gameRunningStateUiManager.UpdateLevel(CurrentLevel);
    }
}