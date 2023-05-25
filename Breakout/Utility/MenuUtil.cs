using System.Drawing;
using Breakout.Commands;
using Breakout.Factories;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Input;
using DIKUArcade.Math;

namespace Breakout.Utility;

/// <summary>
/// A utility class for creating menu-related objects.
/// There are constants for the menu items and the background.
/// </summary>
public static class MenuUtil
{
    public static readonly Entity PausedBackground = new BackgroundFactory("Assets", "Images", "SpaceBackground.png").Create();
    public static readonly Text[] PausedMenuItems =
    {
        DefaultTextFactory.Create("Resume", PositionUtil.ContinueGamePosition, PositionUtil.ContinueGameExtent, Color.Crimson),
        DefaultTextFactory.Create("Main Menu", PositionUtil.ToMainMenuPosition, PositionUtil.ToMainMenuExtent, Color.White),
        DefaultTextFactory.Create("Quit", PositionUtil.PausedMenuQuitItemPosition, PositionUtil.PausedMenuQuitItemExtent, Color.White),
    };
    
    public static readonly Entity LostBackground =
        new BackgroundFactory("Assets", "Images", "shipit_titlescreen.png").Create();
    public static readonly Text[] LostMenuItems =
    {
        DefaultTextFactory.Create("You lost!", PositionUtil.LostGamePosition, PositionUtil.LostGameExtent, Color.White),
        DefaultTextFactory.Create("Press ENTER to return to main menu", PositionUtil.LostGamePressEnterPosition, PositionUtil.LostGamePressEnterExtent, Color.White),
    };

    public static readonly Entity MainMenuBackground = new BackgroundFactory("Assets", "Images", "shipit_titlescreen.png").Create();
    public static readonly Text[] MainMenuItems = {
        DefaultTextFactory.Create("Start Game",PositionUtil.StartGamePosition, PositionUtil.StartGameExtent, Color.Crimson),
        DefaultTextFactory.Create("Quit", PositionUtil.QuitGamePosition, PositionUtil.QuitGameExtent, Color.White),
    };


   
}