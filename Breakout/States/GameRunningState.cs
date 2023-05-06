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
    private BallEntity _ballEntity;
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

    /*
    public void AddEntity(ObjectType objectType)
    {
        var (shape, position) = ObjectTypeFactory.CreateShape(objectType);
        var dynamicShape = new DynamicShape(shape.Position, shape.Extent, shape.Direction);
        EntityContainer.AddDynamicEntity(dynamicShape);
        dynamicShape.SetPosition(position);
    }
    */
    public void ResetState()
    {
    }

    public void UpdateState()
    {
       _playerEntity.Move();
       _ballEntity.Move();
       //_ballEntity.CollideWithObject(ObjectType);


       if (_ballEntity.OutOfBounds())
       {
           //TODO: Lose life
           _ballEntity.Launch();
           // Egentlig, vi skal nok have en initialize-state pre-state? spørg
       }
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
            return;
        }
        _keyboardEventHandler.HandleKeyPress(key);
    }
    #endregion
}