using DIKUArcade.GUI;

namespace Breakout;


public class Application
{
    private static void Main(string[] args)
    {
        var windowArgs = new WindowArgs
        {
            Title = "Breakout v0.1", 
            Width = 700, 
            Height = 700
        };
        
        var game = new Game(windowArgs);
        game.Run();
    }
}