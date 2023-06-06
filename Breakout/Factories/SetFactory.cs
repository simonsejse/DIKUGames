using DIKUArcade.Input;

namespace Breakout.Factories;

public static class SetFactory {
    public static HashSet<KeyboardKey> Create(params KeyboardKey[] args) {
        return args.ToHashSet();
    }
}