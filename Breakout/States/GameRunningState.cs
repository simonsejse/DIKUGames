using Breakout.Containers;
using System.Drawing;
using Breakout.Controller;
using Breakout.Entities;
using Breakout.Factories;
using Breakout.Handler;
using Breakout.Levels;
using DIKUArcade.Entities;
using DIKUArcade.Input;
using DIKUArcade.Math;
using DIKUArcade.State;
using DIKUArcade.Graphics;

namespace Breakout.States;

public class GameRunningState : IGameState
{
    #region Properties and fields
    private static GameRunningState? _instance;
    private PlayerEntity _playerEntity;
    private BallEntity _ballEntity;
    private EntityContainers _entityContainers;
    private EntityContainer<BlockEntity> _blockEntities;
    private readonly LevelLoader _levelLoader;
    private IKeyboardEventHandler _keyboardEventHandler;
    #endregion

    
    #region Constructor
    public GameRunningState()
    {
        _playerEntity = new PlayerEntityFactory().Create();
        _keyboardEventHandler = new RunningStateKeyboardController(_playerEntity);
        _entityContainers = new EntityContainers();
        _levelLoader = new LevelLoader();
        
        _blockEntities = _levelLoader.LoadLevel(0);
         _ballEntity = new BallEntityFactory(0.1f, new Vec2F(0.01f, 0.01f)).Create();
        _entityContainers.BallEntities.AddEntity(_ballEntity);

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
       _ballEntity.Move();
       _ballEntity.CheckBlockCollisions(_ballEntity, _blockEntities, _playerEntity);
       CollisionManager.CheckBallPlayerCollision(_ballEntity, _playerEntity);
   
       //CheckBlockCollisions(_ballEntity, blockEntities);


       
       
    }

    public void RenderState()
    {
        _playerEntity.RenderEntity();
        _entityContainers.RenderEntities();
        _blockEntities.RenderEntities();
    }

    public void HandleKeyEvent(KeyboardAction action, KeyboardKey key)
    {
        if (action == KeyboardAction.KeyRelease)
        {
            _keyboardEventHandler.HandleKeyRelease(key);
        }
        else
        {
            _keyboardEventHandler.HandleKeyPress(key);
        }
    }
    #endregion
}