using System.Drawing;
using Breakout.Factories;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Input;
using DIKUArcade.Math;
using DIKUArcade.State;

namespace Breakout.States;

public class MainMenuState : IGameState
{
    private static MainMenuState? _instance;
    private readonly Text[] _menuButtons;
    
    private readonly ITextFactory _textFactory;

    public MainMenuState(ITextFactory textFactory)
    {
        _textFactory = textFactory;
        _menuButtons = new[]
        {
            textFactory.Create("Start Game", new Vec2F(0.1f, 0.1f), new Vec2F(0.5f, 0.5f), Color.Aqua),
            textFactory.Create("Quit", new Vec2F(0.1f, 0f), new Vec2F(0.5f, 0.5f), Color.White)
        };
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
    }

    public void RenderState()
    {
        foreach(var text in _menuButtons) text.RenderText();
    }

    public void HandleKeyEvent(KeyboardAction action, KeyboardKey key)
    {
        if (key == KeyboardKey.Escape)
        {
            //TODO: Register event to EventBus with close game
        }
    }
}