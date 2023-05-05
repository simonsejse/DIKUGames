using System.Drawing;
using Breakout.Controller;
using Breakout.Factories;
using Breakout.Handler;
using DIKUArcade.Graphics;
using DIKUArcade.Input;
using DIKUArcade.Math;
using DIKUArcade.State;

namespace Breakout.States;

public class MainMenuState : IGameState
{
    private static MainMenuState? _instance;
    private readonly IKeyboardPressHandler _keyboardEventHandler;
    
    public Text[] MenuButtons { get; }
    public int ActiveButton { get; set; }

    private MainMenuState(ITextFactory textFactory)
    {
        ActiveButton = 0;
        MenuButtons = new[]
        {
            textFactory.Create("Start Game", new Vec2F(0.1f, 0.1f), new Vec2F(0.5f, 0.5f), Color.Crimson),
            textFactory.Create("Quit", new Vec2F(0.1f, 0f), new Vec2F(0.5f, 0.5f), Color.White)
        };
        _keyboardEventHandler = new MainMenuStateKeyboardController(this);
    }
    
    public static MainMenuState GetInstance()
    {
        return _instance ??= new MainMenuState(new DefaultTextFactory());
    }

    public void ResetState()
    {
    }

    public void UpdateState()
    {
        Console.WriteLine(ActiveButton);
    }

    public void RenderState()
    {
        foreach(var text in MenuButtons) text.RenderText();
    }

    public void HandleKeyEvent(KeyboardAction action, KeyboardKey key)
    {
        if (action is not KeyboardAction.KeyPress) return;
        
        _keyboardEventHandler.HandleKeyPress(key);
    }
}