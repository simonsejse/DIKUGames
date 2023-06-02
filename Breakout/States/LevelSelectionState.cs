using Breakout.Controller;
using Breakout.Handler;
using Breakout.Utility;
using DIKUArcade.Input;
using DIKUArcade.State;

namespace Breakout.States;

public class LevelSelectionState : DefaultMenu, IGameState
{
    private static LevelSelectionState _instance;
    private readonly IKeyboardPressHandler _keyboardEventHandler;
    private int _selectedLevelIndex;

    private LevelSelectionState() : base(MenuUtil.LevelSelectionMenuItems, MenuUtil.LevelSelectionBackground)
    {
        _keyboardEventHandler = new LevelSelectionStateKeyboardController(this);
        _selectedLevelIndex = 0;
    }

    public static LevelSelectionState GetInstance()
    {
        return _instance ??= new LevelSelectionState();
    }

    public void ResetState()
    {
        _instance = null;
    }

    public void SetLevelIndex(int levelIndex)
    {
        _selectedLevelIndex = levelIndex;
    }

    public void UpdateState()
    {
    }

    public void RenderState()
    {
        base.RenderMenuItems(); 
        
        foreach (var menuItem in MenuUtil.LevelSelectionMenuItems)
        {
            menuItem.RenderText();
        }
    }

    public void HandleKeyEvent(KeyboardAction action, KeyboardKey key)
    {
        if (action is not KeyboardAction.KeyPress) return;
        
        _keyboardEventHandler.HandleKeyPress(key);
    }

    public int GetSelectedLevelIndex()
    {
        return _selectedLevelIndex;
    }

}