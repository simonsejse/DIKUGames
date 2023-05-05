using Breakout.States;

namespace BreakoutTests.StateTest;

[TestFixture]
public class StateTransformerTest
{

    private StateTransformer _transformer;
    
    [SetUp]
    public void Setup()
    {
        _transformer = new StateTransformer();
    }
    
    [Test]
    public void TestTransformStringToState()
    {
        var transformStringToState = _transformer.TransformStringToState(nameof(GameState.Menu));
        Assert.Multiple(() =>
        {
            Assert.That(transformStringToState, Is.EqualTo(GameState.Menu));
            Assert.That(() => _transformer.TransformStringToState("Barry"), Throws.ArgumentException);
        });
    }
    
    [Test]
    public void TestTransformStateToString()
    {
        string transformStateToString = _transformer.TransformStateToString(GameState.Menu);
        Assert.Multiple(() =>
        {
            Assert.That(transformStateToString, Is.EqualTo(nameof(GameState.Menu)));
            Assert.That(() => _transformer.TransformStateToString((GameState) 5), Throws.ArgumentException);
        });    
    }
    
}