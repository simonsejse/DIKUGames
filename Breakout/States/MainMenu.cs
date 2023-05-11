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

public class MainMenu : IGameState, IMenu
{
    private static MainMenu? _instance;
    private readonly IKeyboardPressHandler _keyboardEventHandler;

    private readonly Entity _background;
    public Text[] MenuButtons { get; }
    public int ActiveButton { get; set; }

    private MainMenu(ITextFactory textFactory)
    {
        ActiveButton = 0;
        _background = new BackgroundFactory("Assets", "Images", "shipit_titlescreen.png").Create();
        MenuButtons = new[]
        {
            textFactory.Create("Start Game", new Vec2F(0.1f, 0.1f), new Vec2F(0.5f, 0.5f), Color.Crimson),
            textFactory.Create("Quit", new Vec2F(0.1f, 0f), new Vec2F(0.5f, 0.5f), Color.White),
            textFactory.Create("Level Selector (Soon)", new Vec2F(0.1f, -0.1f), new Vec2F(0.6f, 0.5f), Color.White)
        };
        _keyboardEventHandler = new MainMenuStateKeyboardController(this);
    }
    
    public static MainMenu GetInstance()
    {
        return _instance ??= new MainMenu(new DefaultTextFactory());
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