using System.Drawing;
using DIKUArcade.Graphics;
using DIKUArcade.Input;
using DIKUArcade.Math;
using DIKUArcade.State;

namespace Galaga.GalagaStates;

public class GamePaused : IGameState
{
    private static GamePaused _gamePaused;
    
    public Text[] MenuButtons { get; private set; }
    private IKeyboardIntermediaryPressHandler _keyboardIntermediaryHandler;
    public int ActiveMenuButton = 0;

    public static GamePaused GetInstance()
    {
        GamePaused CreateGamePaused()
        {
            var gamePaused = new GamePaused();
            gamePaused.InitializeGameState();
            gamePaused._keyboardIntermediaryHandler = new PausedStateKeyboardAction(gamePaused);
            return gamePaused;
        }
        return _gamePaused ??= CreateGamePaused();
    }

    private void InitializeGameState()
    {
        var continueText = new Text("Continue", new Vec2F(0.1f, 0.1f), new Vec2F(0.5f, 0.5f));
        continueText.SetColor(Color.Aqua);
        var mainMenu = new Text("Main Menu", new Vec2F(0.1f, 0f), new Vec2F(0.5f, 0.5f));
        mainMenu.SetColor(Color.White);

        MenuButtons = new Text[]
        {
            continueText,
            mainMenu
        };
    }

    public void ResetState()
    {
    }

    public void UpdateState()
    {
    }

    public void RenderState()
    {
        foreach(var text in MenuButtons) text.RenderText();
    }

    public void HandleKeyEvent(KeyboardAction action, KeyboardKey key)
    {
        if (action == KeyboardAction.KeyPress) _keyboardIntermediaryHandler.KeyPress(key);
    }
}