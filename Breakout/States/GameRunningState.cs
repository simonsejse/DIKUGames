using Breakout.Containers;
using Breakout.Controller;
using Breakout.Entites;
using Breakout.Factories;
using Breakout.Handler;
using Breakout.Levels;
using Breakout.Loaders;
using DIKUArcade.Input;
using DIKUArcade.State;

namespace Breakout.States;

public class GameRunningState : IGameState
{
    #region Properties and fields
    private static GameRunningState? _instance;
    private PlayerEntity _playerEntity;
    private EntityContainers _entityContainers;
    private LevelLoader _levelLoader;
    private IKeyboardEventHandler _keyboardEventHandler;
    #endregion

    
    #region Constructor
    public GameRunningState()
    {
        _playerEntity = new PlayerEntityFactory().Create();
        _keyboardEventHandler = new RunningStateKeyboardController(_playerEntity);
        _entityContainers = new EntityContainers();
        _levelLoader = new LevelLoader();
        _entityContainers.BlockEntities = _levelLoader.LoadLevel(0);
    }
    #endregion
    
    #region Singleton pattern
    public static GameRunningState GetInstance()
    {
        return _instance ??= new GameRunningState();
    }
    #endregion

    #region Methods
    public void ResetState()
    {
    }

    public void UpdateState()
    {
       _playerEntity.Move();
    }

    public void RenderState()
    {
        _playerEntity.RenderEntity();
        _entityContainers.RenderEntities();
    }

    public void HandleKeyEvent(KeyboardAction action, KeyboardKey key)
    {
        if (action == KeyboardAction.KeyPress)
        {
            _keyboardEventHandler.HandleKeyPress(key);
        }
        else
        {
            _keyboardEventHandler.HandleKeyRelease(key);
        }
    }
    #endregion
}