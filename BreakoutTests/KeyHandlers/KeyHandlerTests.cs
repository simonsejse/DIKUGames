using Breakout.Commands;
using Breakout.Factories;
using Breakout.Handler;
using DIKUArcade.Input;

namespace BreakoutTests.KeyHandlers;

[TestFixture]
public class KeyHandlerTests
{
    private sealed class KeyReleaseCommand : IKeyboardCommand
    {
        public void Execute()
        {
            Console.WriteLine("Keyboard Key W is released.");
        }
    }
    
    private sealed class KeyPressCommand : IKeyboardCommand
    {
        public void Execute()
        {
            Console.WriteLine("Keyboard Key W is pressed.");
        }
    }
    
    private DefaultKeyboardReleaseHandler _defaultKeyboardReleaseHandler;
    private DefaultKeyboardPressHandler _defaultKeyboardPressHandler;
    private DefaultKeyEventHandler _defaultKeyEventHandler;
    
    [SetUp]
    public void Setup()
    {
        Dictionary<HashSet<KeyboardKey>,IKeyboardCommand> releaseKeyboardActions = new()
        {
            {SetFactory.Create(KeyboardKey.W), new KeyReleaseCommand()}
        };
        Dictionary<HashSet<KeyboardKey>,IKeyboardCommand> pressKeyboardActions = new()
        {
            {SetFactory.Create(KeyboardKey.W), new KeyPressCommand()}
        };
        _defaultKeyboardReleaseHandler = new(releaseKeyboardActions);
        _defaultKeyboardPressHandler = new(pressKeyboardActions);
        _defaultKeyEventHandler = new(pressKeyboardActions, releaseKeyboardActions);
    }

    [Test]
    public void TestKeyRelease()
    {
        using var sw = new StringWriter();
        
        Console.SetOut(sw); 

        _defaultKeyboardReleaseHandler.HandleKeyRelease(KeyboardKey.W);

        string consoleOutput = sw.ToString();

        Assert.That(consoleOutput, Does.Contain("Keyboard Key W is released."));
        Assert.That(consoleOutput, Does.Not.Contain("Keyboard Key W is pressed."));
    }
    
    [Test]
    public void TestKeyPress()
    {
        using var sw = new StringWriter();
        
        Console.SetOut(sw); 

        _defaultKeyboardPressHandler.HandleKeyPress(KeyboardKey.W);

        string consoleOutput = sw.ToString();

        Assert.That(consoleOutput, Does.Not.Contain("Keyboard Key W is released."));
        Assert.That(consoleOutput, Does.Contain("Keyboard Key W is pressed."));
    }
    
    [Test]
    public void TestKeyPressRelease()
    {
        using var sw = new StringWriter();
        
        Console.SetOut(sw); 

        _defaultKeyEventHandler.HandleKeyRelease(KeyboardKey.W);
        _defaultKeyEventHandler.HandleKeyPress(KeyboardKey.W);

        string consoleOutput = sw.ToString();

        Assert.That(consoleOutput, Does.Contain("Keyboard Key W is released."));
        Assert.That(consoleOutput, Does.Contain("Keyboard Key W is pressed."));
    }
}
