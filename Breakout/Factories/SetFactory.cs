using Breakout.Commands;
using Breakout.States;
using DIKUArcade.Input;
using DIKUArcade.State;

namespace Breakout;

public static class SetFactory
{
    public static HashSet<KeyboardKey> Create(params KeyboardKey[] args)
    {
        return args.ToHashSet();
    }
    
    public static HashSet<KeyboardKey> Create(GameState state, IGameState gameRunningState)
    {
        return new 
    }
}