using DIKUArcade.GUI;

namespace Breakout;


public class Application
{
    private static void Main(string[] args)
    {
        var windowArgs = new WindowArgs
        {
            Title = "Galaga v0.1", 
            Width = 500, 
            Height = 500
        };
        
        var game = new Game(windowArgs);
        game.Run();
    }
}