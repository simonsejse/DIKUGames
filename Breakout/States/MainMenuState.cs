using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Input;
using DIKUArcade.State;

namespace Breakout.States;

public class MainMenuState : IGameState
{
    private static MainMenuState? _instance;
    
    public static MainMenuState GetInstance()
    {
        MainMenuState CreateMenu()
        {
            var menu = new MainMenuState();
            return menu;
        }

        return _instance ??= CreateMenu();
    }

    public void ResetState()
    {
    }

    public void UpdateState()
    {
    }

    public void RenderState()
    {
        
    }

    public void HandleKeyEvent(KeyboardAction action, KeyboardKey key)
    {
        if (key == KeyboardKey.Escape)
        {
            //TODO: Register event to EventBus with close game
        }
    }
}