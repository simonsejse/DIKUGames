using DIKUArcade.GUI;

namespace Breakout;


public class Application
{
    private static void Main(string[] args)
    {
        var windowArgs = new WindowArgs
        {
            Title = "Breakout v1", 
            Width = 700, 
            Height = 1200
        };
        
        var game = new Game(windowArgs);
        game.Run();
    }
}