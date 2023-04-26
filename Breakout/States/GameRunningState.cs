using Breakout.Containers;
using Breakout.Entites;
using Breakout.Entities;
using Breakout.Factories;
using Breakout.Handler;
using Breakout.Loaders;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Input;
using DIKUArcade.Math;
using DIKUArcade.State;

namespace Breakout.States;

public class GameRunningState : IGameState
{
    #region Properties and fields
    private static GameRunningState? _instance;

    private IKeyboardEventHandler _keyboardEventHandler;
    
    private PlayerEntity _playerEntity;
    private EntityContainers _entityContainers;
    private LevelLoader _levelLoader;
    
    #endregion

    
    #region Constructor
    public GameRunningState()
    {
        _keyboardEventHandler = new DefaultRunningStateGameEventHandler();
        _playerEntity = new PlayerEntityFactory().Create();
        _entityContainers = new EntityContainers();
        _levelLoader = new LevelLoader();
        _levelLoader.LoadLevel(0, _entityContainers.BlockEntities);
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
       
    }

    public void RenderState()
    {
        _playerEntity.RenderEntity();
        _entityContainers.RenderEntities();
    }

    public void HandleKeyEvent(KeyboardAction action, KeyboardKey key)
    {
        
    }
    #endregion
}