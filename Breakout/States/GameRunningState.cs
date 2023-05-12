using System.Drawing;
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

namespace Breakout.States;

/// <summary>
/// Represents the game state when the game is running.
/// </summary>
public class GameRunningState : IGameState
{
    private static GameRunningState? _instance;
    private readonly GameEventFactory _gameEventFactory;
    private readonly LevelLoader _levelLoader;
    private readonly IKeyboardEventHandler _keyboardEventHandler;
    private readonly EntityManager _entityManager;
    
    private Text _scoreText = null!;
    private Text _levelText = null!;
    private Text _healthText = null!;
    private readonly ITextFactory _textFactory;

    private int CurrentLevel { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="GameRunningState"/> class.
    /// </summary>
    public GameRunningState()
    {
        
        CurrentLevel = 0;
        
        _gameEventFactory = new GameEventFactory();
        _levelLoader = new LevelLoader();
        _entityManager = new EntityManager(this)
        {
            BlockEntities = _levelLoader.LoadLevel(CurrentLevel)
        };
        _keyboardEventHandler = new RunningStateKeyboardController(_entityManager.PlayerEntity);

        var ballEntity = BallEntity.Create(ConstantsUtil.PlayerPosition + ConstantsUtil.PlayerExtent / 2, ConstantsUtil.BallExtent, ConstantsUtil.BallSpeed, ConstantsUtil.BallDirection);
        _entityManager.AddBallEntity(ballEntity);
        
        _textFactory = new DefaultTextFactory();
        UpdateText();
    }
    
    /// <summary>
    /// Gets the singleton instance of the <see cref="GameRunningState"/>.
    /// </summary>
    /// <returns>The singleton instance of the <see cref="GameRunningState"/>.</returns>
    public static GameRunningState GetInstance()
    {
        return _instance ??= new GameRunningState();
    }
    
    /// <summary>
    /// Resets the state by clearing the singleton instance.
    /// </summary>
    public void ResetState()
    {
        _instance = null;
    }
    
    /// <summary>
    /// Updates the game state.
    /// </summary>
    public void UpdateState()
    {
        _entityManager.Move();
        CheckLevel();
    }
    
    /// <summary>
    /// Renders the game state.
    /// </summary>
    public void RenderState()
    {
        _healthText.RenderText();
        _scoreText.RenderText();
        _levelText.RenderText();
        _entityManager.RenderEntities();
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
    /// Checks if all the blocks in the current level have been destroyed.
    /// If so, advances to the next level or transitions to the main menu if there are no more levels.
    /// </summary>
    private void CheckLevel()
    {
        if (_entityManager.BlockEntities.CountEntities() > 0) return;
        bool isNoMoreLevels = CurrentLevel == _levelLoader.NumberOfLevels - 1;
        if (isNoMoreLevels)
        {
            GameEvent<GameEventType> toMainMenu = _gameEventFactory.CreateGameEventForAllProcessors(
                GameEventType.GameStateEvent,
                "CHANGE_STATE",
                nameof(GameState.Menu));
            BreakoutBus.GetBus().RegisterEvent(toMainMenu);
        }
        else
        {
            CurrentLevel++;
            _entityManager.BlockEntities = _levelLoader.LoadLevel(CurrentLevel);
            UpdateText();
        }
    }
    
    /// <summary>
    /// Updates the text elements displaying the player's health, score, and current level.
    /// </summary>
    public void UpdateText()
    {
        int lives = _entityManager.PlayerEntity.GetLives();
        _healthText = _textFactory.Create($"{lives} {string.Concat(Enumerable.Repeat("❤", lives))}", ConstantsUtil.HealthPosition, ConstantsUtil.HealthExtent, Color.Red);
        _scoreText = _textFactory.Create($"Score: {_entityManager.PlayerEntity.GetPoints()}", ConstantsUtil.ScorePosition, ConstantsUtil.ScoreExtent, Color.White);
        _levelText = _textFactory.Create($"Level: {CurrentLevel}", ConstantsUtil.LevelPosition, ConstantsUtil.LevelExtent, Color.White);
    }
}