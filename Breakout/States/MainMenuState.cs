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
        throw new NotImplementedException();
    }

    public void UpdateState()
    {
        throw new NotImplementedException();
    }

    public void RenderState()
    {
        throw new NotImplementedException();
    }

    public void HandleKeyEvent(KeyboardAction action, KeyboardKey key)
    {
        throw new NotImplementedException();
    }
}