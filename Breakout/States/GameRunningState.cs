using Breakout.Containers;
using Breakout.Controller;
using Breakout.Entites;
using Breakout.Factories;
using Breakout.Handler;
using DIKUArcade.Input;
using DIKUArcade.Math;
using DIKUArcade.State;
using Breakout.Levels;

namespace Breakout.States;

public class GameRunningState : IGameState
{
    #region Properties and fields
    private static GameRunningState? _instance;
    private PlayerEntity _playerEntity;
    private EntityContainers _entityContainers;
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
        
        _entityContainers.BlockEntities = _levelLoader.LoadLevel(0);
        var ball = new BallEntityFactory(0.01f, new Vec2F(0.01f, 0.01f)).Create();
        _entityContainers.BallEntities.AddEntity(ball);
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
       _entityContainers.BallEntities.Iterate(entity =>
       {
           entity.Move();
           if (entity.OutOfBounds())
           {
               //TODO: Lose life
               //_entityContainers.BallEntities.Remove ... should remove it
               entity.Launch();
           }
       });
       //_ballEntity.CollideWithObject(ObjectType);

       
       
    }

    public void RenderState()
    {
        _playerEntity.RenderEntity();
        _entityContainers.RenderEntities();
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