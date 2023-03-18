using System.Drawing;
using System.IO;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Input;
using DIKUArcade.Math;
using DIKUArcade.State;
using Image = DIKUArcade.Graphics.Image;

namespace Galaga.GalagaStates;

public class MainMenu : IGameState
{
    private static MainMenu _instance;
    private Entity _backGroundImage;
    public Text[] MenuButtons { get; private set; }
    public int ActiveMenuButton { get; set; }
    public static int MaxMenuButtons => 2;
    
    private IKeyboardIntermediaryPressHandler _keyboardIntermediaryPressHandler;


    public static MainMenu GetInstance()
    {
        MainMenu CreateMainMenu()
        {
            var menu = new MainMenu();
            menu.InitializeGameState();
            menu._keyboardIntermediaryPressHandler = new MainStateKeyboardAction(menu);
            return menu;
        }

        return _instance ??= CreateMainMenu();
    }

    private void InitializeGameState()
    {
        var image = new Image(Path.Combine("Assets", "Images", "TitleImage.png"));
        _backGroundImage = new Entity(new StationaryShape(new Vec2F(0, 0), new Vec2F(1, 1)), image);
        Text newGame = new("New Game", new Vec2F(0.09f, 0.05f), new Vec2F(0.6f, 0.6f));
        newGame.SetColor(Color.GreenYellow);
        Text quit = new("Quit", new Vec2F(0.09f, -0.05f), new Vec2F(0.6f, 0.6f));
        quit.SetColor(Color.White);
        MenuButtons = new Text[]
        {
            newGame,
            quit
        };
    }

    public void ResetState()
    {
        InitializeGameState();
    }

    public void UpdateState()
    {
    }

    public void RenderState()
    {
        _backGroundImage.RenderEntity();
        foreach (var text in MenuButtons) text.RenderText();
    }
    
    public void HandleKeyEvent(KeyboardAction action, KeyboardKey key)
    {
        if (action == KeyboardAction.KeyPress) _keyboardIntermediaryPressHandler.KeyPress(key);
    }
}


