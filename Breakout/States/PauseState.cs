using Breakout.Factories;
using DIKUArcade.Entities;

namespace Breakout.States;

public class PauseState : GameRunningState
{
    private static PauseState? _instance;
    
    private readonly Entity _background;

    public PauseState()
    {
        _background = new BackgroundFactory("Assets", "Images", "BreakoutTitleScreen.png").Create();
    }
    
    public new static PauseState GetInstance()
    {
        return _instance ??= new PauseState();
    }

    public new void ResetState()
    {
    }

    public new void UpdateState()
    {
    }

    public new void RenderState()
    {
        _background.RenderEntity();
        base.RenderState();
    }
}