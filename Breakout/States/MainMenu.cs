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

public class MainMenuState : DefaultMenu, IGameState
{
    private static MainMenuState? _instance;
    private readonly IKeyboardPressHandler _keyboardEventHandler;

    private MainMenuState() : base(MenuUtil.MainMenuItems, MenuUtil.MainMenuBackground)
    {
        _keyboardEventHandler = new MainMenuStateKeyboardController(this);
    }
    
    public static MainMenuState GetInstance()
    {
        return _instance ??= new MainMenuState();
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