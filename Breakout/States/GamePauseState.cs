using System.Drawing;
using Breakout.Controller;
using Breakout.Factories;
using Breakout.Handler;
using Breakout.Utility;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Input;
using DIKUArcade.Math;
using DIKUArcade.State;

namespace Breakout.States;

public class GamePauseState : DefaultMenu, IGameState
{
    private static GamePauseState? _instance;
    private readonly IKeyboardPressHandler _keyboardEventHandler;

    private GamePauseState() : base(MenuUtil.PausedMenuItems, MenuUtil.PausedBackground)
    {
        _keyboardEventHandler = new PauseStateKeyboardController(this);
    }
    
    public static GamePauseState GetInstance()
    {
        return _instance ??= new GamePauseState();
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
        if (action is not KeyboardAction.KeyPress) return;
        
        _keyboardEventHandler.HandleKeyPress(key);
    }
}