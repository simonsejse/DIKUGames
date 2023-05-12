using System.Drawing;
using Breakout.Controller;
using Breakout.Factories;
using Breakout.Handler;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Input;
using DIKUArcade.Math;
using DIKUArcade.State;

namespace Breakout.States;

public class PauseState : IGameState, IMenu
{
    private static PauseState? _instance;
    private readonly Entity _background;
    private readonly IKeyboardPressHandler _keyboardEventHandler;

    public int ActiveButton { get; set; }
    public Text[] MenuButtons { get; }
    
    public PauseState(ITextFactory textFactory)
    {
        ActiveButton = 0;
        _background = new BackgroundFactory("Assets", "Images", "SpaceBackground.png").Create();
        MenuButtons = new[]
        {
            textFactory.Create("Continue", new Vec2F(0.1f, 0.1f), new Vec2F(0.5f, 0.5f), Color.Crimson),
            textFactory.Create("Main Menu", new Vec2F(0.1f, 0f), new Vec2F(0.5f, 0.5f), Color.White),
        };
        _keyboardEventHandler = new PauseStateKeyboardController(this);
    }
    
    public static PauseState GetInstance()
    {
        return _instance ??= new PauseState(new DefaultTextFactory());
    }
    

    public void SetButtonColor(int index, Color color)
    {
        if (index < 0 || index > MenuButtons.Length)
            return;
        MenuButtons[index].SetColor(color);
    }

    public void ResetState()
    {
    }

    public void UpdateState()
    {
    }

    public void RenderState()
    {
        _background.RenderEntity();
        foreach(var text in MenuButtons) text.RenderText();
    }

    public void HandleKeyEvent(KeyboardAction action, KeyboardKey key)
    {
        if (action is not KeyboardAction.KeyPress) return;
        
        _keyboardEventHandler.HandleKeyPress(key);
    }
}