using Breakout.Commands;
using DIKUArcade.Input;

namespace Breakout;

public static class SetFactory
{
    public static HashSet<KeyboardKey> Create(params KeyboardKey[] args)
    {
        return args.ToHashSet();
    }
}