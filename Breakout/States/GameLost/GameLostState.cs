using Breakout.Controller;
using Breakout.Handler;
using Breakout.Utility;
using DIKUArcade.Input;
using DIKUArcade.State;

namespace Breakout.States.GameLost;

public class GameLostState : DefaultMenu,  IGameState
{
    private static GameLostState? _instance;

    private readonly IKeyboardPressHandler _keyboardPressHandler;
    /// <summary>
    /// Gets the singleton instance of the <see cref="GameLostState"/>.
    /// </summary>
    /// <returns>The singleton instance of the <see cref="GameLostState"/>.</returns>
    public static GameLostState GetInstance()
    {
        return _instance ??= new GameLostState();
    }
    
    
    private GameLostState() : base(MenuUtil.LostMenuItems, MenuUtil.LostBackground)
    {
        _keyboardPressHandler = new LostGameKeyboardController(this);
    }
    
    public void ResetState()
    {
        _instance = null;
    }

    public void UpdateState()
    {
        
    }

    public void RenderState()
    {
        base.RenderMenuItems();
    }

    public void HandleKeyEvent(KeyboardAction action, KeyboardKey key)
    {
        if (action == KeyboardAction.KeyRelease) return;
        _keyboardPressHandler.HandleKeyPress(key);   
    }
}