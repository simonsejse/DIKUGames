using System.Drawing;
using Breakout.Commands;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Input;

namespace Breakout.Handler;

/// <summary>
/// Concrete implementation of the <see cref="IMenu"/> interface.
/// </summary>
public class DefaultMenu : IMenu
{
    private readonly Entity _background;
    private int ActiveButton { get; set; }
    private Text[] MenuButtons { get; }
    
    protected DefaultMenu(Text[] menuButtons, Entity background)
    {
        ActiveButton = 0; 
        MenuButtons = menuButtons;
        _background = background;
    }
    
    private void SetButtonColor(int index, Color color)
    {
        if (index < 0 || index > MenuButtons.Length)
            return;
        MenuButtons[index].SetColor(color);
    }

    public void ShiftMenuUp()
    {
        SetButtonColor(ActiveButton, Color.White);
        ActiveButton = (ActiveButton - 1 + MenuButtons.Length) % MenuButtons.Length;
        SetButtonColor(ActiveButton, Color.Crimson);
    }

    public void ShiftMenuDown()
    {
        SetButtonColor(ActiveButton, Color.White);
        ActiveButton = (ActiveButton + 1) % MenuButtons.Length;
        SetButtonColor(ActiveButton, Color.Crimson);
    }

    protected void RenderMenuItems()
    {
        _background.RenderEntity();
        foreach (var entity in MenuButtons) entity.RenderText();
    }

    public int GetActiveMenuItem() => ActiveButton;
    
}