using Breakout.Handler;
using Breakout.States;
using DIKUArcade;
using DIKUArcade.GUI;
using DIKUArcade.Input;

namespace Breakout;

public class Game : DIKUGame
{
    private StateMachine _stateMachine;
    public Game(WindowArgs windowArgs) : base(windowArgs)
    {
        _stateMachine = new StateMachine();
        
    }

    public override void Update()
    {
        _stateMachine.ActiveState.UpdateState();
    }

    public override void Render()
    {
        _stateMachine.ActiveState.RenderState();
    }
    
    public void HandleKeyEvent(KeyboardAction action, KeyboardKey key)
    {
        _stateMachine.ActiveState.HandleKeyEvent(action, key);
    }
    
}