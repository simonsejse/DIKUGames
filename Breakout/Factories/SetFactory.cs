using DIKUArcade.Input;

namespace Breakout.Factories;

/// <summary>
/// Provides a factory for creating a HashSet of KeyboardKey objects.
/// </summary>
public static class SetFactory
{
    /// <summary>
    /// Creates a HashSet of KeyboardKey objects from the specified arguments.
    /// </summary>
    /// <param name="args">The KeyboardKey objects to be included in the HashSet.</param>
    /// <returns>A HashSet of KeyboardKey objects.</returns>
    public static HashSet<KeyboardKey> Create(params KeyboardKey[] args)
    {
        return args.ToHashSet();
    }
}