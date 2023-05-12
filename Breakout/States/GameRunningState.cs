using Breakout.Containers;
using Breakout.Controller;
using Breakout.Entities;
using Breakout.Events;
using Breakout.Factories;
using Breakout.Handler;
using Breakout.Levels;
using DIKUArcade.Events;
using DIKUArcade.Events.Generic;
using DIKUArcade.Input;
using DIKUArcade.Math;
using DIKUArcade.State;

namespace Breakout.States;

public class GameRunningState : IGameState
{
    private static GameRunningState? _instance;
    private readonly GameEventFactory _gameEventFactory;
    private readonly LevelLoader _levelLoader;
    private IKeyboardEventHandler _keyboardEventHandler;
    private readonly EntityManager _entityManager;
    private int CurrentLevel { get; set; }

    public GameRunningState()
    {
        CurrentLevel = 0;
        
        _gameEventFactory = new GameEventFactory();
        _levelLoader = new LevelLoader();
        _entityManager = new EntityManager
        {
            BlockEntities = _levelLoader.LoadLevel(CurrentLevel)
        };
        _keyboardEventHandler = new RunningStateKeyboardController(_entityManager.PlayerEntity);
        
        _entityManager.AddBallEntity(BallEntity.Create(0.1f, new Vec2F(0.01f, 0.01f)));
    }
    
    public static GameRunningState GetInstance()
    {
        return _instance ??= new GameRunningState();
    }
    
    public void ResetState()
    {
        _instance = null;
    }

    public void UpdateState()
    {
        _entityManager.Move();
        CheckLevel();
    }

    public void RenderState()
    {
        _entityManager.RenderEntities();
    }

    public void HandleKeyEvent(KeyboardAction action, KeyboardKey key)
    {
        if (action != KeyboardAction.KeyRelease) 
            _keyboardEventHandler.HandleKeyPress(key);
        else
            _keyboardEventHandler.HandleKeyRelease(key);
    }

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
        }
    }

    public int GetLevel() => CurrentLevel;
}