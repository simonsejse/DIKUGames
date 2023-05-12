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

public class GamePauseState : IGameState, IMenu
{
    private static GamePauseState? _instance;
    private readonly Entity _background;
    private readonly IKeyboardPressHandler _keyboardEventHandler;

    public int ActiveButton { get; set; }
    public Text[] MenuButtons { get; }
    
    public GamePauseState(ITextFactory textFactory)
    {
        ActiveButton = 0;
        _background = new BackgroundFactory("Assets", "Images", "SpaceBackground.png").Create();
        MenuButtons = new[]
        {
            textFactory.Create("Continue", ConstantsUtil.ContinueGamePosition, ConstantsUtil.ContinueGameExtent, Color.Crimson),
            textFactory.Create("Main Menu", ConstantsUtil.ToMainMenuPosition, ConstantsUtil.ToMainMenuExtent, Color.White),
        };
        _keyboardEventHandler = new PauseStateKeyboardController(this);
    }
    
    public static GamePauseState GetInstance()
    {
        return _instance ??= new GamePauseState(new DefaultTextFactory());
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