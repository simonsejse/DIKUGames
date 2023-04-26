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
    private Entity _background;
    #endregion

    #region Constructor
    public GameRunningState()
    {
        
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
        _background.RenderEntity();
    }

    public void HandleKeyEvent(KeyboardAction action, KeyboardKey key)
    {
        
    }
    #endregion
}