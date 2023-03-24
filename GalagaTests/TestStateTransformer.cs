using System.Collections;
using Galaga.GalagaStates;

namespace GalagaTests;

public class TestStateTransformer
{
    private readonly StateTransformer _stateTransformer = new();

    [TestCase(GameStateType.MainMenu)]
    [TestCase(GameStateType.GameRunning)]
    [TestCase(GameStateType.GamePaused)]
    public void TestFromStringToState(GameStateType state)
    {
        string? name = Enum.GetName(state);
        var stateType = _stateTransformer.TransformStringToState(name);
        Assert.That(stateType, Is.EqualTo(state));
    }
    
    [TestCase(GameStateType.MainMenu)]
    [TestCase(GameStateType.GameRunning)]
    [TestCase(GameStateType.GamePaused)]
    public void TestFromStateToString(GameStateType state)
    {
        string? name = Enum.GetName(state);
        string? stateString = _stateTransformer.TransformStateToString(state);
        Assert.That(name, Is.EqualTo(stateString));
    }
    
}