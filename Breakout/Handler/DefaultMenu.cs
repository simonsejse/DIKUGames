using System.Drawing;
using Breakout.Commands;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Input;

namespace Breakout.Handler;

/// <summary>
/// Concrete implementation of the <see cref="IMenu"/> interface.
/// </summary>
public class DefaultMenu : IMenu {
    private readonly Entity _background;
    private int ActiveButton { get; set; }
    private Text[] MenuButtons { get; }
    
    /// <summary>
    /// Initializes a new instance of the DefaultMenu class with the provided menu buttons 
    /// and background entity.
    /// </summary>
    /// <param name="menuButtons">The array of menu buttons as Text entities.</param>
    /// <param name="background">The background entity.</param>
    protected DefaultMenu(Text[] menuButtons, Entity background) {
        ActiveButton = 0; 
        MenuButtons = menuButtons;
        _background = background;
    }
    
    /// <summary>
    /// Sets the color of a menu button at the specified index.
    /// </summary>
    /// <param name="index">The index of the menu button.</param>
    /// <param name="color">The color to set.</param>
    private void SetButtonColor(int index, Color color) {
        if (index < 0 || index > MenuButtons.Length)
            return;
        MenuButtons[index].SetColor(color);
    }

    /// <summary>
    /// Shifts the active menu item up, updating the button colors accordingly.
    /// </summary>
    public void ShiftMenuUp() {
        SetButtonColor(ActiveButton, Color.White);
        ActiveButton = (ActiveButton - 1 + MenuButtons.Length) % MenuButtons.Length;
        SetButtonColor(ActiveButton, Color.Crimson);
    }

    /// <summary>
    /// Shifts the active menu item down, updating the button colors accordingly.
    /// </summary>
    public void ShiftMenuDown() {
        SetButtonColor(ActiveButton, Color.White);
        ActiveButton = (ActiveButton + 1) % MenuButtons.Length;
        SetButtonColor(ActiveButton, Color.Crimson);
    }

    /// <summary>
    /// Renders the menu items, including the background and menu buttons.
    /// </summary>
    protected void RenderMenuItems() {
        _background.RenderEntity();
        foreach (var entity in MenuButtons) entity.RenderText();
    }

    public int GetActiveMenuItem() => ActiveButton;
}