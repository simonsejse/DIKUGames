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

public class MainMenuState : IGameState, IMenu
{
    private static MainMenuState? _instance;
    private readonly IKeyboardPressHandler _keyboardEventHandler;

    private readonly Entity _background;
    public Text[] MenuButtons { get; }
    public int ActiveButton { get; set; }

    private MainMenuState(ITextFactory textFactory)
    {
        ActiveButton = 0;
        _background = new BackgroundFactory("Assets", "Images", "shipit_titlescreen.png").Create();
        MenuButtons = new[]
        {
            textFactory.Create("Start Game",ConstantsUtil.StartGamePosition, ConstantsUtil.StartGameExtent, Color.Crimson),
            textFactory.Create("Quit", ConstantsUtil.QuitGamePosition, ConstantsUtil.QuitGameExtent, Color.White),
        };
        _keyboardEventHandler = new MainMenuStateKeyboardController(this);
    }
    
    public static MainMenuState GetInstance()
    {
        return _instance ??= new MainMenuState(new DefaultTextFactory());
    }
    
    public void SetButtonColor(int index, Color color)
    {
        if (index < 0 || index > MenuButtons.Length)
            return;
        MenuButtons[index].SetColor(color);
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
        _background.RenderEntity();
        foreach(var text in MenuButtons) text.RenderText();
    }

    public void HandleKeyEvent(KeyboardAction action, KeyboardKey key)
    {
        if (action is not KeyboardAction.KeyPress) return;
        
        _keyboardEventHandler.HandleKeyPress(key);
    }
}